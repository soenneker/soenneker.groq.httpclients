using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Groq.HttpClients.Abstract;
using Soenneker.Groq.HttpClients.Registrars;
using Soenneker.Tests.HostedUnit;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.Groq.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class GroqOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IGroqOpenApiHttpClient _httpclient;

    public GroqOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IGroqOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }

    [Test]
    public async Task Scoped_registration_owns_an_independent_cache()
    {
        var services = new ServiceCollection();

        services.AddGroqOpenApiHttpClientAsScoped();

        ServiceDescriptor cache = services.Single(descriptor => descriptor.ServiceType == typeof(IHttpClientCache));
        ServiceDescriptor client = services.Single(descriptor => descriptor.ServiceType == typeof(IGroqOpenApiHttpClient));

        await Assert.That(cache.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
        await Assert.That(client.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
    }
}
