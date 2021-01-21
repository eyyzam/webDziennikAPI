using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebDziennikAPI.Core.Contexts.Auth;
using WebDziennikAPI.Core.Contexts.Auth.Tables;
using WebDziennikAPI.Core.Models.Auth.Implementations;
using WebDziennikAPI.Core.Models.Auth.Interfaces.Common;

namespace WebDziennikAPI.Core.Services.Common
{
	public class UsersService : IUsersService
	{
		private readonly IMapper _mapper;
		private readonly UsersContext _usersContext;

		public UsersService(IMapper mapper, IConfiguration config)
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

		public async Task<User> GetUserByID(int userID)
		{
			return _mapper.Map<Users, User>(await _usersContext.Users.SingleOrDefaultAsync(x => x.Id == userID));
		}

		public async Task<User> GetUserByUsernameAndPassword(string username, string password)
		{
			return _mapper.Map<Users, User>(await _usersContext.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password));
		}
	}
}
