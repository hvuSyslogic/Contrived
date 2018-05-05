using System;
using System.Collections.Generic;
using System.Text;
using Contrived.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contrived.Data.Persistence
{
    public class ContrivedContext : DbContext
    {
        public ContrivedContext(DbContextOptions<ContrivedContext> options) : base(options) { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
