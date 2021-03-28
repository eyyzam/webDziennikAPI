using WebDziennikAPI.Core.Models.Common.Enums;

namespace WebDziennikAPI.Contexts.Accounts.Requests
{
	public interface ISearchForPlayersByPhraseReq
	{
		string Search { get; set; }

		string Fields { get; set; }

		Language Language { get; set; }

		int Limit { get; set; }

		SearchType Type { get; set; }
	}
}
