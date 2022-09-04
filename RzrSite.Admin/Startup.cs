using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RzrSite.Admin.Data;
using RzrSite.Admin.Repositories;
using RzrSite.Admin.Repositories.Interfaces;
using RzrSite.Admin.Repository;

namespace RzrSite.Admin
{
  public class Startup
  {

    public const string CookieScheme = "rzrsite.cookie.scheme";

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAutoMapper(typeof(Startup));
      services.AddMvc();

      services.AddAuthentication(CookieScheme) // Sets the default scheme to cookies
          .AddCookie(CookieScheme, options =>
          {
            options.AccessDeniedPath = "/account/accessdenied";
            options.LoginPath = "/account/login";
          });
      // Example of how to customize a particular instance of cookie options and
      // is able to also use other services.
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<ICategoryRepository, CategoryRepository>();
      services.AddScoped<IProductLineRepository, ProductLineRepository>();
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<IDbFileRepository, DbFileRepository>();
      services.AddScoped<IAdvantageRepository, AdvantageRepository>();
      services.AddScoped<IImageRepository, ImageRepository>();
			services.AddScoped<IVideoRepository, VideoRepository>();
			services.AddScoped<IFeatureTypeRepository, FeatureTypeRepository>();
      services.AddScoped<IFeatureRepository, FeatureRepository>();

      services.AddDbContext<AdminDbContext>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapDefaultControllerRoute();
      }
      );
    }
  }
}
