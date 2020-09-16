using MMFramework.Swashbuckle.Extensions;

namespace MMFramework.AspNetCore.Configuration
{
    public class MMAspNetCoreConfiguration : IMMAspNetCoreConfiguration
    {
        public string ServiceName { get; set; }
        public string ServiceVersion { get; set; }
        private readonly bool _isDevelopment;
        public string BasePath => _isDevelopment
            ? string.Empty
            : $"{this.ServiceNameForUrl()}/v{this.MajorServiceVersionForUrl()}";

        public MMAspNetCoreConfiguration(string serviceName, string serviceVersion, bool isDevelopment)
        {
            _isDevelopment = isDevelopment;
            ServiceName = serviceName;
            ServiceVersion = serviceVersion;
        }
    }
}