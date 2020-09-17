using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MMFramework.AspNetCore.Builder;
using MMFramework.Swashbuckle.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MMFramework.Swashbuckle.Extensions
{
    public static class SwaggerMMApplicationBuilderExtension
    {
        public static IMMSwashbuckleConfiguration SwaggerConfig(this IMMApplicationBuilder builder) =>
            builder.ServiceProvider.GetRequiredService<IMMSwashbuckleConfiguration>();

        public static IMMApplicationBuilder UseSwagger(this IMMApplicationBuilder builder) => builder.UseSwagger(null);

        public static IMMApplicationBuilder UseSwagger(this IMMApplicationBuilder builder,
            Action<SwaggerUIOptions>? setupAction)
        {
            var swaggerConfig = builder.SwaggerConfig();

            builder.App
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    setupAction?.Invoke(c);
                    c.SwaggerEndpoint(swaggerConfig.SwaggerEndpoint, swaggerConfig.SwaggerEndpointName);
                    c.RoutePrefix = builder.AspConfig.BasePath;
                });
            return builder;
        }
    }
}