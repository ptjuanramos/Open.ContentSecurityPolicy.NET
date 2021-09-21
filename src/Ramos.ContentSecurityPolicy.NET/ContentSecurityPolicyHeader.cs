using Ramos.ContentSecurityPolicy.NET.Directives;
using System.Collections.Generic;

namespace Ramos.ContentSecurityPolicy.NET
{
    internal class ContentSecurityPolicyHeader
    {
        private readonly IReadOnlyCollection<Directive> _directives;
        private readonly string _nonce;

        public ContentSecurityPolicyHeader(IReadOnlyCollection<Directive> directives, string nonce)
        {
            _directives = directives;
            _nonce = nonce;
        }

        private string BuildCsp()
        {
            return _directives != null
                ? string.Join(Constants.SeparatorWithSpace, _directives)
                : string.Empty;
        }

        public override string ToString()
        {
            string csp = BuildCsp();

            if (!string.IsNullOrEmpty(_nonce))
                csp = csp.Replace(Constants.NoncePlaceholder, $"nonce-{_nonce}");

            return csp;
        }
    }
}
