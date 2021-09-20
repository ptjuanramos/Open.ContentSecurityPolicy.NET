using Neo.ContentSecurityPolicy.NET.Directives;
using Neo.ContentSecurityPolicy.NET.Directives.Resolver;
using Neo.ContentSecurityPolicy.NET.Helpers;
using Neo.ContentSecurityPolicy.NET.Providers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;

namespace Neo.ContentSecurityPolicy.NET.Extensions
{
    public static class ServiceCollectionExtensions
    {

        private static void AddHelpers(this IServiceCollection services)
        {
            services.TryAddScoped<INonceProvider, DefaultNonceProvider>();
            services.AddTransient<IContentSecurityPolicyHelper, ContentSecurityPolicyHelper>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void AddContentSecurity(this IServiceCollection services)
        {
            services.AddHelpers();
            services.AddTransient<IDirectivesResolver, ConfigurationDirectivesResolver>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="directives"></param>
        public static void AddContentSecurity(this IServiceCollection services, IReadOnlyCollection<Directive> directives)
        {
            services.AddHelpers();
            services.AddSingleton<IDirectivesResolver>((_) => new ExplicitDirectivesResolver(directives));
        }
    }
}
