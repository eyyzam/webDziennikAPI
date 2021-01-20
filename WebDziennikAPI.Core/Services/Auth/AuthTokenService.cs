using System;
using System.Collections.Generic;
using System.Linq;
using WebDziennikAPI.Core.Models.Auth.Implementations;
using WebDziennikAPI.Core.Models.Auth.Interfaces;

namespace WebDziennikAPI.Core.Services.Auth
{
	public class AuthTokenService : IAuthTokenService
	{
		private List<Token> ListOfTokens;

		public AuthTokenService()
		{
			ListOfTokens = new List<Token>();
		}
		
		public Token NewToken()
		{
			var token =  new Token()
			{
				Value = Guid.NewGuid().ToString(),
				ExpiryDate = DateTime.Now.AddDays(1)
			};

			ListOfTokens.Add(token);
			return token;
		}

		public bool VerifyToken(string token)
		{
			return ListOfTokens.Any(x => x.Value == token && x.ExpiryDate > DateTime.Now);
		}
	}
}
