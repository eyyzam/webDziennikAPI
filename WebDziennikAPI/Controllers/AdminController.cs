using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using WebDziennikAPI.Core.Contracts.Admin.Requests;
using WebDziennikAPI.Core.Contracts.Admin.Responses;
using WebDziennikAPI.Core.Contracts.Common.Responses;
using WebDziennikAPI.Core.Filters.Auth;
using WebDziennikAPI.Core.Models.Auth.Implementations;
using WebDziennikAPI.Core.Models.Common.Interfaces;

namespace WebDziennikAPI.Controllers
{
	[ApiController]
	[Produces("application/json")]
	[ProducesResponseType(typeof(ErrorMessagerResponse), (int)HttpStatusCode.Unauthorized)]
	[ProducesResponseType(typeof(ObjectResult), (int)HttpStatusCode.InternalServerError)]
	public class AdminController : ControllerBase
	{
		private readonly IAdminService _adminService;

		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		/// <summary>
		///  If valid Authorization token is passed returns User's data from Token payload
		/// </summary>
		/// <returns>User's account information</returns>
		[Route("GetUserByAuthorizationToken")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(typeof(User), (int) HttpStatusCode.OK)]
		public ActionResult<User> GetUserByAuthorizationToken()
		{
			var user = (User) HttpContext.Items["User"];

			if (user != null)
				return user;

			return Problem(statusCode: (int) HttpStatusCode.InternalServerError, title: "No user found in context");
		}

		[Route("GetRoles")]
		[HttpGet]
		[Authorize]
		[ProducesResponseType(typeof(GetRolesResponse), (int) HttpStatusCode.OK)]
		public async Task<ActionResult<GetRolesResponse>> GetRoles()
		{
			var response = await _adminService.GetRoles();

			if (response.OperationSucceded)
				return response;

			return Problem(statusCode: (int) HttpStatusCode.InternalServerError, title: "Operation failed");
		}

		[Route("EditRole/{id}")]
		[HttpPost]
		[Authorize]
		[ProducesResponseType(typeof(EditRoleResponse), (int) HttpStatusCode.OK)]
		public async Task<ActionResult<EditRoleResponse>> EditRole(int id, EditRoleRequest request)
		{
			var response = await _adminService.EditRole(id, request.Role);

			if (response.OperationSucceded)
				return response;

			return Problem(statusCode: (int) HttpStatusCode.InternalServerError, title: "Operation failed");
		}

		[Route("DeleteRole/{id}")]
		[HttpDelete]
		[Authorize]
		[ProducesResponseType(typeof(DeleteRoleResponse), (int) HttpStatusCode.OK)]
		public async Task<ActionResult<DeleteRoleResponse>> DeleteRole(int id)
		{
			var response = await _adminService.DeleteRole(id);

			if (response.OperationSucceded)
				return response;

			return Problem(statusCode: (int) HttpStatusCode.InternalServerError, title: "Operation failed");
		}
	}
}
