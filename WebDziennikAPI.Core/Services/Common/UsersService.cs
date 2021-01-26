using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using WebDziennikAPI.Core.Contexts;
using WebDziennikAPI.Core.Models.Auth.Implementations;
using WebDziennikAPI.Core.Models.Auth.Interfaces.Common;
using WebDziennikAPI.Core.Tables;

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

		public User GetUserByID(int userID)
		{
			return _mapper.Map<Users, User>(_usersContext.Users.SingleOrDefault(x => x.Id == userID));
		}

		public async Task<User> GetUserByIDAsync(int userID)
		{
			return _mapper.Map<Users, User>(await _usersContext.Users.SingleOrDefaultAsync(x => x.Id == userID));
		}

		public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
		{
			return _mapper.Map<Users, User>(await _usersContext.Users.SingleOrDefaultAsync(x => x.Username == username && x.Password == password));
		}
	}
}
