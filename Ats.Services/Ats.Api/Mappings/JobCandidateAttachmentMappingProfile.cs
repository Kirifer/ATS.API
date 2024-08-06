using Ats.Datalayer.Entities;
using Ats.Models.Entities.JobCandidate;
using AutoMapper;

namespace Ats.Api.Mappings
{
    public class JobCandidateAttachmentMappingProfile : Profile
    {
        public JobCandidateAttachmentMappingProfile() 
        {
            CreateMap<AtsJobCandidateAttachmentUploadDto, JobCandidateAttachment>(MemberList.Destination);
            CreateMap<JobCandidateAttachment, AtsJobCandidateAttachmentDto>(MemberList.Destination);
        }
    }
}
