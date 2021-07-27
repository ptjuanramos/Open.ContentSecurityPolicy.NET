using ContentSecurityPolicy.NET.Directives;

namespace ContentSecurityPolicy.NET
{
    public class ContentSecurityPolicyHeader
    {
        public DefaultSourceDirective DefaultSrc { get; private set; }

        internal ContentSecurityPolicyHeader(DefaultSourceDirective defaultSrc)
        {
            DefaultSrc = defaultSrc;
        }
    }
}
