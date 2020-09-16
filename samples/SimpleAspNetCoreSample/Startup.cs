using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MMFramework.AspNetCore.Extensions;
using MMFramework.DependencyInjection.Extensions;

namespace SimpleAspNetCoreSample
{
    public class Startup
    {
        private readonly IHostEnvironment _env;

        public Startup(IHostEnvironment env)
        {
            _env = env;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            const string serviceName = "SimpleAspNetCoreSample";
            const string serviceVersion = "SimpleAspNetCoreSample";
            services
                .AddMMFramework()
                    .AddSwashbuckleIntegration(serviceName, serviceVersion)
                    .AddAspNetCoreIntegration(serviceName, serviceVersion, _env.IsDevelopment())
                    .Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseMMFramework()
                .UseServiceInfoForPathBase()
                .Build();


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
