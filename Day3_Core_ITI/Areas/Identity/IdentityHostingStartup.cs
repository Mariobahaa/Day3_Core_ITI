using System;
using Day3_Core_ITI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Day3_Core_ITI.Areas.Identity.IdentityHostingStartup))]
namespace Day3_Core_ITI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
      
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AccountContext>(options =>

                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AccountContextConnection"),
                        options => options.EnableRetryOnFailure())

                    ) ;

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AccountContext>();
            });
        }
    }
}