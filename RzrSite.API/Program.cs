using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RzrSite.API;

namespace RzrSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).
              Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              var configuration = new ConfigurationBuilder()
            .AddCommandLine(args)
            .Build();

              webBuilder.UseConfiguration(configuration)
          .UseUrls(configuration["urls"] ?? "http://+:4242")
          .UseStartup<Startup>();
          });
    }
}
