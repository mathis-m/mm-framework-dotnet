﻿using Microsoft.OpenApi.Models;

namespace MMFramework.Swashbuckle.Configuration
{
    public class MMSwashbuckleConfigurationBuilder
    {
        private readonly IMMSwashbuckleConfiguration _configuration;

        public MMSwashbuckleConfigurationBuilder(IMMSwashbuckleConfiguration configuration)
        {
            _configuration = configuration;
        }

        public MMSwashbuckleConfigurationBuilder UseOpenApiInfo(OpenApiInfo openApiInfo)
        {
            openApiInfo.Title ??= _configuration.ServiceName;
            openApiInfo.Version ??= _configuration.FullServiceVersionForUrl();
            _configuration.OpenApiInfo = openApiInfo;

            return this;
        }

        public MMSwashbuckleConfigurationBuilder SortDeprecatedLast(bool sortLast = true)
        {
            _configuration.SortConfiguration.DeprecatedLast = sortLast;
            return this;
        }

        public MMSwashbuckleConfigurationBuilder SortThenByComplexity(bool thenByComplexity = true)
        {
            _configuration.SortConfiguration.ThenByComplexity = thenByComplexity;
            return this;
        }

        public IMMSwashbuckleConfiguration Build()
        {
            return _configuration;
        }
    }
}