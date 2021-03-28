using WebDziennikAPI.Core.Models.Common.Enums;

namespace WebDziennikAPI.Contracts.Requests
{
	public class Accounts_SearchForPlayersByPhraseReq : IAccounts_SearchForPlayersByPhraseReq
	{
		public string Search { get; set; }

		public string Fields { get; set; }

		public Language Language { get; set; }

		public int Limit { get; set; }

		public SearchType Type { get; set; }
	}
}
