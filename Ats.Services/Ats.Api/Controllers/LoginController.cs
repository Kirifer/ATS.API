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
    public class LoginController(
        IMicroServiceConfig serviceConfig,
        IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService accountService = accountService;

        /// <summary>
        /// Login the user based on credentials
        /// </summary>
        /// <param name="request">The request details of the user to be logged in</param>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(typeof(Response<AuthLoginDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> LoginAsync([FromBody] AuthLoginRequestDto request)
        {
            var uriHost = new Uri(Request.GetAbsoluteUrl());
            var response = await accountService.LoginAsync(request);

            // Save the token to cookie as HTTP Only Mode
            if (response.Succeeded && !Equals(response.Data?.Token, null))
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(serviceConfig.JwtConfig!.ExpiryDays),
                    HttpOnly = true,
                    Domain = uriHost.GetDomainName(),
                    Secure = true,
                    SameSite = SameSiteMode.None // Disable for localhost
                };

                Response.Cookies.Append(serviceConfig.JwtConfig!.CookieName, response.Data?.Token!, cookieOptions);
            }

            return StatusCode((int)response.Code, response);

        }
    }
}
