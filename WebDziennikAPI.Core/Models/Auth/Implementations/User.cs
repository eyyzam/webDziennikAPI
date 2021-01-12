using WebDziennikAPI.Core.Models.Auth.Enums;

namespace WebDziennikAPI.Core.Models.Auth.Implementations
{
	public class User
	{
		public int ID { get; set; }

		public string Login { get; set; }

		public string Email { get; set; }

		public Role Role { get; set; }

		public Permissions Permissions { get; set; }
	}
}
