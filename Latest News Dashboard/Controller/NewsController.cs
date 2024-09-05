using Latest_News_Dashboard.Dto;
using Latest_News_Dashboard.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;

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
        [HttpGet("paged-articles")]
        public async Task<ActionResult<NewsResponseDTO>> GetPagedArticles([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            
            var pagedArticles = await _newsService.GetPagedArticlesAsync(pageNumber, pageSize);

            return Ok(pagedArticles);
        }
        [HttpGet("search-articles")]
        public async Task<ActionResult<NewsResponseDTO>> SearchArticles([FromQuery] int pageNumber = 1,[FromQuery] int pageSize = 50,[FromQuery] string? searchQuery = null)
        {
            var searchResult = await _newsService.SearchArticlesAsync(pageNumber, pageSize, searchQuery);
            return Ok(searchResult);
        }
        [HttpGet("filter-articles")]
        public async Task<ActionResult<NewsResponseDTO>> FilterArticles([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50, [FromQuery] string? sourceName = null)
        {
            var searchResult = await _newsService.FilterArticlesAsync(pageNumber, pageSize, sourceName);
            return Ok(searchResult);
        }
        [HttpGet("sources")]
        public async Task<ActionResult<List<Source>>> GetAllSources()
        {
            var sources = await _newsService.GetAllSourcesAsync();
            return Ok(sources);
        }
    }

}

