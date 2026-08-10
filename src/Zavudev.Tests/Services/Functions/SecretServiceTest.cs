using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Functions;

public class SecretServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var secrets = await this.client.Functions.Secrets.List(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
        secrets.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Set_Works()
    {
        await this.client.Functions.Secrets.Set(
            "key",
            new() { FunctionID = "functionId", Value = "value" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Unset_Works()
    {
        await this.client.Functions.Secrets.Unset(
            "key",
            new() { FunctionID = "functionId" },
            TestContext.Current.CancellationToken
        );
    }
}
