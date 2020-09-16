using MMFramework.AspNetCore.Configuration;
using MMFramework.Swashbuckle.Configuration;

namespace MMFramework.DependencyInjection.Configuration
{
    public class MMServiceConfiguration : IMMServiceConfiguration
    {
        public IMMSwashbuckleConfiguration? SwashbuckleConfiguration { get; set; }
        public IMMAspNetCoreConfiguration? AspNetCoreConfiguration { get; set; }
    }
}