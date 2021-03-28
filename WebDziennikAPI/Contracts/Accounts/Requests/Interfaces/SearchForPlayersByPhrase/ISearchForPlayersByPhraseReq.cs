namespace WebDziennikAPI.Contracts.Requests
{
	public interface ISearchForPlayersByPhraseReq
	{
		string Search { get; set; }

		string Fields { get; set; }

		string Language { get; set; }

		int Limit { get; set; }

		string Type { get; set; }
	}
}