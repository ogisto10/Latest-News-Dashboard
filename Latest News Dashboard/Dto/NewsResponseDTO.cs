namespace Latest_News_Dashboard.Dto
{
    public class NewsResponseDTO
    {
        public int PageSize { get; set; } = 50;
        public int PageNumber { get; set; }
        public int Total { get; set; }
        public IEnumerable<ArticleDto> Articles { get; set; } = new List<ArticleDto>();
    }
}
