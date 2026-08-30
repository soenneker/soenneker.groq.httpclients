using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Groq.HttpClients.Abstract;

/// <summary>
/// Provides a cached <see cref="HttpClient"/> configured for Groq's OpenAI-compatible API.
/// </summary>
public interface IGroqOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the configured HTTP client. Repeated calls within this provider's lifetime return the cached instance.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The configured Groq HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
