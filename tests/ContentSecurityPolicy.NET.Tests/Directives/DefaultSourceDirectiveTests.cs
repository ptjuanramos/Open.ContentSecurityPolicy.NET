using ContentSecurityPolicy.NET.Directives;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentSecurityPolicy.NET.Tests.Directives
{
    [TestClass]
    public class DefaultSourceDirectiveTests
    {
        [TestMethod]
        public void ConstructorShouldInitializeListValues()
        {
            DefaultSourceDirective defaultSourceDirective = new();
            Assert.IsNotNull(defaultSourceDirective.Values);
        }

        [TestMethod]
        public void ConstructorWithoutArgumentsShouldAddSelfDirective()
        {
            DefaultSourceDirective defaultSourceDirective = new();

            Assert.AreEqual(1, defaultSourceDirective.Values.Count);
            Assert.AreEqual("self", defaultSourceDirective.Values[0]);
        }

        [TestMethod]
        public void ConstructorWithSingleValueShouldAddValueToList()
        {
            DefaultSourceDirective defaultSourceDirective = new("single-value");

            Assert.AreEqual(1, defaultSourceDirective.Values.Count);
            Assert.AreEqual("single-value", defaultSourceDirective.Values[0]);
        }

        [TestMethod]
        public void ConstructorWithMultipleValuesShouldAddValuesToList()
        {
            StringValues values = new string[] { "value-1", "value-2", "value-3" };
            DefaultSourceDirective defaultSourceDirective = new(values);

            Assert.AreEqual(values.Count, defaultSourceDirective.Values.Count);
            Assert.AreEqual(values[0], defaultSourceDirective.Values[0]);
            Assert.AreEqual(values[1], defaultSourceDirective.Values[1]);
            Assert.AreEqual(values[2], defaultSourceDirective.Values[2]);
        }

        [TestMethod]
        public void ToStringShouldContainDefaultSrcDirective()
        {
            DefaultSourceDirective defaultSourceDirective = new();
            
            string directive = defaultSourceDirective.ToString();

            Assert.IsTrue(directive.ToString().Contains("default-src"));
        }

        [TestMethod]
        public void WithoutArgumentsInTheConstructorToStringShouldContainSelfDirective()
        {
            DefaultSourceDirective defaultSourceDirective = new();
                
            string directive = defaultSourceDirective.ToString();

            Assert.IsTrue(directive.ToString().Contains("default-src"));
            Assert.IsTrue(directive.ToString().Contains("self"));
        }

        [TestMethod]
        public void WithArgumentsInTheConstructorToStringShouldContainAllValues()
        {
            StringValues values = new string[] { "value-1", "value-2", "value-3" };
            DefaultSourceDirective defaultSourceDirective = new(values);

            string directive = defaultSourceDirective.ToString();

            Assert.AreEqual($"default-src {values[0]}; {values[1]}; {values[2]}", directive);
        }
    }
}
