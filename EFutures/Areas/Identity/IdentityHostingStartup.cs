using System;
using EFutures.Areas.Identity.Data;
using EFutures.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EFutures.Areas.Identity.IdentityHostingStartup))]
namespace EFutures.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EFutureDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("EFutureDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    
                    })
                    .AddEntityFrameworkStores<EFutureDbContext>();
            });
        }
    }
}