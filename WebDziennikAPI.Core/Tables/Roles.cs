using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDziennikAPI.Core.Tables
{
	[Table("Roles")]
	public class Roles
	{
		[Key]
		[Column("ID")]
		public int Id { get; set; }

		[Column("Name")]
		[StringLength(30)]
		public string Name { get; set; }
	}
}
