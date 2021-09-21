using System.Collections.Generic;

namespace Ramos.ContentSecurityPolicy.NET.Directives.Resolver
{
    public interface IDirectivesResolver
    {
        IReadOnlyCollection<Directive> GetDirectives();
    }
}