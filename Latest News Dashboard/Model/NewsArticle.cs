namespace Latest_News_Dashboard.Model
{
    public class NewsArticle
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }
        public string  Content { get; set; }
        public int SourceId { get; set; } 
        public DateTime PublishedAt { get; set; }
        public virtual Source Source { get; set; }
    }
}
