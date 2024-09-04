using Microsoft.EntityFrameworkCore;
using NewsAPI.Models;

namespace Latest_News_Dashboard.Model
{
    public class NewsDbContext :DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options)
        : base(options) { }
        public DbSet<Article> NewsArticles { get; set; }
        public DbSet<Source> Sources { get; set; }

    }
}
