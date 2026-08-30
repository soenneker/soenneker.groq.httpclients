[![](https://img.shields.io/nuget/v/soenneker.groq.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.groq.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.groq.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.httpclients/build-and-test.yml?style=for-the-badge&label=build)](https://github.com/soenneker/soenneker.groq.httpclients/actions/workflows/build-and-test.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.httpclients/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.groq.httpclients/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.groq.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.groq.httpclients/)

# Soenneker.Groq.HttpClients

Provides a cached `HttpClient` configured for Groq's OpenAI-compatible API, including its base address and authentication header.

## Installation

```bash
dotnet add package Soenneker.Groq.HttpClients
```

## Configuration

```json
{
  "Groq": {
    "ApiKey": "gsk_..."
  }
}
```

Requests use `https://api.groq.com` by default. These optional settings override the endpoint or authentication format:

```json
{
  "Groq": {
    "ClientBaseUrl": "https://api.groq.com",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

`{token}` is replaced with `Groq:ApiKey` when the client is created.

## Registration and usage

```csharp
using Soenneker.Groq.HttpClients.Abstract;
using Soenneker.Groq.HttpClients.Registrars;

services.AddGroqOpenApiHttpClientAsSingleton();

IGroqOpenApiHttpClient provider =
    serviceProvider.GetRequiredService<IGroqOpenApiHttpClient>();

HttpClient client = await provider.Get(cancellationToken);
HttpResponseMessage response = await client.GetAsync("/openai/v1/models", cancellationToken);
response.EnsureSuccessStatusCode();
```

`Get()` reuses the same cached client for the provider's lifetime. Dispose the provider, not the returned client, when you own the provider.

`AddGroqOpenApiHttpClientAsScoped()` is available when each dependency-injection scope should own and release an independent cached client. Consumers such as a scoped API utility can instead use the singleton registration to keep the transport alive across utility scopes.
