using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CramCoding.WebApp.Areas.Identity.IdentityHostingStartup))]
namespace CramCoding.WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {

            });
        }
    }
}
