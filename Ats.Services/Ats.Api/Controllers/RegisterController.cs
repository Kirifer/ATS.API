using System.Net;

using Ats.Core.Config;
using Ats.Core.Extensions;
using Ats.Core.Filtering;
using Ats.Domain.Services.Interface;
using Ats.Shared;
using Ats.Shared.Extensions;

using Microsoft.AspNetCore.Mvc;

namespace Ats.Api.Controllers
{
    public class RegisterController(
        IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService accountService = accountService;

        /// <summary>
        /// Login the user based on credentials
        /// </summary>
        /// <param name="request">The request details of the user to be logged in</param>
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(Response<AuthRegisterRequestDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegisterAsync([FromBody] AuthRegisterRequestDto request)
        {
            var response = await accountService.RegisterAsync(request);
            return StatusCode((int)response.Code, response);

        }
    }
}
