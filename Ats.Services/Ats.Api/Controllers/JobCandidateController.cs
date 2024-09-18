using Ats.Core.Filtering;
using Ats.Domain.Services;
using Ats.Domain.Services.Interface;
using Ats.Models.Entities.JobCandidate;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Ats.Api.Controllers
{
/*    [Authorize()]*/
    [ApiController]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.Forbidden)]
    [ProducesResponseType(typeof(Response<>), (int)HttpStatusCode.InternalServerError)]
    public class JobCandidateController(IJobCandidateService jobCandidateService,
        IJobCandidateAttachmentService jobCandidateAttachmentService) : ControllerBase
    {
        private readonly IJobCandidateService jobCandidateService = jobCandidateService;
        private readonly IJobCandidateAttachmentService jobCandidateAttachmentService = jobCandidateAttachmentService;

        [HttpGet]
        [Route("jobcandidate")]
        [ProducesResponseType(typeof(Response<List<AtsJobCandidateDto>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetJobCandidatesAsync([FromQuery] AtsJobCandidateFilterDto filter)
        {
            var response = await jobCandidateService.GetJobCandidatesAsync(filter);
            return StatusCode((int)response.Code, response);
        }

        [HttpGet]
        [Route("jobcandidate/{id}")]
        [ProducesResponseType(typeof(Response<AtsJobCandidateDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetJobCandidateAsync(Guid id)
        {
            var response = await jobCandidateService.GetJobCandidateAsync(id);
            return StatusCode((int)response.Code, response);
        }

        [HttpPost]
        [Route("jobcandidate")]
        [ProducesResponseType(typeof(Response<AtsJobCandidateDto>), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddJobCandidateAsync([FromBody] AtsJobCandidateCreateDto candidate)
        {
            var response = await jobCandidateService.CreateJobCandidateAsync(candidate);
            return StatusCode((int)response.Code, response);
        }

        [HttpPut]
        [Route("jobcandidate/{id}")]
        [ProducesResponseType(typeof(Response<AtsJobCandidateDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateJobCandidateAsync(Guid id, [FromBody] AtsJobCandidateUpdateDto candidate)
        {
            var response = await jobCandidateService.UpdateJobCandidateAsync(id, candidate);
            return StatusCode((int)response.Code, response);
        }

        [HttpDelete]
        [Route("jobcandidate/{id}")]
        [ProducesResponseType(typeof(Response<AtsJobCandidateDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteJobCandidateAsync(Guid id)
        {
            var response = await jobCandidateService.DeleteJobCandidateAsync(id);
            return StatusCode((int)response.Code, response);
        }

        #region Job Candidate Attachment
        // In case you want to download the attachment seperately and lessen the load on the main API (job candidate)
        [HttpGet]
        [Route("jobcandidate/{id}/attachments/{attachmentId}")]
        public async Task<IActionResult> GetJobCandidateAttachmentsAsync(Guid id, Guid attachmentId)
        {
            var response = await jobCandidateAttachmentService.GetJobCandidateAttachmentAsync(attachmentId);
            if (response.Succeeded)
            {
                var attachmentDto = response.Data;
                var fileBytes = Convert.FromBase64String(attachmentDto.Content);
                return File(fileBytes, "application/octet-stream", attachmentDto.FileName);
            }
            return StatusCode((int)response.Code, response);
        }


        [HttpDelete]
        [Route("jobcandidate/{id}/attachments/{attachmentId}")]
        [ProducesResponseType(typeof(Response<AtsJobCandidateAttachmentDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteJobCandidateAttachmentAsync(Guid id, Guid attachmentId)
        {
            var response = await jobCandidateAttachmentService.DeleteJobCandidateAttachmentAsync(attachmentId);
            return StatusCode((int)response.Code, response);
        }
        #endregion
    }
}
