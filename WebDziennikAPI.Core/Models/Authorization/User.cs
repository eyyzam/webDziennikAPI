namespace WebDziennikAPI.Core.Models.Authorization
{
	public class User
	{
		public enum Roles
		{
			Student,
			Teacher,
			Director
		}

		public string Username { get; set; }

		public Roles Role { get; set; }
	}
}
