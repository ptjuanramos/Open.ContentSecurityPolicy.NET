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
namespace ContentSecurityPolicy.NET.Helper 
{
    public interface INonceHelper {
        public string GetNonce();
    }
}
```

```CSHARP
namespace ContentSecurityPolicy.NET.Helper 
{
    public abstract class NonceHelper : INonceHelper
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