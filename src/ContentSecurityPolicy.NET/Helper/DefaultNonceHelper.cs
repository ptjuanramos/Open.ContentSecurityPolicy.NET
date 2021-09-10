using System;
using System.Security.Cryptography;

namespace ContentSecurityPolicy.NET.Helper
{
    internal class DefaultNonceHelper : INonceHelper
    {
        public string GenerateNonce()
        {
            byte[] byteArray = new byte[20];

            using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            randomNumberGenerator.GetBytes(byteArray);

            return Convert.ToBase64String(byteArray);
        }

    }
}
