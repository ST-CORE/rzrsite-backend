using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RzrSite.DAL;
using RzrSite.DAL.Reposiories.Interfaces;
using RzrSite.DAL.Repositories;
using System.Reflection;

namespace RzrSite.API
{
  public class Startup
  {
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAutoMapper(typeof(RzrSiteDbContext));
      services.AddControllers();

      services.AddScoped<ICategoryRepo, CategoryRepo>();

      services.AddDbContext<RzrSiteDbContext>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
