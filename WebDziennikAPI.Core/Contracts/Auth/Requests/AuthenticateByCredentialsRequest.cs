using System.ComponentModel.DataAnnotations;

namespace WebDziennikAPI.Core.Contracts.Auth.Requests
{
	public class AuthenticateByCredentialsRequest
	{
		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
