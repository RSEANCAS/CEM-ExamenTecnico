using LibeyTechnicalTestDomain.RegionAggregate.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces
{
    public interface IRegionAggregate
    {
        List<RegionResponse> ListResponse();
    }
}
