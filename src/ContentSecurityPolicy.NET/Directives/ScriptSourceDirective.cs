using Microsoft.Extensions.Primitives;

namespace ContentSecurityPolicy.NET.Directives
{
    public class ScriptSourceDirective : Directive
    {
        public ScriptSourceDirective() : this("self")
        {
        }

        public ScriptSourceDirective(StringValues values) : base("script-src", values)
        {
        }
    }
}
