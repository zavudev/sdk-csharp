using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Functions;

public class GitLinkServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var gitLink = await this.client.Functions.GitLink.Retrieve(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
        gitLink.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var gitLink = await this.client.Functions.GitLink.Update(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
        gitLink.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DeployNow_Works()
    {
        var response = await this.client.Functions.GitLink.DeployNow(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Link_Works()
    {
        var response = await this.client.Functions.GitLink.Link(
            "functionId",
            new() { Owner = "acme", Repo = "order-bot" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Unlink_Works()
    {
        await this.client.Functions.GitLink.Unlink(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
