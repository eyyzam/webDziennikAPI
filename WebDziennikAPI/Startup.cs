using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;
using WebDziennikAPI.Config.Extensions;
using WebDziennikAPI.Extensions;
using WebDziennikAPI.Models;
using WebDziennikAPI.Core.Contexts;
using WebDziennikAPI.Core.Models.Auth.Interfaces;
using WebDziennikAPI.Core.Models.Auth.Interfaces.Common;
using WebDziennikAPI.Core.Services.Auth;
using WebDziennikAPI.Core.Services.Common;
using WebDziennikAPI.Services.Accounts;
using WebDziennikAPI.Services.Common.Configuration;

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
			ServiceRegistration(services);
			EntityFrameworkDBConnection(services);
			HttpClientsRegistration(services);

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
			services.AddControllers();

			services.AddDefaultConfiguration<Startup>(new DefaultConfigurationModel()
			{
				AutoMapperEnabled = true,
				UseAPIConfiguration = true,
				SwaggerEnabled = true,
				DefaultCorsPolicy = true,
				LogsEnabled = true
			});
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
		}

		public static void ServiceRegistration(IServiceCollection services)
		{
			services.AddScoped<JwtSecurityTokenHandler>();
			services.AddSingleton<IUsersService, UsersService>();
			services.AddScoped<IAuthTokenService, AuthTokenService>();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IConfigurationService, ConfigurationService>();
			services.AddScoped<IAccountsService, AccountsService>();
		}

		public static void EntityFrameworkDBConnection(IServiceCollection services)
		{
			services.AddEntityFrameworkConnection<RolesContext>(QueryTrackingBehavior.NoTracking);
			services.AddEntityFrameworkConnection<UsersContext>(QueryTrackingBehavior.NoTracking);
		}

		public static void HttpClientsRegistration(IServiceCollection services)
		{
			services.AddHttpClient("default", config =>
			{
				config.DefaultRequestHeaders.Add("Accept", "text/plain");
			});
		}
	}
}
