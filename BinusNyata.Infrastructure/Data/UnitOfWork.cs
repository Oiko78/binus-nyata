using System;
using System.Threading.Tasks;
using BinusNyata.Domain.Base;
using BinusNyata.Domain.Interfaces;
using BinusNyata.Infrastructure.Data.Repositories;

namespace BinusNyata.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _dbContext;

        public UnitOfWork(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepository<T> AsyncRepository<T>() where T : BaseEntity
        {
            return new BaseRepository<T>(_dbContext);
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}