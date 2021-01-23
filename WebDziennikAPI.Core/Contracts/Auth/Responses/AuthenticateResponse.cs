using WebDziennikAPI.Core.Models.Auth.Implementations;

namespace WebDziennikAPI.Core.Contracts.Auth.Responses
{
	public class AuthenticateResponse
	{
		public User User { get; set; }

		public string AuthorizationToken { get; set; }
	}
}
