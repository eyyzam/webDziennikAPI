using WebDziennikAPI.Core.Models.Common.Enums;

namespace WebDziennikAPI.Services.Accounts.Contracts.Requests
{
	public interface IAccountsService_SearchForPlayersByPhraseReq
	{
		string application_id { get; set; }

		string search { get; set; }

		string fields { get; set; }

		string language { get; set; }

		int limit { get; set; }

		string type { get; set; }
	}
}
