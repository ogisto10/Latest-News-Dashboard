using Latest_News_Dashboard.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Latest_News_Dashboard.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet("GetLatestNews")]
        public async Task<IActionResult> GetLatestNews(string q, DateTime from, DateTime to)
        {
            var news = await _newsService.FetchLatestNewsAsync(q,from,to);
            return Ok(news);
        }

        [HttpPost("UpdateNews")]
        public async Task<IActionResult> UpdateNews()
        {
            await _newsService.UpdateNewsAsync();
            return NoContent();
        }
    }
}

