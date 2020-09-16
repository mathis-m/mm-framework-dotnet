namespace MMFramework.Swashbuckle.Configuration.SortConfiguration
{
    public interface IMMSortSwaggerConfiguration
    {
        bool SortByController { get; set; }
        bool ThenByComplexity { get; set; }
        bool DeprecatedLast { get; set; }
    }
}