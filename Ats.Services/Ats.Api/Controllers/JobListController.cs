using System.Net;

using Ats.Core.Filtering;
using Ats.Domain.Services.Interface;
using Ats.Models.Entities.JobList;
using Microsoft.AspNetCore.Mvc;

namespace Ats.Api.Controllers
{
    [ApiController]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.InternalServerError)]
    public class JobListController(IJobListService joblistService) : ControllerBase
    {
        private readonly IJobListService joblistService = joblistService;

        [HttpGet]
        [Route("job_list")]
        [ProducesResponseType(typeof(Response<List<AtsJobListDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetJobListAsync()
        {
            var response = await joblistService.GetJobListAsync();
            return StatusCode((int)response.Code, response);
        }
    }
}
