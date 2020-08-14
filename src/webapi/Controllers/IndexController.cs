using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{

    [ApiController]
    [Route("/")]
    public class IndexController : ControllerBase
    {

        private readonly ILogger<IndexController> _logger;

        public IndexController(ILogger<IndexController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Index()
        {
            return "Hello World";
        }
    }
}
