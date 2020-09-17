using MMFramework.Extensions;

namespace MMFramework.AspNetCore.Configuration
{
    public class MMAspNetCoreConfiguration : IMMAspNetCoreConfiguration
    {
        private readonly bool _isDevelopment;

        public MMAspNetCoreConfiguration(string serviceName, string serviceVersion, bool isDevelopment)
        {
            _isDevelopment = isDevelopment;
            ServiceName = serviceName;
            ServiceVersion = serviceVersion;
        }

        public string ServiceName { get; set; }
        public string ServiceVersion { get; set; }

        public string BasePath => _isDevelopment
            ? string.Empty
            : $"{this.ServiceNameForUrl()}/v{this.MajorServiceVersionForUrl()}";
    }
}