using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using MMFramework.AspNetCore.Configuration;
using MMFramework.DependencyInjection.Configuration;
using MMFramework.Swashbuckle.Configuration;
using MMFramework.Swashbuckle.Extensions;

namespace MMFramework.DependencyInjection.Builder
{
    public class MMServiceBuilder : IMMServiceBuilder
    {
        public IServiceCollection Services { get; }
        public IMMServiceConfiguration Configuration { get; }

        public MMServiceBuilder(IServiceCollection services)
        {
            Services = services;
            Configuration = new MMServiceConfiguration();
        }

        public IMMServiceBuilder AddSwashbuckleIntegration(string serviceName, string serviceVersion)
        {
            
            Configuration.SwashbuckleConfiguration = new MMSwashbuckleConfiguration(serviceName, serviceVersion);
            return this;
        }

        public IMMServiceBuilder AddSwashbuckleIntegration(string serviceName, string serviceVersion, OpenApiInfo openApiInfo)
        {

            Configuration.SwashbuckleConfiguration = new MMSwashbuckleConfiguration(serviceName, serviceVersion, openApiInfo);
            return this;
        }

        public IMMServiceBuilder AddAspNetCoreIntegration(string serviceName, string serviceVersion, bool isDevelopment)
        {
            Configuration.AspNetCoreConfiguration = new MMAspNetCoreConfiguration(serviceName, serviceVersion, isDevelopment);
            return this;
        }

        public IServiceCollection Build()
        {
            if (Configuration.AspNetCoreConfiguration is { } aspConfig)
            {
                Services.TryAddSingleton(aspConfig);
            }

            if (Configuration.SwashbuckleConfiguration is { } swashbuckleConfig)
            {
                Services.TryAddSingleton(swashbuckleConfig);
                Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(swashbuckleConfig.MajorServiceVersionForUrl(), swashbuckleConfig.OpenApiInfo);
                });
            }
            return Services;
        }
    }
}