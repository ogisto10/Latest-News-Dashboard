using Microsoft.EntityFrameworkCore;
using NewsAPI.Models;

namespace Latest_News_Dashboard.Model
{
    public class NewsDbContext :DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options)
        : base(options) { }
        public DbSet<KeyedArticle> Articles { get; set; }
        public DbSet<Source> Sources { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<KeyedArticle>()
                .HasIndex(a => a.Author)
                .HasDatabaseName("IX_Author");

            base.OnModelCreating(modelBuilder);
        }


    }
}
