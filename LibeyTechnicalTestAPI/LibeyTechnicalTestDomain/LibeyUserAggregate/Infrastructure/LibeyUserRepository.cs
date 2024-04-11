using LibeyTechnicalTestDomain.DocumentTypeAggregate.Domain;
using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using LibeyTechnicalTestDomain.RegionAggregate.Domain;
using System.Net;
using System.Numerics;
using System;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }
        public void Save(LibeyUser libeyUser)
        {
            LibeyUser? item = _context.LibeyUsers.FirstOrDefault(x => x.DocumentNumber == libeyUser.DocumentNumber);
            if (item == null) _context.LibeyUsers.Add(libeyUser);
            else
            {
                item.DocumentTypeId = libeyUser.DocumentTypeId;
                item.Name = libeyUser.Name;
                item.FathersLastName = libeyUser.FathersLastName;
                item.MothersLastName = libeyUser.MothersLastName;
                item.Address = libeyUser.Address;
                item.UbigeoCode = libeyUser.UbigeoCode;
                item.Phone = libeyUser.Phone;
                item.Email = libeyUser.Email;
                item.Password = libeyUser.Password;
                _context.LibeyUsers.Update(item);
            }
            _context.SaveChanges();
        }

        public void Delete(string documentNumber)
        {
            LibeyUser item = _context.LibeyUsers.First(x => x.DocumentNumber == documentNumber);
            item.Active = false;
            _context.LibeyUsers.Update(item);
            _context.SaveChanges();
        }


        public List<LibeyUserResponse> ListResponseBy(string? documentNumber, string? name, string? fathersLastName, string? mothersLastName)
        {

            var q = from libeyUser in _context.LibeyUsers
                    join documentType in _context.DocumentTypes on libeyUser.DocumentTypeId equals documentType.DocumentTypeId
                    join ubigeo in _context.Ubigeos on libeyUser.UbigeoCode equals ubigeo.UbigeoCode
                    join province in _context.Provinces on ubigeo.ProvinceCode equals province.ProvinceCode
                    join region in _context.Regions on province.RegionCode equals region.RegionCode
                    where (libeyUser.DocumentNumber.Contains(documentNumber ?? ""))
                    && (libeyUser.Name.Contains(name ?? ""))
                    && (libeyUser.FathersLastName.Contains(fathersLastName ?? ""))
                    && (libeyUser.MothersLastName.Contains(mothersLastName ?? ""))
                    && libeyUser.Active == true
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        DocumentTypeDescription = documentType.DocumentTypeDescription,
                        Name = libeyUser.Name,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Address = libeyUser.Address,
                        RegionCode = province.RegionCode,
                        RegionDescription = region.RegionDescription,
                        ProvinceCode = ubigeo.ProvinceCode,
                        ProvinceDescription = province.ProvinceDescription,
                        UbigeoCode = libeyUser.UbigeoCode,
                        UbigeoDescription = ubigeo.UbigeoDescription,
                        Phone = libeyUser.Phone,
                        Email = libeyUser.Email,
                        Active = libeyUser.Active
                    };
            var list = q.ToList();

            return list;
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = from libeyUser in _context.LibeyUsers
                    join ubigeo in _context.Ubigeos on libeyUser.UbigeoCode equals ubigeo.UbigeoCode
                    join province in _context.Provinces on ubigeo.ProvinceCode equals province.ProvinceCode
                    where libeyUser.DocumentNumber == documentNumber
                    select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Name = libeyUser.Name,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Address = libeyUser.Address,
                        RegionCode = province.RegionCode,
                        ProvinceCode = ubigeo.ProvinceCode,
                        UbigeoCode = libeyUser.UbigeoCode,
                        Phone = libeyUser.Phone,
                        Email = libeyUser.Email,
                        Password = libeyUser.Password,
                        Active = libeyUser.Active
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }
    }
}