using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using WebDziennikAPI.Config.Configs;
using WebDziennikAPI.Config.Models;

namespace WebDziennikAPI.Config.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static IServiceCollection AddDefaultConfiguration<T>(this IServiceCollection services, DefaultConfigurationModel configuration)
		{
			if (configuration.AutoMapperEnabled)
			{

			}

			if (configuration.LogsEnabled)
			{

			}

			if (configuration.SwaggerEnabled)
			{

			}

			if (configuration.UseAPIConfiguration)
				services.AddAPIConfiguration();

			if (configuration.UseSwaggerFullSchemaNames)
			{

			}

			return services;
		}
		
		public static IServiceCollection AddAPIConfiguration(this IServiceCollection services)
		{
			var environment = services.BuildServiceProvider().GetRequiredService<IHostingEnvironment>();
			var configuration = new ConfigurationBuilder().AddDefaultConfiguration(environment).Build();

			services.AddSingleton<IConfiguration>(configuration);
			services.Configure<BaseConfiguration>(configuration);
			return services;
		}

		public static IServiceCollection AddEntityFrameworkCollection<T>(
			this IServiceCollection services, QueryTrackingBehavior queryTrackingBehavior,
			Action<DbContextOptionsBuilder> dbContextOptions = null) where T : DbContext
		{
			var connectionString = services.BuildServiceProvider().GetService<IOptions<BaseConfiguration>>()?.Value.ConnectionString;

			services.AddDbContext<T>(options =>
			{
				options.UseSqlServer(connectionString ?? string.Empty);
				options.UseQueryTrackingBehavior(queryTrackingBehavior);
				dbContextOptions?.Invoke(options);
			});
			return services;
		}
	}
}
