using ContentSecurityPolicy.NET.Helper;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace ContentSecurityPolicy.NET.Web.TagHelpers
{
    /// <summary>
    /// 
    /// </summary>
    [HtmlTargetElement("script", Attributes = "asp-with-nonce")]
    [HtmlTargetElement("style", Attributes = "asp-with-nonce")]
    public class CSPTagHelper : TagHelper
    {
        private readonly INonceHelper _nonceHelper;

        public CSPTagHelper(INonceHelper nonceHelper)
        {
            _nonceHelper = nonceHelper;
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string nonce = _nonceHelper.GetNonce(); //TODO

            if (!string.IsNullOrEmpty(nonce))
            {
                output.Attributes.Add(new TagHelperAttribute("nonce", nonce));
            }

            return base.ProcessAsync(context, output);
        }
    }
}
