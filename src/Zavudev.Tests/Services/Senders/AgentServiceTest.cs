using System.Threading.Tasks;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Services.Senders;

public class AgentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var agentResponse = await this.client.Senders.Agent.Create(
            "senderId",
            new()
            {
                Model = "gpt-4o-mini",
                Name = "Customer Support",
                Provider = AgentProvider.OpenAI,
                SystemPrompt = "You are a helpful customer support agent. Be friendly and concise.",
            },
            TestContext.Current.CancellationToken
        );
        agentResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var agentResponse = await this.client.Senders.Agent.Retrieve(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        agentResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var agentResponse = await this.client.Senders.Agent.Update(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        agentResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Senders.Agent.Delete(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Stats_Works()
    {
        var agentStats = await this.client.Senders.Agent.Stats(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        agentStats.Validate();
    }
}
