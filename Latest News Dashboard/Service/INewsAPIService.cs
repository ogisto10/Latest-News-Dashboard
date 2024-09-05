using Latest_News_Dashboard.Dto;

namespace Latest_News_Dashboard.Service
{
    public interface INewsAPIService
    {
        Task<IEnumerable<ArticleDto>> FetchLatestNewsAsync(string q, DateTime from, DateTime to);
        Task UpdateYesterdayNews(string q);
    }
}
