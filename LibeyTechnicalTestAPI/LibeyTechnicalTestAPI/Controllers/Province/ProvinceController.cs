using LibeyTechnicalTestDomain.ProvinceAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Province
{
    [ApiController]
    [Route("[controller]")]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceAggregate _aggregate;
        public ProvinceController(IProvinceAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{regionCode}")]
        public IActionResult ListResponseBy(string regionCode)
        {
            var row = _aggregate.ListResponseBy(regionCode);
            return Ok(row);
        }
    }
}
