using WebDziennikAPI.Core.Contracts.Responses;
using WebDziennikAPI.Services.Accounts.Contracts.Responses.Data;

namespace WebDziennikAPI.Services.Accounts.Contracts.Responses
{
	public class AccountsService_SearchForPlayersByPhraseRes
		: BaseResponse<AccountsService_SearchForPlayersByPhraseData[]>
		, IAccountsService_SearchForPlayersByPhraseRes
	{

	}
}
