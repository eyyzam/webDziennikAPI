using Microsoft.EntityFrameworkCore;
using WebDziennikAPI.Core.Tables;

namespace WebDziennikAPI.Core.Contexts
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
