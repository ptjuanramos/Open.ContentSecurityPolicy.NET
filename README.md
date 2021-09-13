# ContentSecurityPolicy.NET

### TODO documentation


```json
"ContentSecurityPolicy": {
    ...
    "DefaultSrc": [ "{nonce}", "self" ],
    "ScriptSrc": [ "{nonce}", "self", "cdn.js" ],
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