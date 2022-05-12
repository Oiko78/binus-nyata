using BinusNyata.Domain.Users;

namespace BinusNyata.Infrastructure.Data.Repositories
{
  public class UserRepository : BaseRepository<User>, IUserRepository
  {
    public UserRepository(DBContext dbContext) : base(dbContext)
    { }
  }
}