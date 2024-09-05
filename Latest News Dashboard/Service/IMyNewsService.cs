using Latest_News_Dashboard.Dto;

namespace Latest_News_Dashboard.Service
{
    public interface IMyNewsService
    {
        Task<NewsResponseDTO> GetPagedArticlesAsync(int pageNumber, int pageSize);
    }
}
