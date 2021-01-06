using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebDziennikAPI.Config.Extensions;
using WebDziennikAPI.Config.Models;

namespace WebDziennikAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDefaultConfiguration<Startup>(new DefaultConfigurationModel()
			{
				AutoMapperEnabled = true,
				UseAPIConfiguration = true,
				SwaggerEnabled = true,
				DefaultCorsPolicy = true,
				LogsEnabled = true
			});

			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.AddDefaultConfiguration();
		}
	}
}
