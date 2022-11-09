using Open.ContentSecurityPolicy.NET.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Open.ContentSecurityPolicy.NET.Tests.Extensions
{
    [TestClass]
    public class HttpResponseExtensionsTest
    {

        private readonly HeaderDictionaryStub headerDictionary = new HeaderDictionaryStub();
        private readonly HttpContextStub httpContext = new HttpContextStub();

        private readonly Mock<HttpResponse> mockedHttpResponse = new Mock<HttpResponse>();

        [TestInitialize]
        public void SetUp()
        {
            mockedHttpResponse.SetupGet(httpResponse => httpResponse.Headers).Returns(headerDictionary);
            mockedHttpResponse.SetupGet(httpResponse => httpResponse.HttpContext).Returns(httpContext);
        }

        [TestMethod]
        public void AddCSPHeaderMustAddHeaderValueToHttpResponse()
        {
            HttpResponseExtensions.AddCSPHeader(mockedHttpResponse.Object, new ContentSecurityPolicyHeader(null, "nonce-value"));

            Assert.IsTrue(headerDictionary.ContainsKey("Content-Security-Policy"));
        }

        [TestMethod]
        public void AddNonceToResponseItemsMustAddNonceToHttpContextItems()
        {
            HttpResponseExtensions.AddNonceToResponseItems(mockedHttpResponse.Object, "nonce-value");

            Assert.IsTrue(httpContext.Items.ContainsKey("nonce"));
        }
    }
}
