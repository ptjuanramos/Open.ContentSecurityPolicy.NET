using ContentSecurityPolicy.NET.Extensions;
using ContentSecurityPolicy.NET.Helper;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ContentSecurityPolicy.NET
{
    internal class ContentSecurityPolicyMiddleware
    {
        private readonly RequestDelegate _nextDelegate;
        private readonly IContentSecurityPolicyHelper _contentSecurityPolicyHelper;

        public ContentSecurityPolicyMiddleware(
            RequestDelegate nextDelegate, 
            IContentSecurityPolicyHelper contentSecurityPolicyHelper)
        {
            _nextDelegate = nextDelegate;
            _contentSecurityPolicyHelper = contentSecurityPolicyHelper;
        }

        public async Task InvokeAsync(HttpContext context, INonceHelper nonceHelper)
        {
            HttpResponse httpResponse = context.Response;
            string nonce = nonceHelper.GetNonce();

            ContentSecurityPolicyHeader contentSecurityPolicyHeader = _contentSecurityPolicyHelper.GetContentSecurityPolicy(nonce);

            httpResponse.AddCSPHeader(contentSecurityPolicyHeader);
            httpResponse.AddNonceToResponseItems(nonce);

            await _nextDelegate(context);
        }
    }
}
