namespace MMFramework.Swashbuckle.Configuration.SortConfiguration
{
    public class MMSortSwaggerConfiguration : IMMSortSwaggerConfiguration
    {
        public bool ThenByComplexity { get; set; } = true;
        public bool DeprecatedLast { get; set; } = false;
    }
}