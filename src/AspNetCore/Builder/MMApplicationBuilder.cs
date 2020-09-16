using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MMFramework.AspNetCore.Configuration;
using MMFramework.Swashbuckle.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MMFramework.AspNetCore.Builder
{
    public class MMApplicationBuilder : IMMApplicationBuilder
    {
        public IApplicationBuilder App { get; set; }
        public IServiceProvider ServiceProvider => App.ApplicationServices;
        public IMMAspNetCoreConfiguration AspConfig => ServiceProvider.GetRequiredService<IMMAspNetCoreConfiguration>();
        public IMMSwashbuckleConfiguration SwaggerConfig => ServiceProvider.GetRequiredService<IMMSwashbuckleConfiguration>();

        public IMMApplicationBuilder UseServiceInfoForPathBase()
        {
            var pathBase = AspConfig.BasePath;
            App.UsePathBase(pathBase);
            return this;
        }

        public IMMApplicationBuilder UseSwagger()
        {
            return UseSwagger(null);
        }

        public IMMApplicationBuilder UseSwagger(Action<SwaggerUIOptions> setupAction)
        {
            App
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    setupAction?.Invoke(c);

                    c.SwaggerEndpoint(SwaggerConfig.SwaggerEndpoint, SwaggerConfig.SwaggerEndpointName);
                    c.RoutePrefix = AspConfig.BasePath;
                });
            return this;
        }

        public IApplicationBuilder Build()
        {
            return App;
        }

        public MMApplicationBuilder(IApplicationBuilder app)
        {
            App = app;
        }
    }
}