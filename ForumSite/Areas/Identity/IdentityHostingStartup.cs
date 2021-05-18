using System;
using ForumSite.Areas.Identity.Data;
using ForumSite.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ForumSite.Areas.Identity.IdentityHostingStartup))]
namespace ForumSite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ForumSiteContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("9chanconnectionstring")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<ForumSiteContext>();
            });
        }
    }
}