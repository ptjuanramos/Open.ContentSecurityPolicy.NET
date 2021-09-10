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
        public readonly string DirectivePreffix;

        internal Directive(string directivePreffix): this(directivePreffix, "self")
        {
        }

        internal Directive(string directivePreffix, StringValues values)
        {
            DirectivePreffix = directivePreffix;
            Values = new List<string>(values);
        }

        public override string ToString()
        {
            return $"{DirectivePreffix} {string.Join(Constants.SeparatorWithSpace, Values)}";
        }
    }
}
