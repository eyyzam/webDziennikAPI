namespace WebDziennikAPI.Contracts.Requests
{
	public class Accounts_SearchForPlayersByPhraseReq : IAccounts_SearchForPlayersByPhraseReq
	{
		public string Search { get; set; }

		public string Fields { get; set; }

		public string Language { get; set; }

		public int Limit { get; set; }

		public string Type { get; set; }
	}
}
