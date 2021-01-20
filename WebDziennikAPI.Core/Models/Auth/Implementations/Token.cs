using System;

namespace WebDziennikAPI.Core.Models.Auth.Implementations
{
	public class Token
	{
		public string Value { get; set; }

		public DateTime ExpiryDate { get; set; }
	}
}
