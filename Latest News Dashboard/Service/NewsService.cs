using Latest_News_Dashboard.Dto;
using Latest_News_Dashboard.Model;
using Latest_News_Dashboard.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace Latest_News_Dashboard.Service
{
    public class NewsService : INewsService
    {
        private readonly NewsApiClient _newsApiClient;
        private readonly NewsDbContext _context;
        private readonly IOptions<NewsApiOptions> _newsApiOptions;
        public NewsService(NewsDbContext context, IOptions<NewsApiOptions> newsApiOptions)
        {
           
            _context = context;
            _newsApiOptions = newsApiOptions;
            _newsApiClient = new NewsApiClient(_newsApiOptions.Value.ApiKey);
        }

        public async Task<IEnumerable<ArticleDto>> FetchLatestNewsAsync(string q, DateTime from, DateTime to)
        {
            var articlesResponse =await _newsApiClient.GetEverythingAsync(new EverythingRequest
            {
                Q = q,
                SortBy = SortBys.Popularity,
                Language = Languages.EN,
                From = from,
                To = to
            });
            if (articlesResponse.Status == Statuses.Ok)
            {
                return articlesResponse.Articles.Select(a => new ArticleDto(a));
            }
            else
                return null;
        }

        public async Task UpdateYesterdayNews(string q)
        {
            //fetch the news of yesterday
            var news = await FetchLatestNewsAsync(q, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(-1));
            //save results in the db
            if (news != null && news.Any())
            {
                await _context.AddRangeAsync(news);
                await _context.SaveChangesAsync();
            }
        }
    }
}
