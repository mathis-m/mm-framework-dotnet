using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace MMFramework.DependencyInjection.Builder
{
    public class MMServiceBuilder : IMMServiceBuilder
    {
        private readonly List<Action> _serviceSetupActions;

        public MMServiceBuilder(IServiceCollection services)
        {
            Services = services;
            _serviceSetupActions = new List<Action>();
        }

        public IServiceCollection Services { get; }

        public IMMServiceBuilder AddMMServiceSetupAction(Action setupAction)
        {
            _serviceSetupActions.Add(setupAction);
            return this;
        }

        public IServiceCollection Build()
        {
            _serviceSetupActions
                .ForEach(setup => setup());
            return Services;
        }
    }
}