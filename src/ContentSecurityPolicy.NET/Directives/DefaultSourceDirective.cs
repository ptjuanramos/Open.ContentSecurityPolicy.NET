using Microsoft.Extensions.Primitives;

namespace ContentSecurityPolicy.NET.Directives
{
    public class DefaultSourceDirective : Directive
    {

        public DefaultSourceDirective() : this("self")
        {
        }

        public DefaultSourceDirective(StringValues values) : base("default-src", values)
        {
        }
    }
}