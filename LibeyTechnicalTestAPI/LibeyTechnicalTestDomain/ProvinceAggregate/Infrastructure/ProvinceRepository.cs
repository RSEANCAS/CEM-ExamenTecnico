using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Infrastructure
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly Context _context;
        public ProvinceRepository(Context context)
        {
            _context = context;
        }

        public List<ProvinceResponse> ListResponseBy(string regionCode)
        {
            var q = from documentType in _context.Provinces
                    where documentType.RegionCode == regionCode
                    select new ProvinceResponse()
                    {
                        ProvinceCode = documentType.ProvinceCode,
                        RegionCode = documentType.RegionCode,
                        ProvinceDescription = documentType.ProvinceDescription
                    };
            var list = q.ToList();
            return list;
        }
    }
}
