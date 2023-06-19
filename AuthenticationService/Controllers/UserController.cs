using System;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private ILogger _logger;
		public UserController(ILogger logger)
		{
			_logger = logger;
			logger.WriteEvent("Event message");
			logger.WriteError("Error message");
		}

		[HttpGet]
		public User GetUser()
		{
			return new User()
			{
				Id = Guid.NewGuid(),
				FirstName = "Ivan",
				LastName = "Ivanov",
				Email = "ivan@gmail.com",
				Password = "1234444432",
				Login = "ivanov"
			};
		}
	}
}