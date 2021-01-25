using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebDziennikAPI.Core.Contracts.Common.Responses;
using WebDziennikAPI.Core.Filters.Auth;
using WebDziennikAPI.Core.Models.Auth.Implementations;

namespace WebDziennikAPI.Controllers
{
	[ApiController]
	[Produces("application/json")]
	public class AdminController : ControllerBase
	{
		/// <summary>
		///  If valid Authorization token is passed returns User's data from Token payload
		/// </summary>
		/// <returns>User's account information</returns>
		[Route("GetUserByAuthorizationToken")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(typeof(User), (int) HttpStatusCode.OK)]
		[ProducesResponseType(typeof(ErrorMessagerResponse), (int) HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
		public ActionResult<User> GetUserByAuthorizationToken()
		{
			var user = (User) HttpContext.Items["User"];

			if (user != null)
				return user;

			return Unauthorized(new ErrorMessagerResponse() { StatusCode = (int) HttpStatusCode.Unauthorized, Message = "No user found in context" });
		}
	}
}
