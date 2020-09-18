using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using MMFramework.DependencyInjection.Extensions;

namespace MMFramework.DependencyInjection.Builder
{
    public class MMServiceBuilder : IMMServiceBuilder
    {
        private readonly List<Action> _serviceSetupActions;
        public IMMServiceInfo ServiceInfo { get; }

        public MMServiceBuilder(IServiceCollection services, Action<IServiceInfoBuilder> setupAction)
        {
            Services = services;
            _serviceSetupActions = new List<Action>();

            var infoBuilder = new ServiceInfoBuilder();
            setupAction(infoBuilder);
            ServiceInfo = infoBuilder.Build();
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