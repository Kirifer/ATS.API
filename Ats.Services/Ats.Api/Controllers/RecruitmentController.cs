using Ats.Core.Filtering;
using Ats.Domain.Services.Interface;
using Ats.Models.Entities.Recruitment;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ats.Api.Controllers
{
    [ApiController]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.InternalServerError)]
    public class RecruitmentController(IRecruitmentService recruitmentService) : ControllerBase
    {
        private readonly IRecruitmentService recruitmentService = recruitmentService;

        [HttpGet]
        [Route("recruitment")]
        [ProducesResponseType(typeof(Response<List<AtsRecruitmentDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRecruitmentsAsync([FromQuery] AtsRecruitmentFilterDto filter)
        {
            var response = await recruitmentService.GetRecruitmentsAsync(filter);
            return StatusCode((int)response.Code, response);
        }

        [HttpGet]
        [Route("recruitment/{id}")]
        [ProducesResponseType(typeof(Response<AtsRecruitmentDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRecruitmentAsync(Guid id)
        {
            var response = await recruitmentService.GetRecruitmentAsync(id);
            return StatusCode((int)response.Code, response);
        }

        [HttpPost]
        [Route("recruitment")]
        [ProducesResponseType(typeof(Response<AtsRecruitmentDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddRecruitmentAsync([FromBody] AtsRecruitmentCreateDto recruit)
        {
            var response = await recruitmentService.CreateRecruitmentAsync(recruit);
            return StatusCode((int)response.Code, response);
        }

        [HttpPut]
        [Route("recruitment/{id}")]
        [ProducesResponseType(typeof(Response<AtsRecruitmentDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateRecruitmentAsync(Guid id, [FromBody] AtsRecruitmentUpdateDto recruit)
        {
            var response = await recruitmentService.UpdateRecruitmentAsync(id, recruit);
            return StatusCode((int)response.Code, response);
        }

        [HttpDelete]
        [Route("recruitment/{id}")]
        [ProducesResponseType(typeof(Response<AtsRecruitmentDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteRecruitmentAsync(Guid id)
        {
            var response = await recruitmentService.DeleteRecruitmentAsync(id);
            return StatusCode((int)response.Code, response);
        }

    }
}
