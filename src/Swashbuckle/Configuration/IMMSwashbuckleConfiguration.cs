using MMFramework.Swashbuckle.Configuration.SortConfiguration;

namespace MMFramework.Swashbuckle.Configuration
{
    /// <summary>
    ///     MM Framework Swashbuckle configuration
    /// </summary>
    public interface IMMSwashbuckleConfiguration
    {
        string ServiceName { get; set; }
        string ServiceVersion { get; set; }
        IMMSortSwaggerConfiguration SortConfiguration { get; set; }
    }
}