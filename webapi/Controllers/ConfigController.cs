using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{

    [ApiController]
    [Route("config")]
    public class ConfigController : ControllerBase {

        private readonly ILogger<ConfigController> _logger;

        public ConfigController(ILogger<ConfigController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public object GetInfo()
        {
            return new { 
                AppEnvironment = GetEnvironmentVariable("APPENVIRONMENT"), 
                AppHost = GetEnvironmentVariable("APPHOST")
            };
        }

        private string GetEnvironmentVariable(string name)
        {
            _logger.LogInformation($"Getting environment variable '{name}'.");
            return Environment.GetEnvironmentVariable(name.ToLower()) ?? Environment.GetEnvironmentVariable(name.ToUpper());
        }

    }
}
