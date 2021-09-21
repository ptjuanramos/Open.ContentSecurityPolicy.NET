using Ramos.ContentSecurityPolicy.NET.Directives;
using Ramos.ContentSecurityPolicy.NET.Directives.Resolver;
using Ramos.ContentSecurityPolicy.NET.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Ramos.ContentSecurityPolicy.NET.Tests.Helper
{
    [TestClass]
    public class ContentSecurityPolicyHelperTest
    {
        private Mock<IDirectivesResolver> _directivesResolverMock;
        private ContentSecurityPolicyHelper _contentSecurityPolicyHelper;

        [TestInitialize]
        public void SetUp()
        {
            List<Directive> directives = new()
            {
                new Directive("script-src", new string[] { "self", "nonce" }),
                new Directive("default-src", new string[] { "self", "nonce", "cdn1" })
            };

            _directivesResolverMock = new();
            _contentSecurityPolicyHelper = new(_directivesResolverMock.Object);

            _directivesResolverMock
                .Setup(directivesResolver => directivesResolver.GetDirectives())
                .Returns(directives);
        }

        [TestMethod]
        public void GetContentSecurityPolicyShouldInitializeInstanceWithTheRetrievalDirectives()
        {
            ContentSecurityPolicyHeader contentSecurityPolicyHeader = _contentSecurityPolicyHelper.GetContentSecurityPolicy("nonce-value");
            string result = contentSecurityPolicyHeader.ToString();
            Assert.AreEqual("script-src self nonce; default-src self nonce cdn1", result);
        }
    }
}
