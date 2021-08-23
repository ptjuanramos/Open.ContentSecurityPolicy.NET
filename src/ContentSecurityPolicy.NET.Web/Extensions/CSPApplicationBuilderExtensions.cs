using Microsoft.AspNetCore.Builder;

namespace ContentSecurityPolicy.NET.Web.Extensions
{
    public static class CspApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseContentSecurityPolicy(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ContentSecurityPolicyMiddleware>();
        }
    }
}
