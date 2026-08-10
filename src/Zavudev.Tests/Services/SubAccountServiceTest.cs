using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class SubAccountServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var subAccount = await this.client.SubAccounts.Create(
            new() { Name = "Client ABC" },
            TestContext.Current.CancellationToken
        );
        subAccount.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var subAccount = await this.client.SubAccounts.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        subAccount.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var subAccount = await this.client.SubAccounts.Update(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        subAccount.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.SubAccounts.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Deactivate_Works()
    {
        var response = await this.client.SubAccounts.Deactivate(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetBalance_Works()
    {
        var response = await this.client.SubAccounts.GetBalance(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
