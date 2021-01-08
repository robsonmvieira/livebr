using System.Collections.Generic;
using System.Threading.Tasks;
using LiveBR.Application.ViewModels;
using LiveBR.Domain.Entities;

namespace LiveBR.Domain.Services
{
    public interface IUserService
    {
        public Task AddUser(CreateUserDTO userDto);

        public Task<IList<CreateUserDTOResponse>> Users();
    }
}