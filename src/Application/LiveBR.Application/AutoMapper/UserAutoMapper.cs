using AutoMapper;
using LiveBR.Application.ViewModels;
using LiveBR.Domain.Entities;

namespace LiveBR.Application.AutoMapper
{
    public class UserAutoMapper: Profile
    {
        public UserAutoMapper()
        {

            CreateMap<CreateUserDto, User>()
                .ForPath(dst =>
                    dst.Name, map =>
                    map.MapFrom(dto => dto.Name))
                .ForPath(dst =>
                    dst.Email.Value, dto =>
                    dto.MapFrom(cud => cud.Email))
                .ForPath(dst =>
                    dst.Cpf.Value, dto =>
                    dto.MapFrom(cud =>
                        cud.Cpf))
                .ForPath(dst =>
                    dst.Password.Value, cud =>
                    cud.MapFrom(x => x.Password));

            CreateMap<User, CreateUserDtoResponse>()
                .ForPath(dst =>
                    dst.Id, font =>
                    font.MapFrom(obj => obj.Id))
                .ForPath(dst =>
                    dst.Name, font =>
                    font.MapFrom(obj => obj.Name))
                .ForPath(dst =>
                    dst.Email, font =>
                    font.MapFrom(obj => obj.Email.Value))
                .ForPath(dst => dst.Cpf,
                    font =>
                        font.MapFrom(user => user.Cpf.Value));



        }
    }
}