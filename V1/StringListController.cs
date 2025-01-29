using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioning.V1
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class StringListController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Data.Summaries.Where(x => x.StartsWith("B"));
        }
    }
}
