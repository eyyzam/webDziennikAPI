using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using WebDziennikAPI.Contracts.Requests;
using WebDziennikAPI.Contracts.Responses;
using WebDziennikAPI.Services.Accounts;
using WebDziennikAPI.Services.Accounts.Contracts.Requests;

namespace WebDziennikAPI.Controllers
{
	[ApiController]
	[Produces("application/json")]
	public class AccountsController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IAccountsService _accountsService;

		public AccountsController(IMapper mapper, IAccountsService accountsService)
		{
			_mapper = mapper;
			_accountsService = accountsService;
		}
		
		[HttpPost]
		[Route("SearchForPlayersByPhrase")]
		[ProducesResponseType(typeof(IAccounts_SearchForPlayersByPhraseRes), (int) HttpStatusCode.OK)]
		[ProducesResponseType((int) HttpStatusCode.InternalServerError)]
		public async Task<IAccounts_SearchForPlayersByPhraseRes> SearchForPlayersByPhrase(Accounts_SearchForPlayersByPhraseReq request)
		{
			var serviceReq = _mapper.Map<IAccountsService_SearchForPlayersByPhraseReq>(request);
			var serviceRes = await _accountsService.SearchForPlayersByPhraseReq(serviceReq);
			return _mapper.Map<IAccounts_SearchForPlayersByPhraseRes>(serviceRes);
		}
	}
}
