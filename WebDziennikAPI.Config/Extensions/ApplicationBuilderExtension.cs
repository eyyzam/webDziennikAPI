using Microsoft.AspNetCore.Builder;

namespace WebDziennikAPI.Config.Extensions
{
	public static class ApplicationBuilderExtension
	{
		public static IApplicationBuilder AddDefaultConfiguration(this IApplicationBuilder app)
		{
			if (ServiceCollectionExtension.UsingSwagger)
			{
				app.UseSwagger();
				app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/WebDziennikAPI/swagger.json", "WebDziennikAPI"));
			}

			if (ServiceCollectionExtension.UsingDefaultCorsPolicy)
				app.UseCors(ServiceCollectionExtension.NameOfCorsPolicy);
				
			return app;
		}
	}
}
