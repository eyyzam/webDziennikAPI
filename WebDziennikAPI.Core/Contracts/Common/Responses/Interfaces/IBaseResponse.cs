namespace WebDziennikAPI.Core.Contracts.Responses
{
	public interface IBaseResponse<T>
	{
		string Status { get; set; }

		IMeta Meta { get; set; }

		T Data { get; set; }
	}
}
