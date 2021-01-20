using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebDziennikAPI.Core.Filters
{
	public class TokenAuthFilter : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
				ContextValidationFailed(context);

			var token = context.HttpContext.Request.Headers.First(x => x.Key == "Authorization").Value;

			// TUTAJ TOKEN SERVICE VERIFY TOKEN COŚ TAKIEGO:
			// if(!_tokenService.VerifyToken(token))
			//	  ContextValidationFailed(context)
		}

		private static void ContextValidationFailed(AuthorizationFilterContext context)
		{
			context.ModelState.AddModelError("Unauthorized", "You are unauthorized!");
			context.Result = new UnauthorizedObjectResult(context.ModelState);
		}
	}
}
