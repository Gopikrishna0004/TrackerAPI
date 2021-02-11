using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
namespace TrackerAPI.Controllers.Default_Management
{
    [ApiController]
    [Route("[controller]")]
    public class Default_Controller : ControllerBase
    {
        private readonly ILogger<Default_Controller> _logger;
        public Default_Controller(ILogger<Default_Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
			try
			{
                string Welcome_Msg = "WELCOME TO TRACKER API...!USE SWAGGER TO SEE ALL API CALLINGS";

                return Ok(Welcome_Msg);
            }
			catch (Exception EX)
			{
                Log.Error("Error DefalutController -> Get Method Error Details: {0}", EX);
				throw EX;
			}
           
        }
    }
}
