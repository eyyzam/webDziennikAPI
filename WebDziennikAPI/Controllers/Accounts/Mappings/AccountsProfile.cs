using AutoMapper;
using WebDziennikAPI.Contracts.Requests;
using WebDziennikAPI.Contracts.Responses;
using WebDziennikAPI.Contracts.Responses.Data;
using WebDziennikAPI.Services.Accounts.Contracts.Requests;
using WebDziennikAPI.Services.Accounts.Contracts.Responses;
using WebDziennikAPI.Services.Accounts.Contracts.Responses.Data;

namespace WebDziennikAPI.Controllers.Mappings
{
	public class AccountsProfile : Profile
	{
		public AccountsProfile()
		{
			CreateMap<ISearchForPlayersByPhraseReq, IAccounts_SearchForPlayersByPhraseReq>();
			CreateMap<IAccounts_SearchForPlayersByPhraseReq, IAccountsService_SearchForPlayersByPhraseReq>();
			CreateMap<AccountsService_SearchForPlayersByPhraseData, SearchForPlayersByPhraseData>();
			CreateMap<IAccountsService_SearchForPlayersByPhraseRes, IAccounts_SearchForPlayersByPhraseRes>();
		}
	}
}
