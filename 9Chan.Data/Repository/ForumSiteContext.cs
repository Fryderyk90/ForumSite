using _9Chan.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _9Chan.Data.Repository
{
    public class ForumSiteContext : IdentityDbContext<User>
    {
        public ForumSiteContext(DbContextOptions<ForumSiteContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> RegUsers { get; set; }
        public DbSet<PersonalMessage> PersonalMessages { get; set; }
        public DbSet<ProfilePicture> ProfilePictures { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<ForumGroup> Groups { get; set; }
        public DbSet<UserGroups> UserToGroup { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    // Customize the ASP.NET Identity model and override the defaults if needed.
        //    // For example, you can rename the ASP.NET Identity table names and more.
        //    // Add your customizations after calling base.OnModelCreating(builder);
        //}
    }
}