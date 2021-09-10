namespace ContentSecurityPolicy.NET.Helper
{
    internal interface IContentSecurityPolicyHelper
    {
        ContentSecurityPolicyHeader GetContentSecurityPolicy(string nonce);
    }
}
