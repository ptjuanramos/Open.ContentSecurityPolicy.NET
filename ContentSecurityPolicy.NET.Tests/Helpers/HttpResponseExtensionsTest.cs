using ContentSecurityPolicy.NET.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContentSecurityPolicy.NET.Tests.Helpers
{
    [TestClass]
    public class HttpResponseExtensionsTest
    {

        private readonly HeaderDictionaryStub headerDictionary = new();
        private readonly HttpContextStub httpContext = new();

        private readonly Mock<HttpResponse> mockedHttpResponse = new();

        [TestInitialize]
        public void SetUp()
        {
            mockedHttpResponse.SetupGet(httpResponse => httpResponse.Headers).Returns(headerDictionary);
            mockedHttpResponse.SetupGet(httpResponse => httpResponse.HttpContext).Returns(httpContext);
        }

        [TestMethod]
        public void AddCSPHeaderMustAddHeaderValueToHttpResponse()
        {
            HttpResponseExtensions.AddCSPHeader(mockedHttpResponse.Object, "nonce-value");

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
