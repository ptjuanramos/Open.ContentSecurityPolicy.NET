using System;
using System.Security.Cryptography;

namespace ContentSecurityPolicy.NET.Helper
{
    /// <summary>
    /// 
    /// </summary>
    internal class DefaultNonceHelper : NonceHelper
    {
        protected override string GenerateNonce()
        {
            byte[] byteArray = new byte[20];

            using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
                randomNumberGenerator.GetBytes(byteArray);

            return Convert.ToBase64String(byteArray);
        }
    }
}
