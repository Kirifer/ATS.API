using Ats.Datalayer.Entities;
using Ats.Models.Entities.Candidate;
using AutoMapper;

namespace Ats.Api.Mappings
{
    public class CandidateMappingProfile: Profile
    {
        public CandidateMappingProfile() {
            CreateMap<AtsCandidateCreateDto, Candidate>(MemberList.Destination);
            CreateMap<AtsCandidateUpdateDto, Candidate>(MemberList.Destination);
            CreateMap<Candidate, AtsCandidateDto>(MemberList.Destination);
        }
    }
}
