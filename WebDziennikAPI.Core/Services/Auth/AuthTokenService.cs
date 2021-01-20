using System;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebDziennikAPI.Core.Models.Auth.Implementations;
using WebDziennikAPI.Core.Models.Auth.Interfaces;

namespace WebDziennikAPI.Core.Services.Auth
{
	public class AuthTokenService : IAuthTokenService
	{
		private readonly IConfiguration _config;

		public AuthTokenService(IConfiguration config)
		{
			_config = config;
		}

		public string GenerateJWTToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_config.AsEnumerable().First(item => item.Key == "Auth:Secret").Value);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
				Expires = DateTime.UtcNow.AddDays(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
