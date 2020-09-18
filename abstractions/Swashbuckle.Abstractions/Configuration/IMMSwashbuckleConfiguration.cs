using System;
using Microsoft.OpenApi.Models;
using MMFramework.Swashbuckle.Configuration.SortConfiguration;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MMFramework.Swashbuckle.Configuration
{
    /// <summary>
    ///     MM Framework Swashbuckle configuration
    /// </summary>
    public interface IMMSwashbuckleConfiguration : IMMServiceInfo
    {
        IMMSortSwaggerConfiguration SortConfiguration { get; set; }
        OpenApiInfo OpenApiInfo { get; set; }
        Action<SwaggerGenOptions> SwaggerGenSetupAction { get; set; }
        string SwaggerEndpoint { get; }
        string SwaggerEndpointName { get; }
    }
}