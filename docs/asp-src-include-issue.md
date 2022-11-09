# Using asp-src-include

ScriptTagHelper asp-src-include doesn't render custom tags, thus it will not render `asp-with-nonce`.

For example:

Having script1, script2 and script3 js files in the app/js folder.

```html
<script asp-with-nonce src="~/app/**/*.js"></script>
```

The result html is:

```html
<script src="~/app/js/script1.js"></script>
<script src="~/app/js/script2.js"></script>
<script src="~/app/js/script3.js"></script>
```

In order to solve this problem, tag helper is not the solution. You need to inject the `INonceProvider` service.

For example:

```HTML
@using Open.ContentSecurityPolicy.NET.Providers
@inject INonceProvider NonceProvider

<script nonce="@NonceProvider.Nonce" src="~/app/**/*.js" />
```

The result html is:

```html
<script nonce="[nonce-value]" src="~/app/js/script1.js"></script>
<script nonce="[nonce-value]" src="~/app/js/script2.js"></script>
<script nonce="[nonce-value]" src="~/app/js/script3.js"></script>
```