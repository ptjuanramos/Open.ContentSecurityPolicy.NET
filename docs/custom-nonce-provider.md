# Implement your own NonceProvider

This package uses a [`DefaultNonceProvider`](../src/Open.ContentSecurityPolicy.NET/Providers/DefaultNonceProvider.cs) class as a default, you know... default nonce provider.

The default nonce provider uses a 20 bytes array and a `System.Security.Cryptography` class to generate a nonce in every request. But you probably want to implement your nonce provider.

1) Extend your custom nonce provider class with `NonceProvider` abstract class and implement the logic to create a nonce value at `GenerateNonce()` method:

```CSHARP

class CustomNonceProvider : NonceProvider 
{

    protected override string GenerateNonce() 
    {
        string nonce = //logic 
        ...
        return nonce;
    }

}

```

2) Regist your `CustomNonceProvider` in the `ServiceCollection` by using the `INonceProvider` interface:

```CSHARP

services.AddScoped<INonceProvider, CustomNonceProvider>();

```

Notes:

1) Regist your custom nonce provider with scoped service life time.