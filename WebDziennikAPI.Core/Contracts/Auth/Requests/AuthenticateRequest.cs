namespace WebDziennikAPI.Core.Contracts.Auth.Requests
{
	public class AuthenticateRequest
	{
		public string Username { get; set; }

		public string Password { get; set; }
	}
}
