namespace WebDziennikAPI.Core.Contracts.Responses
{
	public class BaseResponse<T> : IBaseResponse<T>
	{
		public string Status { get; set; }

		public Meta Meta { get; set; }

		public T Data { get; set; }
	}
}
