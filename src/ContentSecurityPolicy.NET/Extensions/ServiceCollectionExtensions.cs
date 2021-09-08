using ContentSecurityPolicy.NET.Directives;
using ContentSecurityPolicy.NET.Directives.Resolver;
using ContentSecurityPolicy.NET.Helper;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace ContentSecurityPolicy.NET.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddContentSecurity(this IServiceCollection services)
        {
            services.AddTransient<INonceHelper, NonceHelper>();
            services.AddTransient<IDirectivesResolver, ConfigurationDirectivesResolver>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="directives"></param>
        public static void AddContentSecurity(this IServiceCollection services, IReadOnlyCollection<Directive> directives)
        {
            services.AddTransient<INonceHelper, NonceHelper>();
            services.AddSingleton<IDirectivesResolver>((_) => new ExplicitDirectivesResolver(directives));
        }
    }
}
