using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.UbigeoAggregate.Infrastructure
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly Context _context;
        public UbigeoRepository(Context context)
        {
            _context = context;
        }

        public List<UbigeoResponse> ListResponseBy(string provinceCode)
        {
            var q = from documentType in _context.Ubigeos
                    where documentType.ProvinceCode == provinceCode
                    select new UbigeoResponse()
                    {
                        UbigeoCode = documentType.UbigeoCode,
                        RegionCode = documentType.RegionCode,
                        UbigeoDescription = documentType.UbigeoDescription
                    };
            var list = q.ToList();
            return list;
        }
    }
}
