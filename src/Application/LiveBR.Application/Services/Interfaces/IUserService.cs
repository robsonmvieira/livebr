using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiveBR.Application.ViewModels;
using LiveBR.Domain.Entities;

namespace LiveBR.Domain.Services
{
    public interface IUserService
    {
        public Task AddUser(CreateUserDto userDto);

        public Task<IList<CreateUserDtoResponse>> Users();
        public Task<User> GetById(Guid id);

        public Task<IEnumerable<CreateUserDtoResponse>> GetUsersByExpression(Expression<Func<User, bool>> expression);
        public Task<CreateUserDtoResponse> GetUserByExpression(Expression<Func<User, bool>> expression);
        public Task<User> FindUserByEmail(Expression<Func<User, bool>> expression);
        public Task RemoveUser(User user);

    }
}