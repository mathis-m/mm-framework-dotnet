using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using MMFramework.DependencyInjection.Builder;
using MMFramework.Swashbuckle.Configuration;

namespace MMFramework.Swashbuckle.Extensions
{
    public static class SwaggerMMServiceBuilderExtensions
    {
        public static IMMServiceBuilder AddSwaggerIntegration(this IMMServiceBuilder builder, string serviceName, string serviceVersion)
        {
            var config = new MMSwashbuckleConfiguration(serviceName, serviceVersion);
            builder.AddMMServiceSetupAction(() =>
            {
                builder.Services.TryAddSingleton<IMMSwashbuckleConfiguration>(config);
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(config.MajorServiceVersionForUrl(), config.OpenApiInfo);
                });
            });
            return builder;
        }

        public static IMMServiceBuilder AddSwaggerIntegration(this IMMServiceBuilder builder, string serviceName, string serviceVersion, OpenApiInfo openApiInfo)
        {
            var config = new MMSwashbuckleConfiguration(serviceName, serviceVersion, openApiInfo);
            builder.AddMMServiceSetupAction(() =>
            {
                builder.Services.TryAddSingleton<IMMSwashbuckleConfiguration>(config);
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(config.MajorServiceVersionForUrl(), config.OpenApiInfo);
                });
            });
            return builder;
        }
    }
}
