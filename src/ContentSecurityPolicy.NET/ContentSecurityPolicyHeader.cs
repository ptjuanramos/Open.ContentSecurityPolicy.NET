using ContentSecurityPolicy.NET.Directives;
using System.Collections.Generic;

namespace ContentSecurityPolicy.NET
{
    public class ContentSecurityPolicyHeader
    {
        private readonly IReadOnlyCollection<Directive> _directives;

        public ContentSecurityPolicyHeader(IReadOnlyCollection<Directive> directives)
        {
            _directives = directives;
        }

        public override string ToString()
        {
            return _directives != null 
                ? string.Join(Directive.SeparatorWithSpace, _directives) 
                : string.Empty;
        }
    }
}
