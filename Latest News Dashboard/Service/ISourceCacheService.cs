using NewsAPI.Models;

namespace Latest_News_Dashboard.Service
{
    public interface ISourceCacheService
    {
        Task<List<Source>> GetSourcesCacheAsync();
    }
}
