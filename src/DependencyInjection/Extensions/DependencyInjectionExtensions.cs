using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MMFramework.DependencyInjection.Builder;

namespace MMFramework.DependencyInjection.Extensions
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        ///     Adds MMFramework services to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>An <see cref="IMMServiceBuilder" /> that can be used to further configure the MMFramework services.</returns>
        public static IMMServiceBuilder AddMMFramework(this IServiceCollection services, Action<IServiceInfoBuilder> setupAction) =>
            new MMServiceBuilder(services, setupAction);
    }

    public interface IServiceInfoBuilder
    {
        IServiceInfoBuilder UseName(string name);
        IServiceInfoBuilder UseVersion(string version);
        IMMServiceInfo Build();
    }

    public class ServiceInfoBuilder : IServiceInfoBuilder
    {
        private readonly IMMServiceInfo _serviceInfo;

        public ServiceInfoBuilder()
        {
            var assemblyName = Assembly.GetCallingAssembly().GetName();
            var version = assemblyName.Version;
            _serviceInfo = new MMServiceInfo
            {
                ServiceName = assemblyName.Name,
                ServiceVersion = version is null
                    ? "1.0"
                    : $"{version.Major}.{version.Minor}.{version.Revision}",
            };
        }

        public IServiceInfoBuilder UseName(string name)
        {
            _serviceInfo.ServiceName = name;
            return this;
        }

        public IServiceInfoBuilder UseVersion(string version)
        {
            _serviceInfo.ServiceVersion = version;
            return this;
        }

        public IMMServiceInfo Build() => _serviceInfo;
    }
}