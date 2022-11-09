namespace Open.ContentSecurityPolicy.NET.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public interface INonceProvider
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Nonce { get; }
    }
}
