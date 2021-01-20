using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebDziennikAPI.Core.Contexts.Auth;
using WebDziennikAPI.Core.Contexts.Auth.Tables;
using WebDziennikAPI.Core.Models.Auth.Interfaces;

namespace WebDziennikAPI.Core.Services.Auth
{
	public class AuthService : IAuthService
	{
		private readonly IMapper _mapper;
		private readonly UsersContext _usersContext;

		public AuthService(IMapper mapper, IConfiguration config)
		{
			_mapper = mapper;

			var configEnumerable = config.AsEnumerable();
			var connectionString = configEnumerable.FirstOrDefault(item => item.Key == "connectionString").Value;

			if (string.IsNullOrWhiteSpace(connectionString)) return;

			var optionsBuilder = new DbContextOptionsBuilder<UsersContext>();
			optionsBuilder.UseSqlServer(connectionString);
			optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
			_usersContext = new UsersContext(optionsBuilder.Options);
		}

		public async Task<List<Users>> GetUsersAsync()
		{
			var users = await _usersContext.Users.ToListAsync();
			return users;
		}
	}
}
