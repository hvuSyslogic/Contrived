using System;
using System.Linq;
using Contrived.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contrived.Data.Persistence
{
    public class ContrivedContext : DbContext
    {
        public ContrivedContext(DbContextOptions<ContrivedContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>().HasData(
                new Blog { Id = 1, Name = "Contrived Blog" }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "Sara" },
                new Author { Id = 2, Name = "Lindsay" },
                new Author { Id = 3, Name = "Claire" }
            );

            modelBuilder.Entity<Post>().HasData(
                Enumerable.Range(1, 10).Select(n => new Post
                {
                    Id = n,
                    BlogId = 1,
                    AuthorId = n % 3 + 1,
                    PostDate = DateTime.Now.AddDays(-n),
                    Title = $"Post {n}",
                    Body = "Some content here..."
                })
                .ToArray()
            );
        }
    }
}