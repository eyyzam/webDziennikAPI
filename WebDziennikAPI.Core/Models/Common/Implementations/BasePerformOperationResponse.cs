#pragma warning disable CS8632

namespace WebDziennikAPI.Core.Models.Common.Implementations
{
	public class BasePerformOperationResponse
	{
		public bool OperationSucceded { get; set; }

		public string? InternalErrorMessage { get; set; }

		public string? Message { get; set; }
	}
}
