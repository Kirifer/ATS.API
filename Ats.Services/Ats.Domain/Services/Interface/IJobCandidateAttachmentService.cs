using Ats.Core.Abstraction;
using Ats.Core.Filtering;
using Ats.Models.Entities.JobCandidate;
using Ats.Shared.Models;

namespace Ats.Domain.Services.Interface
{
    public interface IJobCandidateAttachmentService : IEntityService
    {
        Task<Response<List<AtsJobCandidateAttachmentDto>>> GetJobCandidateAttachmentsAsync(Guid jobCandidateId);

        Task<Response<AtsJobCandidateAttachmentDto>> GetJobCandidateAttachmentAsync(Guid id);

        Task<Response<AtsJobCandidateAttachmentDto>> UploadJobCandidateAttachmentAsync(Guid jobCandidateId, AtsJobCandidateAttachmentUploadDto uploadPayload);

        Task<Response<EntityBaseDto>> DeleteJobCandidateAttachmentAsync(Guid id);
    }
}
