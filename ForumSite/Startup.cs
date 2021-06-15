using _9Chan.Core.Models;
using _9Chan.Data.Repository;
using _9Chan.Data.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ForumSite
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddScoped<ICategoryData, CategoryData>();
            services.AddScoped<ISubCategoryData, SubCategoryData>();
            services.AddScoped<IThreadData, ThreadData>();
            services.AddScoped<IPostData, PostData>();
            services.AddScoped<IMessageData, MessageData>();
            services.AddScoped<IPictureData, PictureData>();
            services.AddScoped<ICommentData, CommentData>();
            services.AddScoped<ILikeData, LikeData>();
            services.AddScoped<IGroupData, GroupData>();
            services.AddScoped<IUserGroupManager, UserGroupManager>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddScoped<IEncryption, Encryption>();
            services.Configure<EncryptionOptions>(Configuration);

            services.AddControllers();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy",
                    policy =>
                        policy.RequireRole("Admin"));
            });
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Forum/Admin", "AdminPolicy");
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}