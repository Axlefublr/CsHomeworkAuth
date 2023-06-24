using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AuthenticationService.BLL.Middlewares
{
	public class LogMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly ILogger _logger;

		public LogMiddleware(RequestDelegate next, ILogger logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			_logger.WriteEvent($"Your ip address is: {httpContext.Connection.LocalIpAddress}");
			await _next(httpContext);
		}
	}
}