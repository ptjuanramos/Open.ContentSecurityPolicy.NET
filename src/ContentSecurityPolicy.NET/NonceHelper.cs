using System;
using System.Security.Cryptography;

namespace ContentSecurityPolicy.NET
{
    public static class NonceHelper
    {
        public static string GenerateNonce()
        {
            byte[] byteArray = new byte[20];

            using (RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            randomNumberGenerator.GetBytes(byteArray);

            return Convert.ToBase64String(byteArray);
        }

    }
}
