using Microsoft.AspNetCore.Builder;
using WebDziennikAPI.Core.Middlewares.Auth;

namespace WebDziennikAPI.Config.Extensions
{
	public static class ApplicationBuilderExtension
	{
		public static IApplicationBuilder AddDefaultConfiguration(this IApplicationBuilder app)
		{
			if (ServiceCollectionExtension.UsingSwagger)
			{
				app.UseSwagger();
				app.UseSwaggerUI(config =>
				{
					config.SwaggerEndpoint("WebDziennikAPI/swagger.json", "WebDziennikAPI");
				});
			}

			if (ServiceCollectionExtension.UsingDefaultCorsPolicy)
				app.UseCors(ServiceCollectionExtension.NameOfCorsPolicy);
				
			return app;
		}

		public static IApplicationBuilder RegisterMiddlewares(this IApplicationBuilder app)
		{
			app.UseMiddleware<JWTMiddleware>();

			return app;
		}
	}
}
