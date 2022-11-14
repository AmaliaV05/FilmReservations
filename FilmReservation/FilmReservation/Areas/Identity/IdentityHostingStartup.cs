using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FilmReservation.Areas.Identity.IdentityHostingStartup))]
namespace FilmReservation.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}