using Microsoft.EntityFrameworkCore;
using WebDziennikAPI.Core.Tables;

namespace WebDziennikAPI.Core.Contexts
{
	public class RolesContext : DbContext
	{
		public DbSet<Roles> Roles { get; set; }

		public RolesContext(DbContextOptions<RolesContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}
