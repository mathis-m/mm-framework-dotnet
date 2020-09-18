using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MMFramework.AspNetCore.Configuration;
using MMFramework.DependencyInjection.Builder;

namespace MMFramework.AspNetCore.Extensions
{
    public static class AspNetCoreMMServiceBuilderExtensions
    {
        public static IMMServiceBuilder AddAspNetCoreIntegration(this IMMServiceBuilder builder) =>
            builder.AddMMServiceSetupAction(() => builder.Services
                .TryAddSingleton<IMMAspNetCoreConfiguration>(sp => 
                    new MMAspNetCoreConfiguration(
                        builder.ServiceInfo.ServiceName, 
                        builder.ServiceInfo.ServiceVersion,
                        sp.GetRequiredService<IHostEnvironment>().IsDevelopment()
                    )
                )
            );
    }
}