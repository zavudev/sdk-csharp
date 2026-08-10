using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class MessageServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var messageResponse = await this.client.Messages.Retrieve(
            "messageId",
            new(),
            TestContext.Current.CancellationToken
        );
        messageResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Messages.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task React_Works()
    {
        var messageResponse = await this.client.Messages.React(
            "messageId",
            new() { Emoji = "👍" },
            TestContext.Current.CancellationToken
        );
        messageResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Send_Works()
    {
        var messageResponse = await this.client.Messages.Send(
            new() { To = "+56912345678" },
            TestContext.Current.CancellationToken
        );
        messageResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ShowTyping_Works()
    {
        var response = await this.client.Messages.ShowTyping(
            "messageId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
