using System.Threading.Tasks;

namespace LiveBR.CrossCutting.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}