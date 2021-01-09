using AutoMapper;
using LiveBR.API.ViewModels;
using LiveBR.Application.ViewModels;

namespace LiveBR.API.AutoMapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserViewModel, CreateUserDto>();
        }
    }
}