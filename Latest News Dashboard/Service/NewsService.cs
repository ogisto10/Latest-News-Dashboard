using Latest_News_Dashboard.Dto;
using Latest_News_Dashboard.Model;
using Latest_News_Dashboard.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Latest_News_Dashboard.Service
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;
        private readonly NewsDbContext _context;
        private readonly IOptions<NewsApiOptions> _newsApiOptions;
        public NewsService(HttpClient httpClient, NewsDbContext context, IOptions<NewsApiOptions> newsApiOptions)
        {
            _httpClient = httpClient;
            _context = context;
            _newsApiOptions = newsApiOptions;
        }

        public async Task<IEnumerable<NewsArticleDTO>> FetchLatestNewsAsync(string q, DateTime from, DateTime to)
        {
            var url = new StringBuilder(_newsApiOptions.Value.Url)
                .Append($"&q={q}")
                .Append($"&from={from.ToString("yyyy-MM-dd")}")
                .Append($"&to={to.ToString("yyyy-MM-dd")}")
                .ToString();
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            //TO DO : Handle exceptions 500 = Server error, 404 data not found if the content is empty
            var newsResponse = JsonConvert.DeserializeObject<NewsResponseDTO>(content);
            //TO DO : What if the response is null
            return newsResponse.Articles;
        }

        public async Task UpdateNewsAsync()
        {
            var articles = await FetchLatestNewsAsync();

            foreach (var article in articles)
            {
                var newsArticle = new NewsArticle
                {
                    Title = article.Title,
                    Description = article.Description,
                    Url = article.Url,
                    Source = new Source { 
                    Id = article.Source.Id,
                    Name = article.Source.Name
                    }, 
                    PublishedAt = DateTime.Now
                };

                _context.NewsArticles.Add(newsArticle);
            }

            await _context.SaveChangesAsync();
        }
    }
}
