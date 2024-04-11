using LibeyTechnicalTestDomain.UbigeoAggregate.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces
{
    public interface IUbigeoAggregate
    {
        List<UbigeoResponse> ListResponseBy(string provinceCode);
    }
}
