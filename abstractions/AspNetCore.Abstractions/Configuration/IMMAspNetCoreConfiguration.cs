namespace MMFramework.AspNetCore.Configuration
{
    public interface IMMAspNetCoreConfiguration : IMMServiceInfo
    {
        string BasePath { get; }
    }
}