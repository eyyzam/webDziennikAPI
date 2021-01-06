using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace WebDziennikAPI.Config.Extensions
{
	public static class ConfigurationBuilderExtension
	{
		public static IConfigurationBuilder AddDefaultConfiguration(this IConfigurationBuilder configuration, IWebHostEnvironment environment)
		{
			string configurationFileName;

			if (environment == null || environment.IsDevelopment())
				configurationFileName = "config.dev.json";

			else if (environment.IsStaging())
				configurationFileName = "config.stage.json";

			else if (environment.IsProduction())
				configurationFileName = "config.prod.json";

			else
				configurationFileName = "config.dev.json";

			return configuration.AddJsonFile(new ManifestEmbeddedFileProvider(Assembly.GetExecutingAssembly()), "config.default.json", false, true)
				.AddJsonFile("config.json", true, true)
				.AddJsonFile(configurationFileName, true, true);
		}
	}
}
