using Microsoft.AspNetCore.Builder;
using MMFramework.AspNetCore.Builder;

namespace MMFramework.AspNetCore.Extensions
{
    public static class ApplicationBuilderExtensions
    {

        /// <summary>
        /// Use MMFramework to configure hosting./>
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> instance to be configured.</param>
        /// <returns>Returns <see cref="IMMApplicationBuilder"/> to configure the <see cref="IApplicationBuilder"/></returns>
        public static IMMApplicationBuilder UseMMFramework(this IApplicationBuilder app)
        {
            return new MMApplicationBuilder(app);
        }
    }
}
