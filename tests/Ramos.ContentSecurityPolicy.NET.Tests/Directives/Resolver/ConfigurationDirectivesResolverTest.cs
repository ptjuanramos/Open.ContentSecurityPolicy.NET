using Ramos.ContentSecurityPolicy.NET.Directives;
using Ramos.ContentSecurityPolicy.NET.Directives.Resolver;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Ramos.ContentSecurityPolicy.NET.Tests.Directives.Resolver
{
    [TestClass]
    public class ConfigurationDirectivesResolverTest
    {
        #region private methods
        private static IConfiguration GetConfiguration(params KeyValuePair<string, string>[] configs)
        {
            List<KeyValuePair<string, string>> keyValuePairs = new(configs);
            keyValuePairs.Add(new KeyValuePair<string, string>("ContentSecurityPolicy", ""));

            return new ConfigurationBuilder()
                .AddInMemoryCollection(keyValuePairs)
                .Build();
        }
        #endregion

        [TestMethod]
        public void GetDirectivesMustReturnEmptyListIfIConfigurationIsNotSetup()
        {
            ConfigurationDirectivesResolver directivesResolver = new(null);
            IEnumerable<Directive> result = directivesResolver.GetDirectives();

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetDirectivesMustReturnEmptyListIfOnlyTheRootCSPElementIsConfigured()
        {
            IConfiguration onlyRootConfiguration = GetConfiguration();
            ConfigurationDirectivesResolver directivesResolver = new(onlyRootConfiguration);
            IEnumerable<Directive> result = directivesResolver.GetDirectives();

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetDirectivesMustNotTryToAddInvalidDirective()
        {
            IConfiguration onlyRootConfiguration = GetConfiguration(new KeyValuePair<string, string>("ContentSecurityPolicy:Random", ""));
            ConfigurationDirectivesResolver directivesResolver = new(onlyRootConfiguration);
            IEnumerable<Directive> result = directivesResolver.GetDirectives();

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Any());
        }

        [TestMethod]
        public void GetDirectivesMustReturnDirectivesListIfRootAndCspDirectivesAreConfigured()
        {
            IConfiguration onlyRootConfiguration = GetConfiguration(
                new KeyValuePair<string, string>("ContentSecurityPolicy:DefaultSrc:0", "self"),
                new KeyValuePair<string, string>("ContentSecurityPolicy:DefaultSrc:1", "google.com"),
                new KeyValuePair<string, string>("ContentSecurityPolicy:ScriptSrc", "")
            );

            ConfigurationDirectivesResolver directivesResolver = new(onlyRootConfiguration);
            IEnumerable<Directive> result = directivesResolver.GetDirectives();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());

            Directive defaultSrc = result.FirstOrDefault(d => d.DirectivePreffix == "default-src");
            Assert.IsNotNull(defaultSrc);
            Assert.AreEqual(2, defaultSrc.Values.Count);

            Directive scriptSrc = result.FirstOrDefault(d => d.DirectivePreffix == "script-src");
            Assert.IsNotNull(scriptSrc);
            Assert.AreEqual(1, scriptSrc.Values.Count);
            Assert.AreEqual("self", scriptSrc.Values[0]);
        }
    }
}
