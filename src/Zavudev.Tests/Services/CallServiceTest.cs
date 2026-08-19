using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class CallServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var call = await this.client.Calls.Create(
            new() { To = "+56912345678" },
            TestContext.Current.CancellationToken
        );
        call.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var call = await this.client.Calls.Retrieve(
            "callId",
            new(),
            TestContext.Current.CancellationToken
        );
        call.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Calls.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Hangup_Works()
    {
        var response = await this.client.Calls.Hangup(
            "callId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
