using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BinusNyata.Domain.Accounts;
using BinusNyata.Domain.Interfaces;

namespace BinusNyata.Domain.Users
{
  public interface IUserRepository : IRepository<User>
  {
    public Task<Role> GetRole(Expression<Func<Role, bool>> expression);
  }
}