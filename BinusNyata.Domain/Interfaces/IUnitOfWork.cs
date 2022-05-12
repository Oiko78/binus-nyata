using System.Threading.Tasks;
using BinusNyata.Domain.Base;

namespace BinusNyata.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();

        IRepository<T> AsyncRepository<T>() where T : BaseEntity;
    }
}