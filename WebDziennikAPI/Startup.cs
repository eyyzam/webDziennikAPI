using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebDziennikAPI.Config.Extensions;
using WebDziennikAPI.Config.Models;
using WebDziennikAPI.Core.Contexts.Auth;
using WebDziennikAPI.Core.Models.Auth.Interfaces;
using WebDziennikAPI.Core.Models.Auth.Interfaces.Common;
using WebDziennikAPI.Core.Services.Auth;
using WebDziennikAPI.Core.Services.Common;

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
				LogsEnabled = true,
				Authentication = true
			});

			ServiceRegistration(services);
			EntityFrameworkDBConnection(services);

			services.AddControllers();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.AddDefaultConfiguration();
			app.RegisterMiddlewares();
		}

		public static void ServiceRegistration(IServiceCollection services)
		{
			services.AddSingleton<IUsersService, UsersService>();
			services.AddScoped<IAuthTokenService, AuthTokenService>();
			services.AddScoped<IAuthService, AuthService>();
		}

		public static void EntityFrameworkDBConnection(IServiceCollection services)
		{
			services.AddEntityFrameworkConnection<UsersContext>(QueryTrackingBehavior.NoTracking);
		}
	}
}
