using Microsoft.EntityFrameworkCore;
using PracticeProject.Entities;

namespace PracticeProject
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; } = null!;
        public DbSet<Post> Posts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = test.db");
        }
    }
}
