using ContentSecurityPolicy.NET.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentSecurityPolicy.NET.Tests.Configuration
{
    [TestClass]
    public class ConfigurationDirectivesResolverTest
    {
        [TestMethod]
        public void GetDirectivesReturnEmptyStringIfIConfigurationIsNotSetup()
        {
            ConfigurationDirectivesResolver directivesResolver = new(null);
            string result = directivesResolver.GetDirectives();
            Assert.AreEqual(string.Empty, result);
        }
    }
}
