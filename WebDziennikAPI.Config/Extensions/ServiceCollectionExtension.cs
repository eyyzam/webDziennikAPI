using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using WebDziennikAPI.Config.Configs;
using WebDziennikAPI.Config.Filters;
using WebDziennikAPI.Config.Models;

namespace WebDziennikAPI.Config.Extensions
{
	public static class ServiceCollectionExtension
	{
		public static bool UsingSwagger { get; private set; }
		public static bool UsingDefaultCorsPolicy { get; private set; }
		public static string NameOfCorsPolicy { get; private set; }

		public static IServiceCollection AddDefaultConfiguration<T>(this IServiceCollection services, DefaultConfigurationModel configuration)
		{
			if (configuration.AutoMapperEnabled)
			{
				var assemblies = new List<Assembly>(AutoMapperExtension.GetAssemblies());
				assemblies.Insert(0, typeof(T).Assembly);

				services.AddAutoMapper(assemblies);
			}

			if (configuration.UseAPIConfiguration)
				services.AddAPIConfiguration();

			if (configuration.SwaggerEnabled)
				services.AddSwagger();

			if (configuration.DefaultCorsPolicy)
				services.AddDefaultCorsPolicy();

			if (configuration.LogsEnabled)
			{

			}

			return services;
		}
		
		public static IServiceCollection AddAPIConfiguration(this IServiceCollection services)
		{
			var environment = services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();
			var configuration = new ConfigurationBuilder().AddDefaultConfiguration(environment).Build();

			services.AddSingleton<IConfiguration>(configuration);
			services.Configure<BaseConfiguration>(configuration);
			return services;
		}

		public static IServiceCollection AddSwagger(this IServiceCollection services)
		{
			UsingSwagger = true;
			
			services.AddSwaggerGen(config =>
			{
				config.SwaggerDoc("WebDziennikAPI", new OpenApiInfo { Title = "WebDziennikAPI", Version = "v1" });
				config.DocumentFilter<RemoveSchemasFilter>();
			});
			return services;
		}

		public static IServiceCollection AddDefaultCorsPolicy(this IServiceCollection services, string nameOfPolicy = "DefaultPolicy")
		{
			UsingDefaultCorsPolicy = true;
			NameOfCorsPolicy = nameOfPolicy;

			services.AddCors(obj => obj.AddPolicy(nameOfPolicy, builder =>
			{
				builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetPreflightMaxAge(TimeSpan.FromSeconds(2700));
			}));
			return services;
		}

		public static IServiceCollection AddEntityFrameworkConnection<T>(
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
