using System.Collections.Generic;

namespace Open.ContentSecurityPolicy.NET.Directives.Resolver
{
    public interface IDirectivesResolver
    {
        IReadOnlyCollection<Directive> GetDirectives();
    }
}