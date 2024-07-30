using Ats.Core.Filtering;
using Ats.Domain.Services.Interface;
using Ats.Models.Entities.JobRole;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ats.Api.Controllers
{
    [ApiController]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.InternalServerError)]
    public class JobRoleController(IJobRoleService jobRoleService) : ControllerBase
    {
        private readonly IJobRoleService jobRoleService = jobRoleService;

        [HttpGet]
        [Route("jobrole")]
        [ProducesResponseType(typeof(Response<List<AtsJobRoleDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetJobRolesAsync([FromQuery] AtsJobRoleFilterDto filter)
        {
            var response = await jobRoleService.GetJobRolesAsync(filter);
            return StatusCode((int)response.Code, response);
        }

        [HttpGet]
        [Route("jobrole/{id}")]
        [ProducesResponseType(typeof(Response<AtsJobRoleDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetJobRoleAsync(Guid id)
        {
            var response = await jobRoleService.GetJobRoleAsync(id);
            return StatusCode((int)response.Code, response);
        }

        [HttpPost]
        [Route("jobrole")]
        [ProducesResponseType(typeof(Response<AtsJobRoleDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddJobRoleAsync([FromBody] AtsJobRoleCreateDto role)
        {
            var response = await jobRoleService.CreateJobRoleAsync(role);
            return StatusCode((int)response.Code, response);
        }

        [HttpPut]
        [Route("jobrole/{id}")]
        [ProducesResponseType(typeof(Response<AtsJobRoleDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateJobRoleAsync(Guid id, [FromBody] AtsJobRoleUpdateDto role)
        {
            var response = await jobRoleService.UpdateJobRoleAsync(id, role);
            return StatusCode((int)response.Code, response);
        }

        [HttpDelete]
        [Route("jobrole/{id}")]
        [ProducesResponseType(typeof(Response<AtsJobRoleDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteJobRoleAsync(Guid id)
        {
            var response = await jobRoleService.DeleteJobRoleAsync(id);
            return StatusCode((int)response.Code, response);
        }


    }
}
