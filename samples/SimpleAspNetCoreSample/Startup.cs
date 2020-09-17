using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MMFramework.AspNetCore.Extensions;
using MMFramework.DependencyInjection.Extensions;
using MMFramework.Swashbuckle.Extensions;

namespace SimpleAspNetCoreSample
{
    public class Startup
    {
        private readonly IHostEnvironment _env;

        public Startup(IHostEnvironment env, IConfiguration configuration)
        {
            _env = env;

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            const string serviceName = "SimpleAspNetCoreSample";
            const string serviceVersion = "V1.0.0-alpha";
            services
                .AddMMFramework()
                    .AddSwaggerIntegration(serviceName, serviceVersion, c => c
                        .UseOpenApiInfo(new OpenApiInfo
                        {
                            Description = "Sample App using MM Framework."
                        })
                        .SortDeprecatedLast()
                    )
                    .AddAspNetCoreIntegration(serviceName, serviceVersion, _env.IsDevelopment())
                    .Build()
                .AddControllers();
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
                    .UseSwagger()
                    .Build();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
