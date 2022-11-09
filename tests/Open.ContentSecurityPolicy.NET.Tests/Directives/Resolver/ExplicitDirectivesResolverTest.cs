using Open.ContentSecurityPolicy.NET.Directives;
using Open.ContentSecurityPolicy.NET.Directives.Resolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Open.ContentSecurityPolicy.NET.Tests.Directives.Resolver
{
    [TestClass]
    public class ExplicitDirectivesResolverTest
    {
        [TestMethod]
        public void GetDirectivesMustResturnEmptyListIfConstructorArgumentIsNull()
        {
            ExplicitDirectivesResolver explicitDirectivesResolver = new ExplicitDirectivesResolver(null);
            IReadOnlyCollection<Directive> directives = explicitDirectivesResolver.GetDirectives();

            Assert.IsNotNull(directives);
            Assert.IsFalse(directives.Any());
        }

        [TestMethod]
        public void GetDirectivesMustResturnTheSameListThatWasPassedToConstructor()
        {
            List<Directive> directives = new List<Directive>()
            {
                new Directive("default-src")
            };

            ExplicitDirectivesResolver explicitDirectivesResolver = new ExplicitDirectivesResolver(directives);
            IReadOnlyCollection<Directive> result = explicitDirectivesResolver.GetDirectives();

            CollectionAssert.AreEquivalent(directives, result.ToList());
        }
    }
}
