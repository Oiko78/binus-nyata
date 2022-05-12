using BinusNyata.Application.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BinusNyata.Application
{
  public class Startup
  {
    public readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDistributedMemoryCache();
      services.AddMvc(opt =>
      {
        opt.EnableEndpointRouting = false;
      });
      services.AddRouting(opt =>
      {
        opt.LowercaseUrls = true;
      });
      // services.AddSession(options =>
      // {
      //   options.IdleTimeout = TimeSpan.FromHours(1);
      //   options.Cookie.HttpOnly = true;
      //   options.Cookie.IsEssential = true;
      // });
      // services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      services.AddControllersWithViews().AddRazorRuntimeCompilation();
      services.AddDatabase(_configuration);
      services.AddRepositories();
      services.AddBusinessServices();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
      }
      app.Use(async (context, next) =>
      {
        await next();
        if (context.Response.StatusCode == StatusCodes.Status404NotFound)
        {
          context.Request.Path = "/Home";
          await next();
        }
      });
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRouting();
      app.UseAuthorization();
      // app.UseSession();
      app.UseMvcWithDefaultRoute();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}"
        );
      });
    }
  }
}
