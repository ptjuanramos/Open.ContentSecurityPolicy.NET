namespace ContentSecurityPolicy.NET.Helper
{
    public abstract class NonceHelper : INonceHelper
    {
        private readonly string _nonce;

        public NonceHelper()
        {
            _nonce = GenerateNonce();
        }

        public string GetNonce() => _nonce;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract string GenerateNonce();
    }
}