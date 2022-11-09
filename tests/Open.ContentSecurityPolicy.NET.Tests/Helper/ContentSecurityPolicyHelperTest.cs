using Open.ContentSecurityPolicy.NET.Directives;
using Open.ContentSecurityPolicy.NET.Directives.Resolver;
using Open.ContentSecurityPolicy.NET.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Open.ContentSecurityPolicy.NET.Tests.Helper
{
    [TestClass]
    public class ContentSecurityPolicyHelperTest
    {
        private Mock<IDirectivesResolver> _directivesResolverMock;
        private ContentSecurityPolicyHelper _contentSecurityPolicyHelper;

        [TestInitialize]
        public void SetUp()
        {
            List<Directive> directives = new List<Directive>()
            {
                new Directive("script-src", new string[] { "self", "nonce" }),
                new Directive("default-src", new string[] { "self", "nonce", "cdn1" })
            };

            _directivesResolverMock = new Mock<IDirectivesResolver>();
            _contentSecurityPolicyHelper = new ContentSecurityPolicyHelper(_directivesResolverMock.Object);

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
