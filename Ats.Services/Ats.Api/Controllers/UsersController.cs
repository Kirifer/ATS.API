using System.Net;

using Ats.Core.Filtering;
using Ats.Models;

using Microsoft.AspNetCore.Mvc;

namespace Ats.Api.Controllers
{
    [ApiController]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.InternalServerError)]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("users")]
        [ProducesResponseType(typeof(Response<List<AtsUserDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsersAsync([FromQuery] AtsUserFilterDto filter)
        {
            var response = await userService.GetUsersAsync(filter);
            return StatusCode(response.StatusCode, response);
        }
    }
}
