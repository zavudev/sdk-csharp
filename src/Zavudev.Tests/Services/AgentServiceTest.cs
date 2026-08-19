using System.Threading.Tasks;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Services;

public class AgentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var agent = await this.client.Agents.Create(
            new()
            {
                Model = "model",
                Name = "name",
                Provider = AgentProvider.OpenAI,
                SystemPrompt = "systemPrompt",
            },
            TestContext.Current.CancellationToken
        );
        agent.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var agent = await this.client.Agents.Retrieve(
            "agentId",
            new(),
            TestContext.Current.CancellationToken
        );
        agent.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var agent = await this.client.Agents.Update(
            "agentId",
            new(),
            TestContext.Current.CancellationToken
        );
        agent.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Agents.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Agents.Delete("agentId", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListVoices_Works()
    {
        var response = await this.client.Agents.ListVoices(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Test_Works()
    {
        var response = await this.client.Agents.Test(
            "agentId",
            new() { Message = "Where is order ORD-12345?" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
