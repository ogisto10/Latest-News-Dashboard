using Latest_News_Dashboard.Dto;
using Microsoft.EntityFrameworkCore;
using NewsAPI.Models;

namespace Latest_News_Dashboard.Service
{
    public interface IMyNewsService
    {
        Task<NewsResponseDTO> GetPagedArticlesAsync(int pageNumber, int pageSize);
        Task<NewsResponseDTO> SearchArticlesAsync(int pageNumber, int pageSize, string? searchQuery = null);
        Task<NewsResponseDTO> FilterArticlesAsync(int pageNumber, int pageSize, string? sourceName = null);
        Task<List<Source>> GetAllSourcesAsync();
        
    }
}
