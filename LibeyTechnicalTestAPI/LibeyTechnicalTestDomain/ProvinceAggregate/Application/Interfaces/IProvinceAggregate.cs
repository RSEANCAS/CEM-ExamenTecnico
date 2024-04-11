using LibeyTechnicalTestDomain.ProvinceAggregate.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces
{
    public interface IProvinceAggregate
    {
        List<ProvinceResponse> ListResponseBy(string regionCode);
    }
}
