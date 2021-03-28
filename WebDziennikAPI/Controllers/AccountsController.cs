using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebDziennikAPI.Controllers
{
	[ApiController]
	[Produces("application/json")]
	public class AccountsController : ControllerBase
	{
		[HttpGet]
		[ProducesResponseType((int) HttpStatusCode.InternalServerError)]
		public async Task<ActionResult<>> SearchForPlayersByPhrase()
		{
			return View();
		}
	}
}
