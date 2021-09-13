namespace ContentSecurityPolicy.NET.Providers
{
    public abstract class NonceProvider : INonceProvider
    {
        private string _nonce = string.Empty;

        public string Nonce 
        { 
            get
            {
                if (string.IsNullOrEmpty(_nonce))
                    _nonce = GenerateNonce();

                return _nonce;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract string GenerateNonce();
    }
}