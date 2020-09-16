
namespace MMFramework.AspNetCore.Configuration
{
    public class MMAspNetCoreConfiguration : IMMAspNetCoreConfiguration
    {
        public string BasePath { get; set; }

        public MMAspNetCoreConfiguration(string serviceName, string serviceVersion, bool isDevelopment)
        {
            serviceName = serviceName
                .Trim('/')
                .ToLower();
            serviceVersion = serviceVersion
                .Trim('/')
                .ToLower()
                .TrimStart('v');
            BasePath = isDevelopment
                ? ""
                : $"/{serviceName}/v{serviceVersion}";
        }
    }
}