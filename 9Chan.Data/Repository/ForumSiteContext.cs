using System;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                SubCategoryId = 1,
                Title = "Bilar",
                Description = "Här hittar du disskusioner om bilar"
            });
            builder.Entity<SubCategory>().HasData(new SubCategory
            {
                Id = 1,
                CategoryId = 1,
                ThreadId = 1,
                Title = "Volvo",
                Description = "Här diskuterar vi enbart Volvo bilar"

            });
            //builder.Entity<Thread>().HasData(new Thread
            //{
            //    Id = 1,
            //    SubCategoryId = 1,
            //    PostId = 1,
            //    UserId = "e4e322dd-aed7-4ba3-825b-a4b5097428e4",
            //    Title = "Vilken Volvo bil ska jag köpa!?",
            //    Description = "",
            //    IsSticky = false,
            //    DateCreated = DateTime.Today
            //});
            //builder.Entity<Post>().HasData(new Post
            //{
            //    Id = 1,
            //    ThreadId = 1,
            //    UserId = "e4e322dd-aed7-4ba3-825b-a4b5097428e4",
            //    PostText = "Jag har funderat på att köpa S90 men den verkar vara dyr har någon erfarenhet av denna model?",
            //    DatePosted = DateTime.Now,
            //    IsReported = false
            //});

            //builder.Entity<Post>().HasData(new Post
            //{
            //    Id = 2,
            //    ThreadId = 1,
            //    UserId = "e4e322dd-aed7-4ba3-825b-a4b5097428e4",
            //    PostText = "Just det jag glömde säga att V60 modelen också är intressant, sry för dubbel post",
            //    DatePosted = DateTime.Now,
            //    IsReported = false
            //});
        }
    }
}
