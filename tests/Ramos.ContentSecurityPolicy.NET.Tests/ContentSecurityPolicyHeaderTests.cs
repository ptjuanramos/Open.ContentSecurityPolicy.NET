using Ramos.ContentSecurityPolicy.NET.Directives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Ramos.ContentSecurityPolicy.NET.Tests
{
    [TestClass]
    public class ContentSecurityPolicyHeaderTests
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
                DirectiveFactory.GetDirective(Policy.DefaultSrc, new string[] { "self", "cdn" }),
                DirectiveFactory.GetDirective(Policy.ScriptSrc)
            };

            ContentSecurityPolicyHeader contentSecurityPolicyHeader = new(directives, NonceValue);
            Assert.AreEqual("default-src self cdn; script-src self", contentSecurityPolicyHeader.ToString());
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
            Assert.AreEqual($"default-src nonce-{NonceValue} self; script-src nonce-{NonceValue} self", contentSecurityPolicyHeader.ToString());
        }
    }
}
