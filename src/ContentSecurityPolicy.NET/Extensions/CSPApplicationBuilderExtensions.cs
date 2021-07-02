using ContentSecurityPolicy.NET.Helpers;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentSecurityPolicy.NET.Extensions
{
    public static class CSPApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCSP(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Use(async (ctx, next) =>
            {
                HeaderHelper.AddCSPHeader(ctx.Response);
                await next();
            });

            return applicationBuilder;
        }
    }
}
