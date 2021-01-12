using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDziennikAPI.Core.Contexts.Auth.Tables
{
	[Table("Users")]
	public class Users
	{
		[Key]
		[Column("ID")]
		public int ID { get; set; }

		[Column("Login")]
		[StringLength(30)]
		public string Login { get; set; }

		[Column("Password")]
		[StringLength(100)]
		public string Password { get; set; }

		[Column("Email")]
		[EmailAddress]
		[StringLength(100)]
		public string Email { get; set; }
	}
}
