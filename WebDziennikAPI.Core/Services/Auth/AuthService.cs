using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDziennikAPI.Core.Contexts.Auth;
using WebDziennikAPI.Core.Contexts.Auth.Tables;
using WebDziennikAPI.Core.Contracts.Auth.Requests;
using WebDziennikAPI.Core.Contracts.Auth.Responses;
using WebDziennikAPI.Core.Models.Auth.Interfaces;
using WebDziennikAPI.Core.Models.Auth.Interfaces.Common;

namespace WebDziennikAPI.Core.Services.Auth
{
	public class AuthService : IAuthService
	{
		private readonly IMapper _mapper;
		private readonly UsersContext _usersContext;
		private readonly IAuthTokenService _authTokenService;
		private readonly IUsersService _usersService;

		public AuthService(IMapper mapper, IConfiguration config, IAuthTokenService authTokenService, IUsersService usersService)
		{
			_mapper = mapper;
			_authTokenService = authTokenService;
			_usersService = usersService;

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

		public async Task<AuthenticateByCredentialsResponse> AuthenticateByCredentials(AuthenticateByCredentialsRequest request)
		{
			var response = new AuthenticateByCredentialsResponse();
			var user = await _usersService.GetUserByUsernameAndPasswordAsync(request.Username, request.Password);

			if (user == null)
			{
				response.AuthenticationStatus = false;
				return response;
			}

			var token = _authTokenService.GenerateJWTToken(user);
				
			return new AuthenticateByCredentialsResponse()
			{
				User = user,
				Token = token,
				AuthenticationStatus = true
			};
		}
	}
}
