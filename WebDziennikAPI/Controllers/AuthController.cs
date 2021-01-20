using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebDziennikAPI.Core.Contracts.Auth.Requests;
using WebDziennikAPI.Core.Contracts.Auth.Responses;
using WebDziennikAPI.Core.Models.Auth.Interfaces;

namespace WebDziennikAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IAuthService _authService;
		private readonly IConfiguration _config;

		public AuthController(IMapper mapper, IAuthService authService, IConfiguration config)
		{
			_mapper = mapper;
			_authService = authService;
			_config = config;
		}

		[Route("Authenticate")]
		[Produces("application/json")]
		[HttpPost]
		public async Task<ActionResult<AuthenticateResponse>> Authenticate(AuthenticateRequest request)
		{
			var authRequest = new AuthenticateByCredentialsRequest() { Username = request.Username, Password = request.Password};
			var response = await _authService.AuthenticateByCredentials(authRequest);

			if (response.AuthenticationStatus) 
				return new AuthenticateResponse() { AuthorizationToken = response.Token };

			return Unauthorized("Invalid Authentication Credentials!");
		}

		[Route("Config")]
		[Produces("application/json")]
		[HttpGet]
		public ActionResult<bool> Config()
		{
			var configEnumerable = _config.AsEnumerable();
			var xd = configEnumerable.FirstOrDefault(item => item.Key == "Auth:Secret").Value;
			return true;
		}
	}
}
