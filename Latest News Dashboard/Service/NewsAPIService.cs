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
    public class NewsAPIService : INewsAPIService
    {
        private readonly NewsApiClient _newsApiClient;
        private readonly NewsDbContext _context;
        //Options pattern for accessing News API configuration
        private readonly IOptions<NewsApiOptions> _newsApiOptions;
        public NewsAPIService(NewsDbContext context, IOptions<NewsApiOptions> newsApiOptions)
        {
           
            _context = context;
            _newsApiOptions = newsApiOptions;
            // Initialize the API client with the API key
            _newsApiClient = new NewsApiClient(_newsApiOptions.Value.ApiKey);
        }
        //Method to fetch the latest news from the News API based on a search query and date range
        public async Task<IEnumerable<ArticleDto>> FetchLatestNewsAsync(string q, DateTime from, DateTime to)
        {
            // Fetch articles based on the given query, from date, and to date
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
        // Method to update the news for yesterday's date based on a query
        public async Task UpdateYesterdayNews(string q)
        {
            var news = await FetchLatestNewsAsync(q, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(-1));
            if (news != null && news.Any())
            {
                try
                {

                    var existingSources =await  _context.Sources.Select(s=>s.Id).ToListAsync();
                    var sources = news.Select(article => new Source { Name = article.Source.Name, Id = article.Source.Name })
                    .ExceptBy(existingSources,s=>s.Id)// Only take sources that aren't in the existing list
                    .DistinctBy(s=>s.Name);// Ensure sources are unique by name
                    await _context.Sources.AddRangeAsync(sources);
                var articles = news.Select(article => new KeyedArticle
                {
                    Title = article.Title,
                    Content = article.Content,
                    Author = article.Author,
                    Description = article.Description,
                    Url = article.Url,
                    UrlToImage = article.UrlToImage,
                    PublishedAt = article.PublishedAt,
                    SourceId = article.Source.Name
                });
  await _context.Articles.AddRangeAsync(articles);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex) {
                    throw;
                }
            }
        }
    }
}
