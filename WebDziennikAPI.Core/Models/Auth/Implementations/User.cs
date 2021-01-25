using Newtonsoft.Json;

namespace WebDziennikAPI.Core.Models.Auth.Implementations
{
	public class User
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Surname { get; set; }

		public string Username { get; set; }

		[JsonIgnore]
		public string Password { get; set; }

		public string Email { get; set; }

		public string Role { get; set; }
	}
}
