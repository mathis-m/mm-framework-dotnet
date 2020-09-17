using Microsoft.Extensions.DependencyInjection;
using System;

namespace MMFramework.DependencyInjection.Builder
{
    public interface IMMServiceBuilder
    {
        IServiceCollection Services { get; }
        public IMMServiceBuilder AddMMServiceSetupAction(Action setupAction);
        IServiceCollection Build();
    }
}