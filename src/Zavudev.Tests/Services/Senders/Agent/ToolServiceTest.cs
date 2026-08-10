using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Services.Senders.Agent;

public class ToolServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var tool = await this.client.Senders.Agent.Tools.Create(
            "senderId",
            new()
            {
                Description = "Get the status of a customer order",
                Name = "get_order_status",
                Parameters = new()
                {
                    Properties = new Dictionary<string, PropertiesItem>()
                    {
                        {
                            "order_id",
                            new() { Description = "The order ID to look up", Type = "string" }
                        },
                    },
                    Required = ["order_id"],
                    Type = Type.Object,
                },
                WebhookUrl = "https://api.example.com/webhooks/order-status",
            },
            TestContext.Current.CancellationToken
        );
        tool.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var tool = await this.client.Senders.Agent.Tools.Retrieve(
            "toolId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
        tool.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var tool = await this.client.Senders.Agent.Tools.Update(
            "toolId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
        tool.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Senders.Agent.Tools.List(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Senders.Agent.Tools.Delete(
            "toolId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Test_Works()
    {
        var response = await this.client.Senders.Agent.Tools.Test(
            "toolId",
            new()
            {
                SenderID = "senderId",
                TestParams = new Dictionary<string, JsonElement>()
                {
                    { "order_id", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
