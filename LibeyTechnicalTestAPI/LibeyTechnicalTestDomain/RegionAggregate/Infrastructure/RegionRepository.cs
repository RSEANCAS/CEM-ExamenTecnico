using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.RegionAggregate.Infrastructure
{
    public class RegionRepository : IRegionRepository
    {
        private readonly Context _context;
        public RegionRepository(Context context)
        {
            _context = context;
        }

        public List<RegionResponse> ListResponse()
        {
            var q = from documentType in _context.Regions
                    select new RegionResponse()
                    {
                        RegionCode = documentType.RegionCode,
                        RegionDescription = documentType.RegionDescription
                    };
            var list = q.ToList();
            return list;
        }
    }
}
