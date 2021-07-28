using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace ContentSecurityPolicy.NET.Directives
{
    /// <summary>
    /// Class inspired from <see cref="https://github.com/erwindevreugd/ContentSecurityPolicy">this project</see>
    /// </summary>
    public class Directive
    {
        public IList<string> Values { get; internal set; }

        private readonly string _directivePreffix;

        public Directive(string directivePreffix, StringValues values)
        {
            _directivePreffix = directivePreffix;
            Values = new List<string>(values);
        }

        public override string ToString()
        {
            return $"{_directivePreffix} {string.Join("; ", Values)}";
        }
    }
}
