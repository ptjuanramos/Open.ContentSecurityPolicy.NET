# Open.ContentSecurityPolicy.NET

## NuGet Packages

### <span>Open.ContentSecurityPolicy.NET</span>

[![nuget](https://img.shields.io/nuget/v/Open.ContentSecurityPolicy.NET.svg)](https://www.nuget.org/packages/Open.ContentSecurityPolicy.NET/)

### <span>Open.ContentSecurityPolicy.NET.Web</span>

[![nuget](https://img.shields.io/nuget/v/Open.ContentSecurityPolicy.NET.Web.svg)](https://www.nuget.org/packages/Open.ContentSecurityPolicy.NET.Web/)

## Context
### 1. [What is Content Security Policy (CSP)](https://en.wikipedia.org/wiki/Content_Security_Policy)

> Content Security Policy (CSP) is a computer security standard introduced to prevent cross-site scripting (XSS), clickjacking and other code injection attacks resulting from execution of malicious content in the trusted web page context.

> If the Content-Security-Policy header is present in the server response, a compliant client enforces the declarative whitelist policy. One example goal of a policy is a stricter execution mode for JavaScript in order to prevent certain cross-site scripting attacks.


### 2. How this library can help you

This library will automatically set the CSP header with the configured directives in every response. Also, `Open.ContentSecurityPolicy.Web` nuget package helps you when you want to implement CSP in you web applications, containing a tag helper that places the same nonce value in a `<script...>` or `<style...>` tags. 


### 3. Setup

**3.1 appSettings file**

Add the `ContentSecurityPolicy` element to your appSettings files.
The first children describes the content-security-policy [directives](https://content-security-policy.com/) that are named following a camel case convention.


```json
"ContentSecurityPolicy": {
    ...
    "DefaultSrc": [ "'{nonce}'", "'self'" ],
    "ScriptSrc": [ "'{nonce}'", "'self'", "cdn.js" ],
    "FrameAncestors": ["'self'"],
    "PluginTypes": ["'self'"],
    "ReportTo": ["'self'"],
    "NavigateTo": ["'self'"]
    ...
  }
```

**3.2 ConfigureServices**

```C#
services.AddContentSecurity();

//or without appSettings configuration

IReadOnlyCollection<Directive> directives = new Directive[] {
    DirectiveFactory.GetDirective(Policy.DefaultSrc, new string[] { "'{nonce}'", "'self'" }),
    DirectiveFactory.GetDirective(Policy.ScriptSrc, new string[] { "'{nonce}'", "'self'", "cdn.js" }),
    DirectiveFactory.GetDirective(Policy.FrameAncestors),
    DirectiveFactory.GetDirective(Policy.PluginTypes),
    DirectiveFactory.GetDirective(Policy.ReportTo),
    DirectiveFactory.GetDirective(Policy.NavigateTo)
};

//DirectiveFactory has two overloaded methods. When you just need to use 'self' policy in a directive, you can ignore the second argument in the GetDirective method. However, if you must use the second argument to add other policies you need to explicitly add the 'self' policy in order to use it. 

services.AddContentSecurity(directives);
```

**3.3 Middleware**

```C#
app.UseContentSecurityPolicy();
```

**3.4 Nonce value in script and style tags.**

3.4.1 Add web package assembly to your _ViewImports file.
```C#
@addTagHelper *, Open.ContentSecurityPolicy.NET.Web
```

3.4.2 Add `asp-with-nonce` attribute to your script and style tags.

```HTML
<script asp-with-nonce src="~/lib/jquery/dist/jquery.min.js"></script>
```

That's it :shrug:!

**(Optional)**
This package has a [default](https://github.com/ptjuanramos/Open.ContentSecurityPolicy.NET/blob/main/src/Open.ContentSecurityPolicy.NET/Providers/DefaultNonceProvider.cs) nonce provider. If you want to implement your own, follow these [instructions](docs/custom-nonce-provider.md).

**(Note)**
The tag helper `asp-src-include` doesn't work very well with custom tag helpers. If you want to add nonce values to your included src files, follow these [instructions](docs/asp-src-include-issue.md).

### 4. Examples

Explanation by example:

[Example. 1](examples/Example.NET.Web)

  - Imagine that you receive the following requirements:
    - Web client must receive a CSP response header with, `script-src` and `default-src` directives. 
    - Script-src directive must allow scripts tags that contains a nonce value to run.
    - Script-src must allow jquery cdn to run.
