using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace ContentSecurityPolicy.NET.Extensions
{
    public static class CSPApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCSP(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Use(async (ctx, next) =>
            {
                HttpResponse httpResponse = ctx.Response;
                string nonce = "";

                httpResponse.AddCSPHeader(nonce);
                httpResponse.AddNonceToResponseItems(nonce);

                await next();
            });

            return applicationBuilder;
        }
    }
}
