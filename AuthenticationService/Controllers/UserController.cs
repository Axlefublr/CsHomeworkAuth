using System;
using System.Data.Common;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly ILogger _logger;
		private readonly IMapper _mapper;
		public UserController(ILogger logger, IMapper mapper)
		{
			_logger = logger;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("viewmodel")]
		public UserViewModel GetUserViewModel()
		{
			User user = new()
			{
				Id = Guid.NewGuid(),
				FirstName = "Ivan",
				LastName = "Ivanov",
				Email = "ivan@gmail.com",
				Password = "1234444432",
				Login = "ivanov"
			};
			UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);
			return userViewModel;
		}
	}
}