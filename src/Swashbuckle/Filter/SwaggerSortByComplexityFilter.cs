using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Models;
using MMFramework.Swashbuckle.Configuration;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MMFramework.Swashbuckle.Filter
{
    public class SwaggerSortByComplexityFilter : IDocumentFilter
    {
        private readonly IMMSwashbuckleConfiguration _configuration;

        public SwaggerSortByComplexityFilter(IMMSwashbuckleConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var paths = swaggerDoc.Paths
                .OrderBy(e => e.Key); // alphabetic

            // Sort on operation level for deprecation
            var byComplexity = _configuration.SortConfiguration.ThenByComplexity;
            var deprecatedLast = _configuration.SortConfiguration.DeprecatedLast;
            if (deprecatedLast)
            {
                paths = SortOperationsDeprecatedLastThenByComplexity(swaggerDoc); // alphabetic
            }
            // for only complexity
            else if (byComplexity)
            {
                paths = SortOperationsOnlyByComplexity(swaggerDoc);
            }

            // sort paths by complexity
            if (byComplexity)
            {
                paths = paths
                    .ThenBy(x => x.Key.Length + x.Value.Parameters.Count); // complexity
            }

            var newPaths = new OpenApiPaths();
            paths.ToList().ForEach(path => newPaths.Add(path.Key, path.Value));
            swaggerDoc.Paths = newPaths;
        }

        private static IOrderedEnumerable<KeyValuePair<string, OpenApiPathItem>> SortOperationsOnlyByComplexity(
            OpenApiDocument swaggerDoc)
        {
            return swaggerDoc.Paths
                .Select(SortDeprecatedOperationsLast)
                .OrderBy(e => e.Key);
        }

        private static KeyValuePair<string, OpenApiPathItem> SortDeprecatedOperationsLast(
            KeyValuePair<string, OpenApiPathItem> x)
        {
            var ops = new Dictionary<OperationType, OpenApiOperation>();
            x.Value.Operations
                .OrderBy(op => op.Value.Parameters.Count)
                .ToList()
                .ForEach(op => ops.Add(op.Key, op.Value));
            x.Value.Operations = ops;
            return x;
        }

        private IOrderedEnumerable<KeyValuePair<string, OpenApiPathItem>> SortOperationsDeprecatedLastThenByComplexity(
            OpenApiDocument swaggerDoc)
        {
            return swaggerDoc.Paths
                .Select(SortOperationsDeprecatedLastAndOptionalByComplexity)
                .OrderBy(x => x.Value.Operations.Values.Any(op => op.Deprecated)) // deprecated last
                .ThenBy(e => e.Key);
        }

        private KeyValuePair<string, OpenApiPathItem> SortOperationsDeprecatedLastAndOptionalByComplexity(
            KeyValuePair<string, OpenApiPathItem> x)
        {
            var ops = new Dictionary<OperationType, OpenApiOperation>();
            var tmpOps = x.Value.Operations.OrderBy(op => op.Value.Deprecated);
            // and complexity
            if (_configuration.SortConfiguration.ThenByComplexity)
            {
                tmpOps = tmpOps.ThenBy(op => op.Value.Parameters.Count);
            }

            tmpOps.ToList()
                .ForEach(op => ops.Add(op.Key, op.Value));
            x.Value.Operations = ops;
            return x;
        }
    }
}