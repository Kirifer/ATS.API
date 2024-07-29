using Ats.Core.Filtering;
using Ats.Domain.Services.Interface;
using Ats.Models.Entities.Candidate;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ats.Api.Controllers
{
    [ApiController]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.InternalServerError)]
    public class CandidatesController(ICandidateService candidateService) : ControllerBase
    {
        private readonly ICandidateService candidateService = candidateService;

        [HttpGet]
        [Route("candidates")]
        [ProducesResponseType(typeof(Response<List<AtsCandidateDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCandidatesAsync([FromQuery] AtsCandidateFilterDto filter)
        {
            var response = await candidateService.GetCandidatesAsync(filter);
            return StatusCode((int)response.Code, response);
        }

        [HttpGet]
        [Route("candidates/{id}")]
        [ProducesResponseType(typeof(Response<AtsCandidateDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCandidateAsync(Guid id)
        {
            var response = await candidateService.GetCandidateAsync(id);
            return StatusCode((int)response.Code, response);
        }

        [HttpPost]
        [Route("candidates")]
        [ProducesResponseType(typeof(Response<AtsCandidateDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddCandidateAsync([FromBody] AtsCandidateCreateDto candidate)
        {
            var response = await candidateService.CreateCandidateAsync(candidate);
            return StatusCode((int)response.Code, response);
        }

        [HttpPut]
        [Route("candidates/{id}")]
        [ProducesResponseType(typeof(Response<AtsCandidateDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateCandidateAsync(Guid id, [FromBody] AtsCandidateUpdateDto candidate)
        {
            var response = await candidateService.UpdateCandidateAsync(id, candidate);
            return StatusCode((int)response.Code, response);
        }

        [HttpDelete]
        [Route("candidates/{id}")]
        [ProducesResponseType(typeof(Response<AtsCandidateDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCandidateAsync(Guid id)
        {
            var response = await candidateService.DeleteCandidateAsync(id);
            return StatusCode((int)response.Code, response);
        }


    }
}
