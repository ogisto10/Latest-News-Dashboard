using Latest_News_Dashboard.Model;

namespace Latest_News_Dashboard.Dto
{
    public class NewsArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string Content { get; set; } 
        public DateTime PublishedAt { get; set; }
        public  SourceDTO Source { get; set; }
    }

}
