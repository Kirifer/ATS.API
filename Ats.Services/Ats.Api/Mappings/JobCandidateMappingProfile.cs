using Ats.Datalayer.Entities;
using Ats.Models.Entities.JobCandidate;
using AutoMapper;

namespace Ats.Api.Mappings
{
    public class JobCandidateMappingProfile : Profile
    {
        public JobCandidateMappingProfile() 
        {
            CreateMap<AtsJobCandidateCreateDto, JobCandidate>(MemberList.Destination);
            CreateMap<JobCandidate, AtsJobCandidateDto>(MemberList.Destination);
            CreateMap<AtsJobCandidateUpdateDto, JobCandidate>(MemberList.Destination);
        }
    }
}
