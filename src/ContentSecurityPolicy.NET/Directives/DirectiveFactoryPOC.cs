using ContentSecurityPolicy.NET.Directives;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContentSecurityPolicy.NET.Directives
{
    public class DirectiveFactoryPOC
    {
        public Directive GetDirective(Policy policy, StringValues values)
        {
            return policy switch
            {
                Policy.DefaultSrc => new Directive("default-src", values),
                Policy.ScriptSrc => new Directive("script-src", values),
                _ => null,
            };
        }
    }
}
