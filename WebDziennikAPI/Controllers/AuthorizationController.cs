using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebDziennikAPI.Core.Contexts.Auth.Tables;
using WebDziennikAPI.Core.Services.Auth;

namespace WebDziennikAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IAuthService _authService;

		public AuthorizationController(IMapper mapper, IAuthService authService)
		{
			_mapper = mapper;
			_authService = authService;
		}

		[Route("Login")]
		[Produces("application/json")]
		[HttpPost]
		public async Task<ActionResult<List<Users>>> Login()
		{
			var response = await _authService.GetUsersAsync();
			return response.Where(x => x.Login == "eazymen").ToList();
		}
	}
}
