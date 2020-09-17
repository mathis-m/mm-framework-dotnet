using Microsoft.Extensions.DependencyInjection;
using MMFramework.DependencyInjection.Builder;

namespace MMFramework.DependencyInjection.Extensions
{
    public static class DependencyInjectionExtensions
    {
        /// <summary>
        ///     Adds MMFramework services to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns>An <see cref="IMMServiceBuilder" /> that can be used to further configure the MMFramework services.</returns>
        public static IMMServiceBuilder AddMMFramework(this IServiceCollection services) =>
            new MMServiceBuilder(services);
    }
}