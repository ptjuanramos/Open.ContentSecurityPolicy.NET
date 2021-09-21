using Ramos.ContentSecurityPolicy.NET.Directives;
using Ramos.ContentSecurityPolicy.NET.Directives.Resolver;
using System.Collections.Generic;

namespace Ramos.ContentSecurityPolicy.NET.Helpers
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