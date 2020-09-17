using Abstractions;
using Microsoft.OpenApi.Models;
using MMFramework.Swashbuckle.Configuration.SortConfiguration;

namespace MMFramework.Swashbuckle.Configuration
{
    /// <summary>
    ///     MM Framework Swashbuckle configuration
    /// </summary>
    public interface IMMSwashbuckleConfiguration: IMMServiceInfo
    {
        IMMSortSwaggerConfiguration SortConfiguration { get; set; }
        OpenApiInfo OpenApiInfo { get; set; }
        string SwaggerEndpoint { get; }
        string SwaggerEndpointName { get; }
    }
}