using AutoMapper;
using LiveBR.Application.ViewModels;
using LiveBR.Domain.Entities;

namespace LiveBR.Application.AutoMapper
{
    public class UserAutoMapper: Profile
    {
        public UserAutoMapper()
        {
            CreateMap<CreateUserDTO, User>()
                .ForMember(dst =>
                    dst.Name, map =>
                    map.MapFrom(dto => dto.Name))
                .ForMember(dst =>
                    dst.Email.Value, dto =>
                    dto.MapFrom(cud => cud.Email))
                .ForMember(dst =>
                    dst.Cpf.Value, dto =>
                    dto.MapFrom(cud =>
                        cud.CPF));

            CreateMap<User, CreateUserDTOResponse>()
                .ForMember(dst =>
                    dst.Id, font =>
                    font.MapFrom(obj => obj.Id))
                .ForMember(dst =>
                    dst.Name, font =>
                    font.MapFrom(obj => obj.Name))
                .ForMember(dst =>
                    dst.Email, font =>
                    font.MapFrom(obj => obj.Email.Value))
                .ForMember(dst => dst.CPF,
                    font =>
                        font.MapFrom(user => user.Cpf.Value));

        }
    }
}