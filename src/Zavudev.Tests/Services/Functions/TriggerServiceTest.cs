using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Functions;

public class TriggerServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var trigger = await this.client.Functions.Triggers.Create(
            "functionId",
            new() { EventTypes = ["message.inbound"], SenderIds = [null] },
            TestContext.Current.CancellationToken
        );
        trigger.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var trigger = await this.client.Functions.Triggers.Update(
            "triggerId",
            new() { Active = true },
            TestContext.Current.CancellationToken
        );
        trigger.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var triggers = await this.client.Functions.Triggers.List(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
        triggers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Functions.Triggers.Delete(
            "triggerId",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
