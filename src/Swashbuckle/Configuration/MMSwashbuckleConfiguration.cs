using Abstractions;
using Microsoft.OpenApi.Models;
using MMFramework.Swashbuckle.Configuration.SortConfiguration;

namespace MMFramework.Swashbuckle.Configuration
{
    public class MMSwashbuckleConfiguration : IMMSwashbuckleConfiguration
    {
        public string ServiceName { get; set; }
        public string ServiceVersion { get; set; }
        public OpenApiInfo OpenApiInfo { get; set; }
        public string SwaggerEndpoint => $"/swagger/{this.MajorServiceVersionForUrl()}/swagger.json";
        public string SwaggerEndpointName => this.FullName();
        public IMMSortSwaggerConfiguration SortConfiguration { get; set; }

        public MMSwashbuckleConfiguration(string serviceName, string serviceVersion, OpenApiInfo openApiInfo)
        {
            
            ServiceName = serviceName;
            ServiceVersion = serviceVersion;
            SortConfiguration = new MMSortSwaggerConfiguration();
            openApiInfo.Title ??= ServiceName;
            openApiInfo.Version ??= this.FullServiceVersionForUrl();
            OpenApiInfo = openApiInfo;
        }

        public MMSwashbuckleConfiguration(string serviceName, string serviceVersion)
        {

            ServiceName = serviceName;
            ServiceVersion = serviceVersion;
            SortConfiguration = new MMSortSwaggerConfiguration();
            OpenApiInfo = new OpenApiInfo { Title = ServiceName, Version = this.FullServiceVersionForUrl() };
        }
    }
}