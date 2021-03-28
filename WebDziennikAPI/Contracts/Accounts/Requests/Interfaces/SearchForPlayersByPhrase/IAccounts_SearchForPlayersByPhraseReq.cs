using WebDziennikAPI.Core.Models.Common.Enums;

namespace WebDziennikAPI.Contracts.Requests
{
	public interface IAccounts_SearchForPlayersByPhraseReq
	{
		string Search { get; set; }

		string Fields { get; set; }

		Language Language { get; set; }

		int Limit { get; set; }

		SearchType Type { get; set; }
	}
}
