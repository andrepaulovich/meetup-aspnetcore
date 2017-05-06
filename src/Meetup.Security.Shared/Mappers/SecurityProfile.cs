using Meetup.Security.Entities;
using Meetup.Security.Shared.Dtos;

namespace Meetup.Security.Shared.Mappers
{
    public class SecurityProfile : AutoMapper.Profile
    {
        public SecurityProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserProfile, UserProfileDto>().ReverseMap();
            CreateMap<Functionality, FunctionalityDto>().ReverseMap();
            CreateMap<ProfileFunctionality, ProfileFunctionalityDto>().ReverseMap();
            CreateMap<Profile, ProfileDto>().ReverseMap();
            CreateMap<Token, TokenDto>().ReverseMap();
        }
    }
}
