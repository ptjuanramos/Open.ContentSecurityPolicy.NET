using Ramos.ContentSecurityPolicy.NET.Extensions;
using Microsoft.Extensions.Primitives;

namespace Ramos.ContentSecurityPolicy.NET.Directives
{
    public class DirectiveFactory
    {
        public static Directive GetDirective(Policy policy) => new(policy.GetPreffix());

        public static Directive GetDirective(Policy policy, StringValues values) => new(policy.GetPreffix(), values);
    }
}
