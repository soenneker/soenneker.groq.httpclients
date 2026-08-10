using Soenneker.Groq.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

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
}
