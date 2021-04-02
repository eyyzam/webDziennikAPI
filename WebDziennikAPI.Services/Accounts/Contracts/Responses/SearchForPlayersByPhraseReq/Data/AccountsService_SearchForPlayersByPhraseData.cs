namespace WebDziennikAPI.Services.Accounts.Contracts.Responses.Data
{
	public class AccountsService_SearchForPlayersByPhraseData : IAccountsService_SearchForPlayersByPhraseData
	{
		public string Nickname { get; set; }

		public long Account_ID { get; set; }
	}
}
