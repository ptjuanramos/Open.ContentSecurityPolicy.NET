using Microsoft.AspNetCore.Http;

namespace ContentSecurityPolicy.NET.Extensions
{
    internal static class HttpResponseExtensions
    {
        const string HeaderKey = "Content-Security-Policy";
        const string NonceKey = "nonce";

        public static void AddCSPHeader(this HttpResponse httpResponse, string cspHeaderValue)
        {
            if (!httpResponse.Headers.ContainsKey(HeaderKey))
            {
                httpResponse.Headers.Add(HeaderKey, cspHeaderValue);
            }
        }

        public static void AddNonceToResponseItems(this HttpResponse httpResponse, string nonce)
        {
            if(!httpResponse.HttpContext.Items.ContainsKey(NonceKey))
            {
                httpResponse.HttpContext.Items.Add(NonceKey, nonce);
            }
        }
    }
}
