using System.Collections.Generic;

namespace Neo.ContentSecurityPolicy.NET.Directives.Resolver
{
    public interface IDirectivesResolver
    {
        IReadOnlyCollection<Directive> GetDirectives();
    }
}