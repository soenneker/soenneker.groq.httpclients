using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Groq.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Groq.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class GroqOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IGroqOpenApiHttpClient"/> and its client cache as singleton services.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddGroqOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IGroqOpenApiHttpClient, GroqOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IGroqOpenApiHttpClient"/> and its client cache as scoped services.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddGroqOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsScoped()
                .TryAddScoped<IGroqOpenApiHttpClient, GroqOpenApiHttpClient>();

        return services;
    }
}
