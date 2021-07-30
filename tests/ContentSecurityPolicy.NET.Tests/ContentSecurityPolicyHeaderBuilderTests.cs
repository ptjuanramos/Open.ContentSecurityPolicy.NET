using ContentSecurityPolicy.NET.Directives;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContentSecurityPolicy.NET.Tests
{
    [TestClass]
    public class ContentSecurityPolicyHeaderBuilderTests
    {
        private ContentSecurityPolicyHeaderBuilder builder;

        [TestInitialize]
        public void SetUp()
        {
            builder = new();
        }

        [TestMethod]
        public void BuildShouldReturnContentSecurityPolicyHeaderInstance()
        {
            ContentSecurityPolicyHeader contentSecurityPolicyHeader = builder.Build();
            Assert.IsNotNull(contentSecurityPolicyHeader);
        }

    //    [TestMethod]
    //    public void AddDefaultSrcShouldAddDefaultSrcDirective()
    //    {
    //        DefaultSourceDirective defaultSourceDirective = new();
            
    //        builder.AddDefaultSrc(defaultSourceDirective);
    //        ContentSecurityPolicyHeader contentSecurityPolicyHeader = builder.Build();

    //        Assert.IsNotNull(contentSecurityPolicyHeader.DefaultSrc);
    //        Assert.AreSame(defaultSourceDirective, contentSecurityPolicyHeader.DefaultSrc);
    //    }
    }
}
