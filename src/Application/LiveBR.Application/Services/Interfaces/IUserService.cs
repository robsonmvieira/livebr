using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LiveBR.Application.ViewModels;
using LiveBR.Domain.Entities;

namespace LiveBR.Domain.Services
{
    public interface IUserService
    {
        public Task AddUser(CreateUserDto userDto);

        public Task<IList<CreateUserDtoResponse>> Users();
        public Task<CreateUserDtoResponse> GetById(Guid id);
    }
}