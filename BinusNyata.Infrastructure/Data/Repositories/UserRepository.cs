using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BinusNyata.Domain.Accounts;
using BinusNyata.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace BinusNyata.Infrastructure.Data.Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    private readonly DBContext _dbContext;

    public UserRepository(DBContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public Task<Role> GetRole(Expression<Func<Role, bool>> expression)
    {
      return _dbContext.Set<Role>().Where(expression).FirstOrDefaultAsync();
    }
  }
}
