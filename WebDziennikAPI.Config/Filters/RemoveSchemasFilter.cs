using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebDziennikAPI.Config.Filters
{
	public class RemoveSchemasFilter : IDocumentFilter
	{
		public void Apply(OpenApiDocument swaggerDocument, DocumentFilterContext context)
		{
			var schemas = swaggerDocument.Components.Schemas;
			foreach (var schema in schemas)
			{
				swaggerDocument.Components.Schemas.Remove(schema.Key);
			}
		}
	}
}
