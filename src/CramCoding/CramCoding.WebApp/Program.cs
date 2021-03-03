using CramCoding.Data.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Threading.Tasks;

namespace CramCoding.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            if (args.Contains("seed"))
            {
                await SeedAsync(host);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async Task SeedAsync(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var initializer = scope.ServiceProvider.GetService<AppDbInitializer>();
                await initializer.SeedAsync();
            }
        }
    }
}
