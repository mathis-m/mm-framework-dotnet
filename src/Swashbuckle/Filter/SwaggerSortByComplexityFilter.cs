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

            IOrderedEnumerable<KeyValuePair<string, OpenApiPathItem>>? paths = swaggerDoc.Paths
                .OrderBy(e => e.Key); // alphabetic

            // Sort on operation level for deprecation
            if (_configuration.SortConfiguration.DeprecatedLast)
            {
                paths = swaggerDoc.Paths
                    .Select(x =>
                    {
                        var ops = new Dictionary<OperationType, OpenApiOperation>();
                        var tmpOps = x.Value.Operations
                            .OrderBy(op => op.Value.Deprecated);
                        // and complexity
                        if (_configuration.SortConfiguration.ThenByComplexity)
                        {
                            tmpOps = tmpOps.ThenBy(op => op.Value.Parameters.Count);
                        }
                        
                        tmpOps
                            .ToList()
                            .ForEach(op => ops.Add(op.Key, op.Value));
                        x.Value.Operations = ops;
                        return x;
                    })
                    .OrderBy(x => x.Value.Operations.Values.Any(op => op.Deprecated)) // deprecated last
                    .ThenBy(e => e.Key); // alphabetic
            }
            // for only complexity
            else if (_configuration.SortConfiguration.ThenByComplexity)
            {
                paths = swaggerDoc.Paths
                    .Select(x =>
                    {
                        var ops = new Dictionary<OperationType, OpenApiOperation>();
                        x.Value.Operations
                            .OrderBy(op => op.Value.Parameters.Count)
                            .ToList()
                            .ForEach(op => ops.Add(op.Key, op.Value));
                        x.Value.Operations = ops;
                        return x;
                    })
                    .OrderBy(e => e.Key);
            }
            // sort paths by complexity
            if (_configuration.SortConfiguration.ThenByComplexity)
            {
                paths = paths
                    .ThenBy(x => x.Key.Length + x.Value.Parameters.Count); // complexity
            }

            var newPaths = new OpenApiPaths();
            paths.ToList().ForEach(path => newPaths.Add(path.Key, path.Value));
            swaggerDoc.Paths = newPaths;
        }
    }
}
