using Microsoft.AspNetCore.Builder;

namespace Open.ContentSecurityPolicy.NET.Extensions
{
    public static class CspApplicationBuilderExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseContentSecurityPolicy(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ContentSecurityPolicyMiddleware>();
        }
    }
}
