using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSON_Localization.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {

        private readonly IStringLocalizer<DemoController> _loc;
        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger, IStringLocalizer<DemoController>loc)
        {
            _loc = loc;
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation(_loc["hi"]);
            var message = _loc["hi"].ToString();
            return Ok(message);
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            var message = string.Format(_loc["welcome"], name);
            return Ok(message);
        }


        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var message = _loc.GetAllStrings();
            return Ok(message);
        }



    }
}
