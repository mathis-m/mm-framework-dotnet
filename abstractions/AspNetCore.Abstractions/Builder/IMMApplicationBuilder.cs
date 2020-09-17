
using MMFramework.AspNetCore.Configuration;
using System;
using Microsoft.AspNetCore.Builder;

namespace MMFramework.AspNetCore.Builder
{
    public interface IMMApplicationBuilder
    {
        IApplicationBuilder App { get; set; }
        IServiceProvider ServiceProvider { get; }
        IMMAspNetCoreConfiguration AspConfig { get; }
        IMMApplicationBuilder AddMMApplicationBuilderSetupAction(Action setupAction);
        IMMApplicationBuilder UseServiceInfoForPathBase();
        IApplicationBuilder Build();
    }
}