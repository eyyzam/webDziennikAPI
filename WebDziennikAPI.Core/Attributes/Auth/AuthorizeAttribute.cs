using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebDziennikAPI.Core.Models.Auth.Implementations;

namespace WebDziennikAPI.Core.Attributes.Auth
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class AuthorizeAttribute : Attribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var user = (User) context.HttpContext.Items["User"];

			if (user == null)
				context.Result = new JsonResult(new { Message = "You are unauthorized!" }) { StatusCode = StatusCodes.Status401Unauthorized };
		}
	}
}
