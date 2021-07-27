using ContentSecurityPolicy.NET.Directives;
using System;

namespace ContentSecurityPolicy.NET
{
    public class ContentSecurityPolicyHeaderBuilder
    {
        private DefaultSourceDirective DefaultSrc { get; set; }

        public ContentSecurityPolicyHeader Build()
        {
            return new ContentSecurityPolicyHeader(DefaultSrc);
        }

        internal ContentSecurityPolicyHeaderBuilder AddDefaultSrc(DefaultSourceDirective defaultSrc)
        {
            DefaultSrc = defaultSrc;
            return this;
        }
    }
}