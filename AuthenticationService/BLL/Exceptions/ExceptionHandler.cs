using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthenticationService.BLL.Exceptions
{
	public class ExceptionHandler : ActionFilterAttribute, IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			string message = "An error occured.";
			if (context.Exception is CustomException) {
				message = context.Exception.Message;
			}
			context.Result = new BadRequestObjectResult(message);
		}
	}
}