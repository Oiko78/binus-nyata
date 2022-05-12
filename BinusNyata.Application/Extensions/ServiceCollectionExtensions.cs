using System.Linq;
using System.Reflection;
using BinusNyata.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BinusNyata.Application.Extensions
{
  public static class ServiceCollectionExtension
  {
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) =>
      services.AddDbContext<DBContext>(optionsAction: opt =>
      {
        opt.UseSqlServer(configuration.GetConnectionString("ConnectionString"), config =>
        {
          config.MigrationsAssembly("BinusNyata.Infrastructure");
        });
        opt.UseLoggerFactory(LoggerFactory.Create(config => config.AddConsole()));
      });

    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
      Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(type => type.IsClass && !type.IsAbstract && type.FullName.EndsWith("Service"))
        .ToList()
        .ForEach(type => services.AddScoped(type));

      return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
      Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(type => type.IsClass && !type.IsAbstract && type.FullName.EndsWith("Repository"))
        .ToList()
        .ForEach(type => services.AddScoped(type));

      return services;
    }
  }
}