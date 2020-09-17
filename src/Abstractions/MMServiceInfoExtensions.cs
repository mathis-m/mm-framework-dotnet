using System.Linq;

namespace Abstractions
{
    public static class MMServiceInfoExtensions
    {
        public static string ServiceNameForUrl(this IMMServiceInfo swashbuckleConfig)
        {
            return swashbuckleConfig.ServiceName
                .Trim('/')
                .Replace(" ", "")
                .ToLower();
        }

        public static string MajorServiceVersionForUrl(this IMMServiceInfo swashbuckleConfig)
        {
            return "v" + swashbuckleConfig.ServiceVersion
                .Split('.')
                .First()
                .Trim('/')
                .ToLower()
                .TrimStart('v');
        }

        public static string FullServiceVersionForUrl(this IMMServiceInfo swashbuckleConfig)
        {
            return "v" + swashbuckleConfig.ServiceVersion
                .Trim('/')
                .ToLower()
                .TrimStart('v');
        }

        private static string PlainServiceVersion(this IMMServiceInfo swashbuckleConfig)
        {
            return swashbuckleConfig.ServiceVersion
                .Split('.')
                .First()
                .Trim('/')
                .ToLower()
                .TrimStart('v');
        }

        public static string FullName(this IMMServiceInfo swashbuckleConfig)
        {
            return $"{swashbuckleConfig.ServiceName}, Version: {PlainServiceVersion(swashbuckleConfig)}";
        }
    }
}