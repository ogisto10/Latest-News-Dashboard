using Latest_News_Dashboard.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NewsAPI.Models;

namespace Latest_News_Dashboard.Service
{
    public class SourceCacheService : ISourceCacheService
    {
        private readonly NewsDbContext _context;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "AllSources";

        public SourceCacheService(NewsDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<List<Source>> GetSourcesCacheAsync()
        {
            
            if (!_cache.TryGetValue(CacheKey, out List<Source> sources))
            {
                sources = await _context.Sources.ToListAsync();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromDays(1));
                _cache.Set(CacheKey, sources, cacheOptions);
            }

            return sources;
        }
    }
}

