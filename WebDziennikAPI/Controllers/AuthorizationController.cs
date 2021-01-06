using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebDziennikAPI.Core.Models.Authorization;

namespace WebDziennikAPI.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class AuthorizationController : ControllerBase
	{
		private readonly IMapper _mapper;

		public AuthorizationController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpPost]
		public ActionResult<User> Login()
		{
			return new User()
			{
				Username = "XD",
				Role = Core.Models.Authorization.User.Roles.Student
			};
		}
	}
}
