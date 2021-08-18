using Microsoft.AspNetCore.Builder;

namespace ContentSecurityPolicy.NET.Extensions
{
    public static class CSPApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseContentSecurityPolicy(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ContentSecurityPolicyMiddleware>();
        }
    }
}
