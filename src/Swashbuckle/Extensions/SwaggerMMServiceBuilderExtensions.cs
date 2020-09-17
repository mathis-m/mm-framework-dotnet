using System;
using Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MMFramework.DependencyInjection.Builder;
using MMFramework.Swashbuckle.Configuration;
using MMFramework.Swashbuckle.Filter;

namespace MMFramework.Swashbuckle.Extensions
{
    public static class SwaggerMMServiceBuilderExtensions
    {
        public static IMMServiceBuilder AddSwaggerIntegration(this IMMServiceBuilder builder, string serviceName, string serviceVersion, Action<MMSwashbuckleConfigurationBuilder>? setupAction = null)
        {
            var config = new MMSwashbuckleConfiguration(serviceName, serviceVersion);
            var configurationBuilder = new MMSwashbuckleConfigurationBuilder(config);
            setupAction?.Invoke(configurationBuilder);
            SetupSwaggerIntegration(builder, configurationBuilder.Build());
            return builder;
        }

        private static void SetupSwaggerIntegration(IMMServiceBuilder builder, IMMSwashbuckleConfiguration config)
        {
            builder.AddMMServiceSetupAction(() =>
            {
                builder.Services.TryAddSingleton<IMMSwashbuckleConfiguration>(config);
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(config.MajorServiceVersionForUrl(), config.OpenApiInfo);
                    c.DocumentFilter<SwaggerSortByComplexityFilter>();
                });
            });
        }
    }
}
