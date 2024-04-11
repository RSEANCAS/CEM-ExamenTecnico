using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application
{
    public class ProvinceAggregate : IProvinceAggregate
    {
        private readonly IProvinceRepository _repository;
        public ProvinceAggregate(IProvinceRepository repository)
        {
            _repository = repository;
        }
        public List<ProvinceResponse> ListResponseBy(string regionCode)
        {
            var rows = _repository.ListResponseBy(regionCode);
            return rows;
        }
    }
}
