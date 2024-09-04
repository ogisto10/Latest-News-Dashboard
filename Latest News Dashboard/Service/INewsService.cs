using Latest_News_Dashboard.Dto;

namespace Latest_News_Dashboard.Service
{
    public interface INewsService
    {
        Task<IEnumerable<NewsArticleDTO>> FetchLatestNewsAsync(string q, DateTime from, DateTime to);
        Task UpdateNewsAsync();
    }
}
