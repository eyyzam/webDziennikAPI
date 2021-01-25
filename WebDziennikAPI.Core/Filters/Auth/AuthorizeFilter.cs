using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebDziennikAPI.Core.Contracts.Common.Responses;
using WebDziennikAPI.Core.Models.Auth.Interfaces.Common;

namespace WebDziennikAPI.Core.Filters.Auth
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class Authorize : TypeFilterAttribute
	{
		public Authorize() : base(typeof(AuthorizationFilter)) { }

		private class AuthorizationFilter : IActionFilter
		{
			private readonly IConfiguration _config;
			private readonly IUsersService _userService;
			private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

			public AuthorizationFilter(IConfiguration config, IUsersService usersService, JwtSecurityTokenHandler jwtSecurityTokenHandler)
			{
				_config = config;
				_userService = usersService;
				_jwtSecurityTokenHandler = jwtSecurityTokenHandler;
			}

			public void OnActionExecuting(ActionExecutingContext context)
			{
				var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

				if (token == null || !VerifyToken(context.HttpContext, token))
					context.Result = new JsonResult(new ErrorMessagerResponse()
					{
						StatusCode = (int)HttpStatusCode.Unauthorized,
						Message = "Unauthorized - Invalid Authorization Token"
					});
			}

			public void OnActionExecuted(ActionExecutedContext context) { }

			private bool VerifyToken(HttpContext context, string token)
			{
				var key = Encoding.ASCII.GetBytes(_config.AsEnumerable().First(item => item.Key == "Auth:Secret").Value);

				var validationParameters = new TokenValidationParameters()
				{
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ClockSkew = TimeSpan.Zero
				};

				try
				{
					_jwtSecurityTokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
					AttachUserToContext(context, validatedToken);
					return true;
				}
				catch (Exception)
				{
					return false;
				}
			}

			private void AttachUserToContext(HttpContext context, SecurityToken validatedToken)
			{
				var jwtToken = (JwtSecurityToken)validatedToken;
				var userID = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

				context.Items["User"] = _userService.GetUserByID(userID);
			}
		}
	}
}
