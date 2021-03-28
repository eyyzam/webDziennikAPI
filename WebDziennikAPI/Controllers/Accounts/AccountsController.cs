using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebDziennikAPI.Contracts.Requests;
using WebDziennikAPI.Contracts.Responses;

namespace WebDziennikAPI.Controllers
{
	[ApiController]
	[Produces("application/json")]
	public class AccountsController : ControllerBase
	{
		private readonly IMapper _mapper;

		public AccountsController(IMapper mapper)
		{
			_mapper = mapper;
		}
		
		[HttpGet]
		[Route("SearchForPlayersByPhrase")]
		[ProducesResponseType(typeof(IAccounts_SearchForPlayersByPhraseRes), (int) HttpStatusCode.OK)]
		[ProducesResponseType((int) HttpStatusCode.InternalServerError)]
		public ActionResult<IAccounts_SearchForPlayersByPhraseRes> SearchForPlayersByPhrase(ISearchForPlayersByPhraseReq request)
		{
			var serviceReq = _mapper.Map<IAccounts_SearchForPlayersByPhraseReq>(request);
			var serviceRes = new Accounts_SearchForPlayersByPhraseRes();
			return _mapper.Map<ActionResult<IAccounts_SearchForPlayersByPhraseRes>>(serviceRes);
		}
	}
}
