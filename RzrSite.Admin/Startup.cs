using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RzrSite.Admin.Configuration;
using RzrSite.Admin.Data;
using RzrSite.Admin.Repository;
using RzrSite.Models.Entities;

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
      services.AddMvc();

      services.AddAuthentication(CookieScheme) // Sets the default scheme to cookies
          .AddCookie(CookieScheme, options =>
          {
            options.AccessDeniedPath = "/account/denied";
            options.LoginPath = "/account/login";
          });

      // Example of how to customize a particular instance of cookie options and
      // is able to also use other services.
      services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, CookieConfiguraion>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IDbFileRepository, DbFileRepository>();

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
      });
    }
  }
}
