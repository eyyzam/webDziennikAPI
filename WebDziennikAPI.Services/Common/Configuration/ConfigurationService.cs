using Microsoft.Extensions.Configuration;
using System.Linq;

namespace WebDziennikAPI.Services.Common.Configuration
{
	public class ConfigurationService : IConfigurationService
	{
		private readonly IConfiguration _config;

		public ConfigurationService(IConfiguration config)
		{
			_config = config;
		}

		public string GetApplicationID()
		{
			var appID = _config.AsEnumerable().FirstOrDefault(item => item.Key == "ApplicationID").Value;
			return appID;
		}
	}
}
