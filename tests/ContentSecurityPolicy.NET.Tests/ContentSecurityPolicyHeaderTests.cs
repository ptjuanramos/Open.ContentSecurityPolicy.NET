using ContentSecurityPolicy.NET.Directives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ContentSecurityPolicy.NET.Tests
{
    class ContentSecurityPolicyHeaderTests
    {
        [TestMethod]
        public void ToStringMustReturnEmptyStringIfDirectivesListAreNull()
        {
            ContentSecurityPolicyHeader contentSecurityPolicyHeader = new(null);
            Assert.AreEqual(string.Empty, contentSecurityPolicyHeader.ToString());
        }

        [TestMethod]
        public void ToStringMustReturnConcatenatedDirectivesIfDirectivesListAreNotNull()
        {
            List<Directive> directives = new()
            {
                DirectiveFactory.GetDirective(Policy.DefaultSrc),
                DirectiveFactory.GetDirective(Policy.ScriptSrc)
            };

            ContentSecurityPolicyHeader contentSecurityPolicyHeader = new(directives);
            Assert.AreEqual("default-src self; script-src self;", contentSecurityPolicyHeader.ToString());
        }
    }
}
