using WebDziennikAPI.Core.Models.Auth.Implementations;

namespace WebDziennikAPI.Core.Contracts.Auth.Responses
{
	public class AuthenticateByCredentialsResponse
	{
		public bool AuthenticationStatus { get; set; } = false;

		public User User { get; set; }

		public string Token { get; set; }
	}
}
