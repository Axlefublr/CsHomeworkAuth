using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
	[ExceptionHandler]
	[ApiController]
	[Route("[controller]")]
	public class UserController : ControllerBase
	{
		private readonly ILogger _logger;
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		public UserController(ILogger logger, IMapper mapper, IUserRepository userRepository)
		{
			_logger = logger;
			_mapper = mapper;
			_userRepository = userRepository;
		}

		[Authorize(Roles = "Administrator")]
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

		[HttpPost]
		[Route("authenticate")]
		public async Task<UserViewModel> Authenticate(string login, string password)
		{
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
			{
				throw new ArgumentNullException("The request is empty. Login is: " + nameof(login) + ". Password is: " + nameof(password));
			}
			User user = _userRepository.GetByLogin(login) ?? throw new AuthenticationException("The user is not found");
			if (user.Password != password)
			{
				throw new AuthenticationException("The password is incorrect");
			}

			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Role.Name)
			};

			ClaimsIdentity claimsIdentity = new(
				claims,
				"AppCookie",
				ClaimsIdentity.DefaultNameClaimType,
				ClaimsIdentity.DefaultRoleClaimType
			);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

			return _mapper.Map<UserViewModel>(user);
		}

	}
}