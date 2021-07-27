using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace ContentSecurityPolicy.NET.Directives
{
    public class DefaultSourceDirective
    {
        public IList<string> Values { get; internal set; }

        public DefaultSourceDirective() : this("self")
        {
            
        }

        public DefaultSourceDirective(StringValues values)
        {
            Values = new List<string>(values);
        }

        public override string ToString()
        {
            return $"default-src {string.Join("; ", Values)}";
        }
    }
}