using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebDziennikAPI.Core.Contexts.Auth.Tables;
using WebDziennikAPI.Core.Contracts.Auth.Requests;
using WebDziennikAPI.Core.Contracts.Auth.Responses;
using WebDziennikAPI.Core.Models.Auth.Interfaces;
using WebDziennikAPI.Core.Services.Auth;

namespace WebDziennikAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IAuthService _authService;

		public AuthController(IMapper mapper, IAuthService authService)
		{
			_mapper = mapper;
			_authService = authService;
		}

		[Route("Login")]
		[Produces("application/json")]
		[HttpPost]
		public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
		{
			var response = await _authService.GetUsersAsync();

			if (response.Any()) return new LoginResponse() {AuthorizationToken = "XD"};

			ModelState.AddModelError("Unauthorized", "You are unauthorized");
			return Unauthorized(ModelState);
		}
 	}
}
