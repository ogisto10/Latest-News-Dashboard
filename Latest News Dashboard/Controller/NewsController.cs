using Latest_News_Dashboard.Dto;
using Latest_News_Dashboard.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Latest_News_Dashboard.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMyNewsService _newsService;
        public NewsController(IMyNewsService newsService)
        {
            _newsService = newsService;
        }
        [HttpGet]
        [Route("paged-articles")]
        public async Task<ActionResult<NewsResponseDTO>> GetPagedArticles([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            
            var pagedArticles = await _newsService.GetPagedArticlesAsync(pageNumber, pageSize);

            return Ok(pagedArticles);
        }
    }
}

