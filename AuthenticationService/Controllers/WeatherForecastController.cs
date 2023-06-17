using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
	[ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
			Logger logger = new();
            logger.WriteEvent("Event message");
            logger.WriteError("Error message");
		}
    }
}
