using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.RegionAggregate.Application
{
    public class RegionAggregate : IRegionAggregate
    {

        private readonly IRegionRepository _repository;
        public RegionAggregate(IRegionRepository repository)
        {
            _repository = repository;
        }
        public List<RegionResponse> ListResponse()
        {
            var rows = _repository.ListResponse();
            return rows;
        }
    }
}
