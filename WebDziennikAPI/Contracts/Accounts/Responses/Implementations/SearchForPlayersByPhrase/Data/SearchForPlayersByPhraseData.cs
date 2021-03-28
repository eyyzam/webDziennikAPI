namespace WebDziennikAPI.Contracts.Responses.Data
{
	public class SearchForPlayersByPhraseData : ISearchForPlayersByPhraseData
	{
		public string Nickname { get; set; }

		public long Account_ID { get; set; }
	}
}
