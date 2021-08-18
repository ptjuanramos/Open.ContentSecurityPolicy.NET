using ContentSecurityPolicy.NET.Extensions;
using ContentSecurityPolicy.NET.Helper;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ContentSecurityPolicy.NET
{
    public class ContentSecurityPolicyMiddleware
    {
        private readonly RequestDelegate _nextDelegate;
        private readonly INonceHelper _nonceHelper;

        public ContentSecurityPolicyMiddleware(RequestDelegate nextDelegate, INonceHelper nonceHelper)
        {
            _nextDelegate = nextDelegate;
            _nonceHelper = nonceHelper;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            HttpResponse httpResponse = context.Response;
            string nonce = _nonceHelper.GenerateNonce();

            httpResponse.AddCSPHeader(nonce);
            httpResponse.AddNonceToResponseItems(nonce);

            await _nextDelegate(context);
        }
    }
}
