namespace WebDziennikAPI.Contracts.Responses.Data
{
	public interface ISearchForPlayersByPhraseData
	{ 
		string Nickname { get; set; }

		long Account_ID { get; set; }
	}
}
