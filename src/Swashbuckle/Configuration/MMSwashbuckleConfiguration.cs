using MMFramework.Swashbuckle.Configuration.SortConfiguration;

namespace MMFramework.Swashbuckle.Configuration
{
    public class MMSwashbuckleConfiguration : IMMSwashbuckleConfiguration
    {
        public string ServiceName { get; set; }
        public string ServiceVersion { get; set; }
        public IMMSortSwaggerConfiguration SortConfiguration { get; set; }

        public MMSwashbuckleConfiguration(string serviceName, string serviceVersion)
        {
            ServiceName = serviceName;
            ServiceVersion = serviceVersion;
            SortConfiguration = new MMSortSwaggerConfiguration();
        }
    }
}