[![](https://img.shields.io/nuget/v/soenneker.groq.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.groq.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.groq.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.groq.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.groq.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.groq.httpclients/)

# Soenneker.Groq.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Groq.HttpClients
```

## Quick start

```csharp
using Soenneker.Groq.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddGroqOpenApiHttpClientAsSingleton();
```

Adds `GroqOpenApiHttpClient` as a singleton service.

## What you get

- `IGroqOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `GroqOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `GroqOpenApiHttpClientRegistrar.AddGroqOpenApiHttpClientAsSingleton(services)` | Adds `GroqOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `GroqOpenApiHttpClientRegistrar.AddGroqOpenApiHttpClientAsScoped(services)` | Adds `GroqOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
