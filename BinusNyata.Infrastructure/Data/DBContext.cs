using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BinusNyata.Domain.Accounts;
using BinusNyata.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace BinusNyata.Infrastructure.Data
{
  public class DBContext : DbContext
  {
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(
        AppDomain.CurrentDomain
          .GetAssemblies()
          .Where(x => x.FullName.Contains("BinusNyata.Domain"))
          .First()
      );
    }
  }
}
