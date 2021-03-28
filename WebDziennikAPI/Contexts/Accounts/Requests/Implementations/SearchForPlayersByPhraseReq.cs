using WebDziennikAPI.Core.Models.Common.Enums;

namespace WebDziennikAPI.Contexts.Accounts.Requests
{
	public class SearchForPlayersByPhraseReq : ISearchForPlayersByPhraseReq
	{
		public string Search { get; set; }

		public string Fields { get; set; }

		public Language Language { get; set; }

		public int Limit { get; set; }

		public SearchType Type { get; set; }
	}
}
