using AutoMapper;
using LiveBR.API.ViewModels;
using LiveBR.Application.ViewModels;
using LiveBR.Domain.Entities;

namespace LiveBR.API.AutoMapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserViewModel, CreateUserDto>();

            CreateMap<User, UserLoginResponseViewModel>()
                .ForPath(dst => dst.Email, user =>
                    user.MapFrom(x => x.Email.Value))
                .ForPath(dst => dst.Name, user =>
                    user.MapFrom(x => x.Name));
        }
    }
}