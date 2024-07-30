using Ats.Datalayer.Entities;
using Ats.Models.Entities.JobRole;
using AutoMapper;

namespace Ats.Api.Mappings
{
    public class JobRoleMappingProfile : Profile
    {
        public JobRoleMappingProfile() 
        {
            CreateMap<AtsJobRoleCreateDto, JobRole>(MemberList.Destination);
            CreateMap<AtsJobRoleUpdateDto, JobRole>(MemberList.Destination);
            CreateMap<JobRole, AtsJobRoleDto>(MemberList.Destination);
        }
    }
}
