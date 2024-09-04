namespace Latest_News_Dashboard.Dto
{
    public class NewsResponseDTO
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public IEnumerable<NewsArticleDTO> Articles { get; set; }
    }
}
