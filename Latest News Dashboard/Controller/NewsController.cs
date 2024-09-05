using Latest_News_Dashboard.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Latest_News_Dashboard.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsAPIService _newsService;
        public NewsController(INewsAPIService newsService)
        {
            _newsService = newsService;
        }
    }
}

