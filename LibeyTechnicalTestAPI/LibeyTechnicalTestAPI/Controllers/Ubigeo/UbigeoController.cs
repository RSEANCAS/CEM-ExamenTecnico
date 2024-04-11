using LibeyTechnicalTestDomain.UbigeoAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Ubigeo
{
    [ApiController]
    [Route("[controller]")]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoAggregate _aggregate;
        public UbigeoController(IUbigeoAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{provinceCode}")]
        public IActionResult ListResponseBy(string provinceCode)
        {
            var row = _aggregate.ListResponseBy(provinceCode);
            return Ok(row);
        }
    }
}
