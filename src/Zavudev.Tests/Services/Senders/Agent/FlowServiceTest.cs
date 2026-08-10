using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Services.Senders.Agent;

public class FlowServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var flow = await this.client.Senders.Agent.Flows.Create(
            "senderId",
            new()
            {
                Name = "Lead Capture",
                Steps =
                [
                    new()
                    {
                        ID = "welcome",
                        Config = new Dictionary<string, JsonElement>()
                        {
                            { "text", JsonSerializer.SerializeToElement("bar") },
                        },
                        Type = Type.Message,
                        NextStepID = "ask_name",
                    },
                    new()
                    {
                        ID = "ask_name",
                        Config = new Dictionary<string, JsonElement>()
                        {
                            { "variable", JsonSerializer.SerializeToElement("bar") },
                            { "prompt", JsonSerializer.SerializeToElement("bar") },
                        },
                        Type = Type.Collect,
                        NextStepID = "nextStepId",
                    },
                ],
                Trigger = new()
                {
                    Type = FlowTriggerType.Keyword,
                    Intent = "intent",
                    Keywords = ["info", "pricing", "demo"],
                },
            },
            TestContext.Current.CancellationToken
        );
        flow.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var flow = await this.client.Senders.Agent.Flows.Retrieve(
            "flowId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
        flow.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var flow = await this.client.Senders.Agent.Flows.Update(
            "flowId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
        flow.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Senders.Agent.Flows.List(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Senders.Agent.Flows.Delete(
            "flowId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Duplicate_Works()
    {
        var response = await this.client.Senders.Agent.Flows.Duplicate(
            "flowId",
            new() { SenderID = "senderId", NewName = "Lead Capture (Copy)" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
