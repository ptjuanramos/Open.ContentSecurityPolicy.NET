using ContentSecurityPolicy.NET.Helper;
using Microsoft.Extensions.DependencyInjection;

namespace ContentSecurityPolicy.NET.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddContentSecurity(this IServiceCollection services)
        {
            services.AddTransient<INonceHelper, NonceHelper>();
        }
    }
}
