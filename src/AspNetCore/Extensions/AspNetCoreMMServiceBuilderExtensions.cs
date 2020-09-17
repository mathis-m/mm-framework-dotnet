using Microsoft.Extensions.DependencyInjection.Extensions;
using MMFramework.AspNetCore.Configuration;
using MMFramework.DependencyInjection.Builder;

namespace MMFramework.AspNetCore.Extensions
{
    public static class AspNetCoreMMServiceBuilderExtensions
    {
        public static IMMServiceBuilder AddAspNetCoreIntegration(this IMMServiceBuilder builder, string serviceName, string serviceVersion, bool isDevelopment)
        {
            var config = new MMAspNetCoreConfiguration(serviceName, serviceVersion, isDevelopment);
            builder.AddMMServiceSetupAction(() =>
            {
                builder.Services.TryAddSingleton<IMMAspNetCoreConfiguration>(config);
            });
            return builder;
        }
    }
}
