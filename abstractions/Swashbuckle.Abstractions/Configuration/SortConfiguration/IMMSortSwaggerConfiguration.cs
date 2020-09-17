namespace MMFramework.Swashbuckle.Configuration.SortConfiguration
{
    public interface IMMSortSwaggerConfiguration
    {
        bool ThenByComplexity { get; set; }
        bool DeprecatedLast { get; set; }
    }
}