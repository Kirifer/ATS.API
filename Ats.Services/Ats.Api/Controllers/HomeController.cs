using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ats.Api.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("")]
        [Route("Home")]
        public IActionResult Index()
        {
            return Ok("Ats Api 1.0");
        }
    }
}
