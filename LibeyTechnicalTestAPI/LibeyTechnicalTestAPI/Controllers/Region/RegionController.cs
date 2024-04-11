using LibeyTechnicalTestDomain.RegionAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.Region
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionAggregate _aggregate;
        public RegionController(IRegionAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("")]
        public IActionResult ListResponse()
        {
            var row = _aggregate.ListResponse();
            return Ok(row);
        }
    }
}
