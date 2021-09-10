using ContentSecurityPolicy.NET.Directives;
using ContentSecurityPolicy.NET.Directives.Resolver;
using ContentSecurityPolicy.NET.Helper;
using System.Collections.Generic;

namespace ContentSecurityPolicy.NET
{
    internal class ContentSecurityPolicyHelper : IContentSecurityPolicyHelper
    {
        private readonly IDirectivesResolver _directivesResolver;

        public ContentSecurityPolicyHelper(IDirectivesResolver directivesResolver)
        {
            _directivesResolver = directivesResolver;
        }

        public ContentSecurityPolicyHeader GetContentSecurityPolicy(string nonce)
        {
            IReadOnlyCollection<Directive> directives = _directivesResolver.GetDirectives();
            return new ContentSecurityPolicyHeader(directives, nonce);
        }
    }
}