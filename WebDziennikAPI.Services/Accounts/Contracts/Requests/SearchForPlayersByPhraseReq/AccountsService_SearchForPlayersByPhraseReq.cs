namespace WebDziennikAPI.Services.Accounts.Contracts.Requests
{
	public class AccountsService_SearchForPlayersByPhraseReq : IAccountsService_SearchForPlayersByPhraseReq
	{
		public string application_id { get; set; }

		public string search { get; set; }

		public string fields { get; set; }

		public string language { get; set; }

		public int limit { get; set; }

		public string type { get; set; }
	}
}
