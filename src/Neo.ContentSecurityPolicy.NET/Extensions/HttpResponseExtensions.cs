using Microsoft.AspNetCore.Http;

namespace Neo.ContentSecurityPolicy.NET.Extensions
{
    internal static class HttpResponseExtensions
    {
        public static void AddCSPHeader(this HttpResponse httpResponse, ContentSecurityPolicyHeader contentSecurityPolicyHeader)
        {
            if (!httpResponse.Headers.ContainsKey(Constants.HeaderKey))
            {
                httpResponse.Headers.Add(Constants.HeaderKey, contentSecurityPolicyHeader.ToString());
            }
        }

        public static void AddNonceToResponseItems(this HttpResponse httpResponse, string nonce)
        {
            if(!httpResponse.HttpContext.Items.ContainsKey(Constants.NonceKey))
            {
                httpResponse.HttpContext.Items.Add(Constants.NonceKey, nonce);
            }
        }
    }
}
