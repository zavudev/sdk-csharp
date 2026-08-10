using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Senders.Agent;

public class ExecutionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var execution = await this.client.Senders.Agent.Executions.Retrieve(
            "executionId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
        execution.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Senders.Agent.Executions.List(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
