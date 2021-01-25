using Microsoft.AspNetCore.Builder;

namespace WebDziennikAPI.Config.Extensions
{
	public static class ApplicationBuilderExtension
	{
		public static IApplicationBuilder AddDefaultConfiguration(this IApplicationBuilder app)
		{
			if (ServiceCollectionExtension.UsingSwagger)
			{
				app.UseSwagger(config =>
				{
					config.SerializeAsV2 = true;
				});
				app.UseSwaggerUI(config =>
				{
					config.DefaultModelsExpandDepth(-1);
					config.SwaggerEndpoint("/swagger/v1/swagger.json", "WebDziennikAPI");
				});
			}

			if (ServiceCollectionExtension.UsingDefaultCorsPolicy)
				app.UseCors(ServiceCollectionExtension.NameOfCorsPolicy);
				
			return app;
		}
	}
}
