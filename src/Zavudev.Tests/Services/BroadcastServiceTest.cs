using System;
using System.Threading.Tasks;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Services;

public class BroadcastServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var broadcast = await this.client.Broadcasts.Create(
            new() { Channel = BroadcastChannel.Sms, Name = "Black Friday Sale" },
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var broadcast = await this.client.Broadcasts.Retrieve(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var broadcast = await this.client.Broadcasts.Update(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Broadcasts.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Broadcasts.Delete(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var response = await this.client.Broadcasts.Cancel(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task EscalateReview_Works()
    {
        var response = await this.client.Broadcasts.EscalateReview(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Progress_Works()
    {
        var broadcastProgress = await this.client.Broadcasts.Progress(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        broadcastProgress.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Reschedule_Works()
    {
        var response = await this.client.Broadcasts.Reschedule(
            "broadcastId",
            new() { ScheduledAt = DateTimeOffset.Parse("2024-01-15T14:00:00Z") },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetryReview_Works()
    {
        var response = await this.client.Broadcasts.RetryReview(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Send_Works()
    {
        var response = await this.client.Broadcasts.Send(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
