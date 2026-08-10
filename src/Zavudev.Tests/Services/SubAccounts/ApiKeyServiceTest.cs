using System.Threading.Tasks;

namespace Zavudev.Tests.Services.SubAccounts;

public class ApiKeyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var apiKey = await this.client.SubAccounts.ApiKeys.Create(
            "id",
            new() { Name = "Production Key" },
            TestContext.Current.CancellationToken
        );
        apiKey.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var apiKeys = await this.client.SubAccounts.ApiKeys.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        apiKeys.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Revoke_Works()
    {
        await this.client.SubAccounts.ApiKeys.Revoke(
            "keyId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
