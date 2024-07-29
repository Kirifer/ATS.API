using Ats.Datalayer.Entities;
using Ats.Models.Entities.Recruitment;
using AutoMapper;

namespace Ats.Api.Mappings
{
    public class RecruitmentMappingProfile : Profile
    {
        public RecruitmentMappingProfile()
        {
            CreateMap<AtsRecruitmentCreateDto, Recruitment>(MemberList.Destination);
            CreateMap<Recruitment, AtsRecruitmentDto>(MemberList.Destination);
            CreateMap<AtsRecruitmentUpdateDto, Recruitment>(MemberList.Destination);
        }
    }
 
    }
