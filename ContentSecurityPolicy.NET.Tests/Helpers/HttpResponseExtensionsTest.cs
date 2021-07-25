using ContentSecurityPolicy.NET.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ContentSecurityPolicy.NET.Tests.Helpers
{
    [TestClass]
    public class HttpResponseExtensionsTest
    {
        [TestMethod]
        public void AddCSPHeaderMustAddHeaderValueToHttpResponse()
        {
            HeaderDictionaryStub headerDictionary = new();
            Mock<HttpResponse> mockedHttpResponse = new();

            mockedHttpResponse.SetupGet(httpResponse => httpResponse.Headers).Returns(headerDictionary);

            HttpResponseExtensions.AddCSPHeader(mockedHttpResponse.Object, "nonce-value");

            Assert.IsTrue(headerDictionary.ContainsKey("Content-Security-Policy"));
        }
    }
}
