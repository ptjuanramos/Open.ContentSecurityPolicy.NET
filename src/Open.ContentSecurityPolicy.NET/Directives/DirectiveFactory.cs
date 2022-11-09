using Open.ContentSecurityPolicy.NET.Extensions;
using Microsoft.Extensions.Primitives;

namespace Open.ContentSecurityPolicy.NET.Directives
{
    public class DirectiveFactory
    {
        public static Directive GetDirective(Policy policy) => new Directive(policy.GetPreffix());

        public static Directive GetDirective(Policy policy, StringValues values) => new Directive(policy.GetPreffix(), values);
    }
}
