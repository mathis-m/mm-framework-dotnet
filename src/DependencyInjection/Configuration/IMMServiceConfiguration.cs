using MMFramework.AspNetCore.Configuration;
using MMFramework.Swashbuckle.Configuration;

namespace MMFramework.DependencyInjection.Configuration
{
    public interface IMMServiceConfiguration
    {

        /// <summary>
        ///     Optional configuration for swashbuckle setup.
        /// </summary>
        IMMSwashbuckleConfiguration? SwashbuckleConfiguration { get; set; }

        /// <summary>
        ///     Optional configuration for aspnetcore setup.
        /// </summary>
        IMMAspNetCoreConfiguration? AspNetCoreConfiguration { get; set; }
    }
}