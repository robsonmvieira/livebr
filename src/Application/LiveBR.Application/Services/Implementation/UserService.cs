using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LiveBR.Application.ViewModels;
using LiveBR.Domain.Entities;
using LiveBR.Domain.Interfaces;
using LiveBR.Domain.Services;

namespace LiveBR.Application.Services.Implementation
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task AddUser(CreateUserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.Add(user);
        }

        public async Task<IList<CreateUserDTOResponse>> Users()
        {
            var response = await _userRepository.ListAll();
            var list = _mapper.Map<IList<CreateUserDTOResponse>>(response);
            return list;
        }
    }
}