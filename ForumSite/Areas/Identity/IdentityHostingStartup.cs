using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
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
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<ForumSiteContext>(options =>
                    options.UseSqlServer(

                /* 
                 Uncomment the Database you want to use.
                 */



                //AzureDb
                //context.Configuration.GetConnectionString("9chanconnectionstring")));

                //LocalDb
                context.Configuration.GetConnectionString("LocalDatabase")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<ForumSiteContext>();
            });
        }
    }
}