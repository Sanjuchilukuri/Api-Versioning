using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.V2
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("2.0")]
    public class StringListController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Data.Summaries.Where(x => x.StartsWith("S"));
        }
    }
}
