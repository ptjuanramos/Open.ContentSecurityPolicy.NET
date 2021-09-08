# ContentSecurityPolicy.NET

### TODO documentation


```json
"ContentSecurityPolicy": {
    ...
    "DefaultSrc": [],
    "ScriptSrc": [],
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
        public string GenerateNonce();
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