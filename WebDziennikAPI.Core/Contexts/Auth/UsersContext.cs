using Microsoft.EntityFrameworkCore;
using WebDziennikAPI.Core.Contexts.Auth.Tables;

namespace WebDziennikAPI.Core.Contexts.Auth
{
	public class UsersContext : DbContext
	{
		public DbSet<Users> Users { get; set; }

		public UsersContext(DbContextOptions<UsersContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}
