using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using LiveBR.Application.ViewModels;
using LiveBR.CrossCutting.Utils.EncoderPassword;
using LiveBR.CrossCutting.ValueObject;
using LiveBR.Domain.Entities;
using LiveBR.Domain.Interfaces;
using LiveBR.Domain.Services;

namespace LiveBR.Application.Services.Implementation
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncoderPassword _encoderPassword;

        public UserService(IUserRepository userRepository, IMapper mapper, IEncoderPassword encoderPassword)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encoderPassword = encoderPassword;
        }
        public async Task AddUser(CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            
            var hashedPassword = _encoderPassword.HashPassword(user.Password.Value, 12, false);
            user.ChangePassword(hashedPassword);
            
            user.IsValidUser();
            await _userRepository.Add(user);
        }

        public async Task<IList<CreateUserDtoResponse>> Users()
        {
            var response = await _userRepository.ListAll();
            var list = _mapper.Map<IList<CreateUserDtoResponse>>(response);
            return list;
        }

        public async Task<User> GetById(Guid id)
        {
            if (id == Guid.Empty) throw new DomainExpection("O Id não pode ser vazio");
            return await _userRepository.FindById(id);
            // return _mapper.Map<CreateUserDtoResponse>(result);
        }

        public async Task<IEnumerable<CreateUserDtoResponse>> GetUsersByExpression(Expression<Func<User, bool>> expression)
        {
            var response = await _userRepository.GetListByExpression(expression);
            var result = _mapper.Map<IList<CreateUserDtoResponse>>(response);
            return result;
        }

        public async Task<CreateUserDtoResponse> GetUserByExpression(Expression<Func<User, bool>> expression)
        {
            var response = await _userRepository.GetByExpression(expression);
            var result = _mapper.Map<CreateUserDtoResponse>(response);
            return result;
        }

        public async Task<User> FindUserByEmail(Expression<Func<User, bool>> expression)
        {
            var response = await _userRepository.GetByExpression(expression);
            return response;
        }

        public async Task RemoveUser(User user)
        {
            await _userRepository.Remove(user);
        }
    }
}