using WebDziennikAPI.Contracts.Responses.Data;
using WebDziennikAPI.Core.Contracts.Responses;

namespace WebDziennikAPI.Contracts.Responses
{
	public class Accounts_SearchForPlayersByPhraseRes : BaseResponse<SearchForPlayersByPhraseData[]>, IAccounts_SearchForPlayersByPhraseRes { }
}
