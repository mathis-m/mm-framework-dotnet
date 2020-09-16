using Microsoft.Extensions.DependencyInjection;
using MMFramework.DependencyInjection.Configuration;

namespace MMFramework.DependencyInjection.Builder
{
    public interface IMMServiceBuilder
    {
        IServiceCollection Services { get; }

        IMMServiceConfiguration Configuration { get; }
        IMMServiceBuilder AddSwashbuckleIntegration(string serviceName, string serviceVersion);
        IMMServiceBuilder AddAspNetCoreIntegration(string serviceName, string serviceVersion, bool isDevelopment);
        IServiceCollection Build();
    }
}