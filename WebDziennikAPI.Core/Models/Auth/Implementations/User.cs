using System.Collections.Generic;
using Newtonsoft.Json;
using WebDziennikAPI.Core.Models.Auth.Enums;

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

		public Role Role { get; set; } = Role.Student;

		public List<Permissions> Permissions { get; set; } = new List<Permissions>();
	}
}
