using ContentSecurityPolicy.NET.Directives;
using ContentSecurityPolicy.NET.Directives.Resolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace ContentSecurityPolicy.NET.Tests.Directives.Resolver
{
    [TestClass]
    public class ExplicitDirectivesResolverTest
    {
        [TestMethod]
        public void GetDirectivesMustResturnEmptyListIfConstructorArgumentIsNull()
        {
            ExplicitDirectivesResolver explicitDirectivesResolver = new(null);
            IReadOnlyCollection<Directive> directives = explicitDirectivesResolver.GetDirectives();

            Assert.IsNotNull(directives);
            Assert.IsFalse(directives.Any());
        }

        [TestMethod]
        public void GetDirectivesMustResturnTheSameListThatWasPassedToConstructor()
        {
            List<Directive> directives = new()
            {
                new Directive("default-src")
            };

            ExplicitDirectivesResolver explicitDirectivesResolver = new(directives);
            IReadOnlyCollection<Directive> result = explicitDirectivesResolver.GetDirectives();

            CollectionAssert.AreEquivalent(directives, result.ToList());
        }
    }
}
