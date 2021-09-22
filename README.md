# Ramos.ContentSecurityPolicy.NET

## NuGet Packages

### <span>Ramos.ContentSecurityPolicy.NET</span>

[![nuget](https://img.shields.io/nuget/v/Ramos.ContentSecurityPolicy.NET.svg)](https://www.nuget.org/packages/Ramos.ContentSecurityPolicy.NET.Job/)

### <span>Ramos.ContentSecurityPolicy.NET.Web</span>

[![nuget](https://img.shields.io/nuget/v/Ramos.ContentSecurityPolicy.NET.Web.svg)](https://www.nuget.org/packages/Ramos.ContentSecurityPolicy.NET.Web/)

## Context
### 1. [What is Content Security Policy (CSP)](https://en.wikipedia.org/wiki/Content_Security_Policy)

> Content Security Policy (CSP) is a computer security standard introduced to prevent cross-site scripting (XSS), clickjacking and other code injection attacks resulting from execution of malicious content in the trusted web page context.

> If the Content-Security-Policy header is present in the server response, a compliant client enforces the declarative whitelist policy. One example goal of a policy is a stricter execution mode for JavaScript in order to prevent certain cross-site scripting attacks.


### 2. How this library can help you

This library will automatically set the CSP header with the configured directives in every response. Also, `Ramos.ContentSecurityPolicy.Web` nuget package helps you when you want to implement CSP in you web applications, containing a tag helper that places the same nonce value in a `<script...>` or `<style...>` tags. 


### 3. Setup

Add this JSON element in your appSettings files.

```json
"ContentSecurityPolicy": {
    ...
    "DefaultSrc": [ "'{nonce}'", "'self'" ],
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
