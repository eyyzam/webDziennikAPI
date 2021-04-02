using System.Linq;
using System.Web;

namespace WebDziennikAPI.Core.Extensions
{
	public class UrlExtensions
	{
		public string BuildUrlQueryParams<T>(T request)
		{
			if (request is null)
				return string.Empty;

			var urlParamsDictionary = request
				.GetType()
				.GetProperties()
				.ToDictionary(prop => prop.Name, prop => prop.GetValue(request, null)?.ToString());

			var urlParams = string.Join("&", urlParamsDictionary.Where(p => !string.IsNullOrEmpty(p.Value) && p.Value != "0").Select(param => $"{param.Key}={param.Value}"));
			return string.IsNullOrEmpty(urlParams) ? string.Empty : $"?{urlParams}";
		}
	}
}
