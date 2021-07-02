using Microsoft.AspNetCore.Http;

namespace ContentSecurityPolicy.NET.Helpers
{
    internal static class HeaderHelper
    {
        const string HeaderKey = "Content-Security-Policy";

        public static void AddCSPHeader(HttpResponse httpResponse)
        {
            if (!httpResponse.Headers.ContainsKey(HeaderKey))
            {
                httpResponse.Headers.Add(HeaderKey, ""); //TODO 
            }
        }
    }
}
