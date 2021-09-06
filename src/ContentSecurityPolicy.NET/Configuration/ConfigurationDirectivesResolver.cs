using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentSecurityPolicy.NET.Configuration
{
    internal class ConfigurationDirectivesResolver : IConfigurationDirectivesResolver
    {
        private readonly IConfiguration _configuration;

        public ConfigurationDirectivesResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        internal string GetDirectives()
        {
            return string.Empty;
        }
    }
}
