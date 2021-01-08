using LiveBR.Domain.Entities;
using LiveBR.Domain.Interfaces;
using LiveBR.Repository.Context;

namespace LiveBR.Repository.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(LiveBrContext liveBrContext) : base(liveBrContext)
        {
        }
    }
}