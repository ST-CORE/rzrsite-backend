using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RzrSite.Admin.Helper;

namespace RzrSite.Admin
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(webBuilder =>
      {
        var configuration = new ConfigurationBuilder()
          .AddCommandLine(args)
          .Build();

        if (configuration["rzrhost"] != null)
        {
          UrlLocator.ApiUrl = configuration["rzrhost"];
        }
        else
        {
          UrlLocator.ApiUrl = "http://localhost:4242";
        }

        webBuilder.UseConfiguration(configuration)
        .UseStartup<Startup>();
      });
  }
}
