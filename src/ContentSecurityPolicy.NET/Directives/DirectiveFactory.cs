using ContentSecurityPolicy.NET.Directives;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentSecurityPolicy.NET.Directives
{
    public class DirectiveFactory
    {
        public static Directive GetDirective(Policy policy) => new(policy.GetPreffix());

        public static Directive GetDirective(Policy policy, StringValues values) => new(policy.GetPreffix(), values);
    }
}
