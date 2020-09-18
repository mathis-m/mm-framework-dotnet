using Microsoft.AspNetCore.Builder;
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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMMFramework(x => x
                    .UseName("SimpleAspNetCoreSample")
                    .UseVersion("V1.0.0-alpha")
                ).AddSwaggerIntegration(c => c
                    .UseOpenApiInfo(new OpenApiInfo
                    {
                        Description = "Sample App using MM Framework.",
                    })
                    .SortDeprecatedLast()
                    .UseSwaggerGen(genOptions => genOptions
                        .UseInlineDefinitionsForEnums()
                    )
                ).AddAspNetCoreIntegration(
                ).Build()
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
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}