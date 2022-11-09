using Open.ContentSecurityPolicy.NET.Extensions;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Open.ContentSecurityPolicy.NET.Directives.Resolver
{
    internal class ConfigurationDirectivesResolver : IDirectivesResolver
    {
        private const string ConfigurationKey = "ContentSecurityPolicy";

        private readonly IConfiguration _configuration;

        public ConfigurationDirectivesResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IReadOnlyCollection<Directive> GetDirectives()
        {
            IConfigurationSection cspSection = _configuration?.GetSection(ConfigurationKey);
            if (cspSection == null)
                return new List<Directive>();

            IEnumerable<IConfigurationSection> directivesSections = cspSection.GetChildren();

            return MapToDirectives(directivesSections);
        }

        #region private methods
        private static IReadOnlyCollection<Directive> MapToDirectives(IEnumerable<IConfigurationSection> directivesSections)
        {
            List<Directive> directives = new List<Directive>();

            foreach (IConfigurationSection section in directivesSections)
            {
                Policy policy = section.Key.GetPolicy();
                if (policy == Policy.None)
                    continue;

                Directive directive;

                string[] directiveValues = section.Get<string[]>();
                
                if(directiveValues == null || directiveValues.Length == 0)
                {
                    directive = DirectiveFactory.GetDirective(policy);
                } 
                else
                {
                    directive = DirectiveFactory.GetDirective(policy, directiveValues);
                }
                    

                directives.Add(directive);
            }

            return directives;
        }
        #endregion
    }
}
