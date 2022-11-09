using System;
using System.Security.Cryptography;

namespace Open.ContentSecurityPolicy.NET.Providers
{
    /// <summary>
    /// 
    /// </summary>
    internal class DefaultNonceProvider : NonceProvider
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
