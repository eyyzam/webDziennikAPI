using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebDziennikAPI.Core.Models.Auth.Interfaces;
using WebDziennikAPI.Core.Models.Auth.Interfaces.Common;

namespace WebDziennikAPI.Core.Middlewares.Auth
{
	public class JWTMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IConfiguration _config;
		private readonly IUsersService _userService;

		public JWTMiddleware(RequestDelegate next, IConfiguration config, IUsersService usersService)
		{
			_next = next;
			_config = config;
			_userService = usersService;
		}

		public async Task Invoke(HttpContext context, IAuthService authService)
		{
			var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

			if (token != null)
				AttachUserToContext(context, token);

			await _next(context);
		}

		private void AttachUserToContext(HttpContext context, string token)
		{
			try
			{
				var tokenHandler = new JwtSecurityTokenHandler();
				var key = Encoding.ASCII.GetBytes(_config.AsEnumerable().First(item => item.Key == "Auth:Secret")
					.Value);

				tokenHandler.ValidateToken(token, new TokenValidationParameters()
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					ClockSkew = TimeSpan.Zero
				}, out var validatedToken);

				var jwtToken = (JwtSecurityToken) validatedToken;
				var userID = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

				context.Items["User"] = _userService.GetUserByID(userID);
			}
			catch
			{
				// Nothing happens when JWT Validation Fails
				// User will not get attached to context so he's unable to access secure routes
			}
		}
	}
}
