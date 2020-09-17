﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using MMFramework.AspNetCore.Configuration;
using System;
using System.Collections.Generic;

namespace MMFramework.AspNetCore.Builder
{
    public class MMApplicationBuilder : IMMApplicationBuilder
    {
        private readonly List<Action> _setupApplicationBuilderActions;
        public IApplicationBuilder App { get; set; }
        public IServiceProvider ServiceProvider => App.ApplicationServices;
        public IMMAspNetCoreConfiguration AspConfig => ServiceProvider.GetRequiredService<IMMAspNetCoreConfiguration>();

        public IMMApplicationBuilder AddMMApplicationBuilderSetupAction(Action setupAction)
        {
            _setupApplicationBuilderActions.Add(setupAction);
            return this;
        }

        public IMMApplicationBuilder UseServiceInfoForPathBase()
        {
            var pathBase = AspConfig.BasePath;
            App.UsePathBase(pathBase);
            return this;
        }

        public IApplicationBuilder Build()
        {
            _setupApplicationBuilderActions
                .ForEach(setup => setup());
            return App;
        }

        public MMApplicationBuilder(IApplicationBuilder app)
        {
            App = app;
            _setupApplicationBuilderActions = new List<Action>();
        }
    }
}