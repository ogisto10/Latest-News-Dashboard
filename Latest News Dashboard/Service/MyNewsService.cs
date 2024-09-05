using Latest_News_Dashboard.Dto;
using Latest_News_Dashboard.Model;
using Microsoft.EntityFrameworkCore;

namespace Latest_News_Dashboard.Service
{
    public class MyNewsService:IMyNewsService
    {
        private readonly NewsDbContext _context;

        public MyNewsService(NewsDbContext context )
        {
            _context = context;
        }
        public async Task<NewsResponseDTO> GetPagedArticlesAsync(int pageNumber, int pageSize)
        {
            var totalArticles = await _context.Articles.CountAsync();
            var articles = await _context.Articles
                                         .Skip((pageNumber - 1) * pageSize) 
                                         .Take(pageSize)  
                                         .Select(article => new ArticleDto(article)) 
                                         .ToListAsync();
            return new NewsResponseDTO
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Total = totalArticles,
                Articles = articles
            };
        }
    }
}
