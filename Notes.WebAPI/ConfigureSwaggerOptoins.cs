using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Notes.WebAPI
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _proivider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider proivider)
        {
            _proivider = proivider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _proivider.ApiVersionDescriptions)
            {
                var apiversion = description.ApiVersion.ToString();
                options.SwaggerDoc(
                    description.GroupName,
                    new OpenApiInfo
                    {
                        Version = apiversion,
                        Title = $"Notes API, version:{apiversion}",
                        Description = "Notes API. Pet project."
                    });
                options.AddSecurityDefinition(
                    $"AuthToken {apiversion}",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "bearer",
                        Name = "Authorization",
                        Description = "Authorization token"
                    });

                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = $"AuthToken {apiversion}",
                            }
                        },
                        new string[] { }
                        }
                    });

                options.CustomOperationIds(apiDescription => apiDescription.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null);


            }
        }
    }
}
