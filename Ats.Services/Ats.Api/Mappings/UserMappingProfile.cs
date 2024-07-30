using Ats.Datalayer.Entities;
using Ats.Models;

using AutoMapper;

namespace Ats.Api.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AtsUserCreateDto, User>(MemberList.Destination);
            CreateMap<AtsUserUpdateDto, User>(MemberList.Destination);
            CreateMap<User, AtsUserDto>(MemberList.Destination);
        }
    }
}
