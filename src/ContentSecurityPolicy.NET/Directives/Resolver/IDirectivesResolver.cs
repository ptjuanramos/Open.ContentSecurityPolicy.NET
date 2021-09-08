using System.Collections.Generic;

namespace ContentSecurityPolicy.NET.Directives.Resolver
{
    public interface IDirectivesResolver
    {
        IReadOnlyCollection<Directive> GetDirectives();
    }
}