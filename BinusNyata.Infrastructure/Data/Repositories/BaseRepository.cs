using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BinusNyata.Domain.Base;
using BinusNyata.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BinusNyata.Infrastructure.Data.Repositories
{
  public class BaseRepository<T> : IRepository<T> where T : BaseEntity
  {
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DBContext dbContext)
    {
      _dbSet = dbContext.Set<T>();
    }

    public async Task<T> Add(T entity)
    {
      await _dbSet.AddAsync(entity);
      return entity;
    }

    public Task<T> Delete(T entity)
    {
      _dbSet.Remove(entity);
      return Task.FromResult(entity);
    }

    public Task<T> Update(T entity)
    {
      _dbSet.Update(entity);
      return Task.FromResult(entity);
    }

    public Task<T> Get(Expression<Func<T, bool>> expression)
    {
      return _dbSet.Where(expression).FirstOrDefaultAsync();
    }

    public Task<List<T>> GetAll(Expression<Func<T, bool>> expression)
    {
      return _dbSet.Where(expression).ToListAsync();
    }
  }
}