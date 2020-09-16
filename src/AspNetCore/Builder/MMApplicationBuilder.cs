using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MMFramework.AspNetCore.Configuration;

namespace MMFramework.AspNetCore.Builder
{
    public class MMApplicationBuilder : IMMApplicationBuilder
    {
        public IApplicationBuilder App { get; set; }
        public IServiceProvider ServiceProvider => App.ApplicationServices;
        public IMMAspNetCoreConfiguration AspConfig => ServiceProvider.GetRequiredService<IMMAspNetCoreConfiguration>();

        public IMMApplicationBuilder UseServiceInfoForPathBase()
        {
            var pathBase = AspConfig.BasePath;
            App.UsePathBase(pathBase);
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