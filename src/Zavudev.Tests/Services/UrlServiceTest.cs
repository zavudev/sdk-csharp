using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class UrlServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Escalate_Works()
    {
        var response = await this.client.Urls.Escalate(
            "urlId",
            new() { Reason = "This is our official landing page and was rejected in error." },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListVerified_Works()
    {
        var page = await this.client.Urls.ListVerified(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveDetails_Works()
    {
        var response = await this.client.Urls.RetrieveDetails(
            "urlId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task SubmitForVerification_Works()
    {
        var response = await this.client.Urls.SubmitForVerification(
            new() { UrlValue = "https://example.com/page" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
