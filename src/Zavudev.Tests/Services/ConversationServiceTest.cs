using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class ConversationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var conversation = await this.client.Conversations.Retrieve(
            "conversationId",
            new(),
            TestContext.Current.CancellationToken
        );
        conversation.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Conversations.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListMessages_Works()
    {
        var page = await this.client.Conversations.ListMessages(
            "conversationId",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task MarkAsRead_Works()
    {
        var response = await this.client.Conversations.MarkAsRead(
            "conversationId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
