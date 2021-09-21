using Ramos.ContentSecurityPolicy.NET.Providers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Ramos.ContentSecurityPolicy.NET.Web.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    [HtmlTargetElement("script", Attributes = "asp-with-nonce")]
    [HtmlTargetElement("style", Attributes = "asp-with-nonce")]
    public class NonceTagHelper : TagHelper
    {
        private readonly INonceProvider _nonceProvider;

        public NonceTagHelper(INonceProvider nonceProvider)
        {
            _nonceProvider = nonceProvider;
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string nonce = _nonceProvider.Nonce;

            if (!string.IsNullOrEmpty(nonce))
            {
                output.Attributes.Add(new TagHelperAttribute("nonce", nonce));
            }

            return base.ProcessAsync(context, output);
        }
    }
}
