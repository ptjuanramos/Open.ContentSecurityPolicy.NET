using Open.ContentSecurityPolicy.NET.Directives;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Open.ContentSecurityPolicy.NET.Tests.Directives
{
    [TestClass]
    public class DirectiveTests
    {
        [TestMethod]
        public void ConstructorShouldInitializeListValues()
        {
            Directive directive = new Directive("script-src", "");
            Assert.IsNotNull(directive.Values);
        }

        [TestMethod]
        public void ConstructorWithoutArgumentsShouldAddSelfDirective()
        {
            Directive directive = new Directive("script-src");

            Assert.AreEqual(1, directive.Values.Count);
            Assert.AreEqual("'self'", directive.Values[0]);
        }

        [TestMethod]
        public void ConstructorWithSingleValueShouldAddValueToList()
        {
            Directive directive = new Directive("script-src", "single-value");

            Assert.AreEqual(1, directive.Values.Count);
            Assert.AreEqual("single-value", directive.Values[0]);
        }

        [TestMethod]
        public void ConstructorWithMultipleValuesShouldAddValuesToList()
        {
            StringValues values = new string[] { "value-1", "value-2", "value-3" };
            Directive directive = new Directive("script-src", values);

            Assert.AreEqual(values.Count, directive.Values.Count);
            Assert.AreEqual(values[0], directive.Values[0]);
            Assert.AreEqual(values[1], directive.Values[1]);
            Assert.AreEqual(values[2], directive.Values[2]);
        }

        [TestMethod]
        public void ToStringShouldContainDefaultSrcDirective()
        {
            Directive directive = new Directive("script-src", "single-value");
            Assert.IsTrue(directive.ToString().Contains("script-src"));
        }

        [TestMethod]
        public void WithoutArgumentsInTheConstructorToStringShouldContainSelfDirective()
        {
            Directive directive = new Directive("script-src");

            Assert.AreEqual($"script-src 'self'", directive.ToString());
        }

        [TestMethod]
        public void WithArgumentsInTheConstructorToStringShouldContainAllValues()
        {
            StringValues values = new string[] { "value-1", "value-2", "value-3" };
            Directive directive = new Directive("script-src", values);

            Assert.AreEqual($"script-src {values[0]} {values[1]} {values[2]}", directive.ToString());
        }
    }
}
