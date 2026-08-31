using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Agents;

public class SenderServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Connect_Works()
    {
        var response = await this.client.Agents.Senders.Connect(
            "agentId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Disconnect_Works()
    {
        await this.client.Agents.Senders.Disconnect(
            "senderId",
            new() { AgentID = "agentId" },
            TestContext.Current.CancellationToken
        );
    }
}
