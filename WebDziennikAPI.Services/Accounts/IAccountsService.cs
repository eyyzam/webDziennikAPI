using System.Threading.Tasks;
using WebDziennikAPI.Services.Accounts.Contracts.Requests;
using WebDziennikAPI.Services.Accounts.Contracts.Responses;

namespace WebDziennikAPI.Services.Accounts
{
	public interface IAccountsService
	{
		Task<IAccountsService_SearchForPlayersByPhraseRes> SearchForPlayersByPhraseReq(IAccountsService_SearchForPlayersByPhraseReq request);
	}
}
