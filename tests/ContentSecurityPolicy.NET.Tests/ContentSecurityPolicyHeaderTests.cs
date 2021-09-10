using ContentSecurityPolicy.NET.Directives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ContentSecurityPolicy.NET.Tests
{
    class ContentSecurityPolicyHeaderTests
    {
        private const string NonceValue = "nonce-value";

        [TestMethod]
        public void ToStringMustReturnEmptyStringIfDirectivesListAreNull()
        {
            ContentSecurityPolicyHeader contentSecurityPolicyHeader = new(null, NonceValue);
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

            ContentSecurityPolicyHeader contentSecurityPolicyHeader = new(directives, NonceValue);
            Assert.AreEqual("default-src self; script-src self;", contentSecurityPolicyHeader.ToString());
        }

        [TestMethod]
        public void ToStringMustReplaceDirectiveNoncePlaceholder()
        {
            List<Directive> directives = new()
            {
                DirectiveFactory.GetDirective(Policy.DefaultSrc, new string[] { "{nonce}", "self" }),
                DirectiveFactory.GetDirective(Policy.ScriptSrc, new string[] { "{nonce}", "self" })
            };

            ContentSecurityPolicyHeader contentSecurityPolicyHeader = new(directives, NonceValue);
            Assert.AreEqual($"default-src {NonceValue} self; script-src {NonceValue} self;", contentSecurityPolicyHeader.ToString());
        }
    }
}
