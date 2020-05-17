using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RzrSite.API.Filters;
using RzrSite.API.Middleware;
using RzrSite.DAL;
using RzrSite.DAL.Repositories;
using RzrSite.DAL.Repositories.Interfaces;
using RzrSite.Models.Responses.DbFile;

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
      services.AddAutoMapper(typeof(RzrSiteDbContext), typeof(AddedDbFile));

      services.AddCors(options =>
      {
        options.AddDefaultPolicy(builder => builder.AllowAnyOrigin());
      });

      services.AddControllers(options =>
        {
          options.Filters.Add(new EntityNotFoundFilter());
          options.Filters.Add(new InconsistentStructureFilter());
        });

      services.AddScoped<ICategoryRepo, CategoryRepo>();
      services.AddScoped<IProductLineRepo, ProductLineRepo>();
      services.AddScoped<IDbFileRepo, DbFileRepo>();

      services.AddDbContext<RzrSiteDbContext>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
      }

      app.UseRouting();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
