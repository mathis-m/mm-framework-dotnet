﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MMFramework.DependencyInjection.Builder;
using MMFramework.Extensions;
using MMFramework.Swashbuckle.Configuration;
using MMFramework.Swashbuckle.Filter;

namespace MMFramework.Swashbuckle.Extensions
{
    public static class SwaggerMMServiceBuilderExtensions
    {
        public static IMMServiceBuilder AddSwaggerIntegration(this IMMServiceBuilder builder, Action<MMSwashbuckleConfigurationBuilder>? setupAction = null)
        {
            var config = new MMSwashbuckleConfiguration(builder.ServiceInfo.ServiceName, builder.ServiceInfo.ServiceVersion);
            var configurationBuilder = new MMSwashbuckleConfigurationBuilder(config);
            setupAction?.Invoke(configurationBuilder);
            SetupSwaggerIntegration(builder, configurationBuilder.Build());
            return builder;
        }

        private static void SetupSwaggerIntegration(IMMServiceBuilder builder, IMMSwashbuckleConfiguration config)
        {
            builder.AddMMServiceSetupAction(() =>
            {
                builder.Services.TryAddSingleton(config);
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(config.MajorServiceVersionForUrl(), config.OpenApiInfo);
                    c.DocumentFilter<SwaggerSortByComplexityFilter>();

                    config.SwaggerGenSetupAction(c);
                });
            });
        }
    }
}