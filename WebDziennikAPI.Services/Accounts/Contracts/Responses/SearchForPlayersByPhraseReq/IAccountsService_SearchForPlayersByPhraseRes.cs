using WebDziennikAPI.Core.Contracts.Responses;
using WebDziennikAPI.Services.Accounts.Contracts.Responses.Data;

namespace WebDziennikAPI.Services.Accounts.Contracts.Responses
{
	public interface IAccountsService_SearchForPlayersByPhraseRes : IBaseResponse<AccountsService_SearchForPlayersByPhraseData[]>
	{
	}
}
