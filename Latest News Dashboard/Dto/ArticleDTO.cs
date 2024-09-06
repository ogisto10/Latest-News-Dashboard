using Latest_News_Dashboard.Model;
using NewsAPI.Models;

namespace Latest_News_Dashboard.Dto
{
    public class ArticleDto
    {
        public ArticleDto(Article article)
        {
            Title = article.Title;
            Content = article.Content;
            Author = article.Author;
            Description = article.Description;
            Url = article.Url;
            UrlToImage = article.UrlToImage;
            PublishedAt = article.PublishedAt;
            Source = article.Source;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string Content { get; set; } 
        public DateTime? PublishedAt { get; set; }
        public  Source Source { get; set; }
    }

}
