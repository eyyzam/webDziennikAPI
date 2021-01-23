using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using WebDziennikAPI.Core.Attributes.Auth;
using WebDziennikAPI.Core.Contracts.Auth.Requests;
using WebDziennikAPI.Core.Contracts.Auth.Responses;
using WebDziennikAPI.Core.Contracts.Common.Responses;
using WebDziennikAPI.Core.Models.Auth.Implementations;
using WebDziennikAPI.Core.Models.Auth.Interfaces;

namespace WebDziennikAPI.Controllers
{
	[ApiController]
	[Produces("application/json")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;

		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		/// <summary>
		///  Method allows to authenticate user by username and password. Returns WD Token
		/// </summary>
		/// <param name="request">Object containing username and password</param>
		/// <returns>WD Token</returns>
		[Route("AuthenticateByCredentials")]
		[HttpPost]
		[ProducesResponseType(typeof(AuthenticateResponse), (int) HttpStatusCode.OK)]
		[ProducesResponseType(typeof(ErrorMessagerResponse), (int)HttpStatusCode.BadRequest)]
		[ProducesResponseType(typeof(ErrorMessagerResponse), (int) HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int) HttpStatusCode.InternalServerError)]
		public async Task<ActionResult<AuthenticateResponse>> AuthenticateByCredentials(AuthenticateRequest request)
		{
			if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
				return BadRequest(new ErrorMessagerResponse() { StatusCode = (int) HttpStatusCode.BadRequest, Message = "Invalid request parameters" });

			var authRequest = new AuthenticateByCredentialsRequest() { Username = request.Username, Password = request.Password};
			var response = await _authService.AuthenticateByCredentials(authRequest);

			if (response.AuthenticationStatus) 
				return new AuthenticateResponse() { User = response.User, AuthorizationToken = response.Token };

			return Unauthorized(new ErrorMessagerResponse() { StatusCode = (int) HttpStatusCode.Unauthorized, Message = "Invalid Credentials"});
		}

		/// <summary>
		///  Method allows user to logout. If successful returns message
		/// </summary>
		/// <returns>Status Message</returns>
		[Route("Logout")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(typeof(LogoutResponse), (int) HttpStatusCode.OK)]
		[ProducesResponseType(typeof(ErrorMessagerResponse), (int) HttpStatusCode.Unauthorized)]
		[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
		public ActionResult<LogoutResponse> Logout()
		{
			var user = (User) HttpContext.Items["User"];

			if (user != null && HttpContext.Items.Remove(user))
				return new LogoutResponse() { Message = "Logout was successful" };

			return Unauthorized(new ErrorMessagerResponse() { StatusCode = (int)HttpStatusCode.Unauthorized, Message = "Invalid Credentials" });
		}
	}
}
