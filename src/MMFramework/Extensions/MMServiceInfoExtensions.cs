using System.Linq;

namespace MMFramework.Extensions
{
    public static class MMServiceInfoExtensions
    {
        public static string ServiceNameForUrl(this IMMServiceInfo swashbuckleConfig) =>
            swashbuckleConfig.ServiceName
                .Trim('/')
                .Replace(" ", "")
                .ToLower();

        public static string MajorServiceVersionForUrl(this IMMServiceInfo swashbuckleConfig) =>
            "v" + swashbuckleConfig.ServiceVersion
                .Split('.')
                .First()
                .Trim('/')
                .ToLower()
                .TrimStart('v');

        public static string FullServiceVersionForUrl(this IMMServiceInfo swashbuckleConfig) =>
            "v" + swashbuckleConfig.ServiceVersion
                .Trim('/')
                .ToLower()
                .TrimStart('v');

        private static string PlainServiceVersion(this IMMServiceInfo swashbuckleConfig) =>
            swashbuckleConfig.ServiceVersion
                .Split('.')
                .First()
                .Trim('/')
                .ToLower()
                .TrimStart('v');

        public static string FullName(this IMMServiceInfo swashbuckleConfig) =>
            $"{swashbuckleConfig.ServiceName}, Version: {PlainServiceVersion(swashbuckleConfig)}";
    }
}