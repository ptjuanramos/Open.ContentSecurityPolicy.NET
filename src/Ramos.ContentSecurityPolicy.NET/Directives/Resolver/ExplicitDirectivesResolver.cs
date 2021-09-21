using System.Collections.Generic;

namespace Ramos.ContentSecurityPolicy.NET.Directives.Resolver
{
    internal class ExplicitDirectivesResolver : IDirectivesResolver
    {
        private readonly IReadOnlyCollection<Directive> _directives;

        public ExplicitDirectivesResolver(IReadOnlyCollection<Directive> directives)
        {
            _directives = directives;
        }

        public IReadOnlyCollection<Directive> GetDirectives() => _directives ?? new List<Directive>();
    }
}
