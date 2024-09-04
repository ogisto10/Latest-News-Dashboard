using Microsoft.EntityFrameworkCore;

namespace Latest_News_Dashboard.Model
{
    public class NewsDbContext :DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options)
        : base(options) { }
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<Source> Sources { get; set; }

    }
}
