using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Senders.Agent.KnowledgeBases;

public class DocumentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var document = await this.client.Senders.Agent.KnowledgeBases.Documents.Create(
            "kbId",
            new()
            {
                SenderID = "senderId",
                Content = "Our return policy allows returns within 30 days of purchase...",
                Title = "Return Policy",
            },
            TestContext.Current.CancellationToken
        );
        document.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Senders.Agent.KnowledgeBases.Documents.List(
            "kbId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Senders.Agent.KnowledgeBases.Documents.Delete(
            "docId",
            new() { SenderID = "senderId", KBID = "kbId" },
            TestContext.Current.CancellationToken
        );
    }
}
