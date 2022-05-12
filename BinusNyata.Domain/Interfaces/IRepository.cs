using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BinusNyata.Domain.Base;

namespace BinusNyata.Domain.Interfaces
{
  public interface IRepository<T> where T : BaseEntity
  {
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
    Task<T> Get(Expression<Func<T, bool>> exp);
    Task<List<T>> GetAll(Expression<Func<T, bool>> exp);
  }
}