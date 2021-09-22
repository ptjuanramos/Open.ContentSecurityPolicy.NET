# Ramos.ContentSecurityPolicy.NET

## Context
### 1. [What is Content Security Policy (CSP)](https://en.wikipedia.org/wiki/Content_Security_Policy)

> Content Security Policy (CSP) is a computer security standard introduced to prevent cross-site scripting (XSS), clickjacking and other code injection attacks resulting from execution of malicious content in the trusted web page context

> If the Content-Security-Policy header is present in the server response, a compliant client enforces the declarative whitelist policy. One example goal of a policy is a stricter execution mode for JavaScript in order to prevent certain cross-site scripting attacks.

### TODO documentation


```json
"ContentSecurityPolicy": {
    ...
    "DefaultSrc": [ "{'nonce}'", "'self'" ],
    "ScriptSrc": [ "'{nonce}'", "'self'", "cdn.js" ],
    "FrameAncestors": [],
    "PluginTypes": [],
    "ReportTo": [],
    "NavigateTo": []
    ...
  }
```


```CSHARP
namespace ContentSecurityPolicy.NET.Extensions 
{
    public static class ServiceCollectionExtensions 
    {
        public static void AddContentSecurity(this IServiceCollection services);

        public static void AddContentSecurity(this IServiceCollection services, IReadOnlyCollection<Directive> directives);
    }
}
```

```CSHARP
namespace ContentSecurityPolicy.NET.Providers 
{
    public interface INonceProvider 
    {
        public string Nonce { get; };
    }
}
```

```CSHARP
namespace ContentSecurityPolicy.NET.Providers 
{
    public abstract class NonceProvider : INonceProvider
    {
        protected abstract string GenerateNonce();
    }
}
```

```CSHARP
namespace ContentSecurityPolicy.NET.Web.Extensions 
{
    public static class CspApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseContentSecurityPolicy(this IApplicationBuilder applicationBuilder);
    }
}
```


```HTML

<script asp-with-nonce src="~/lib/jquery/dist/jquery.min.js"></script>

```
