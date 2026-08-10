using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Senders.Agent;

public class KnowledgeBaseServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var knowledgeBase = await this.client.Senders.Agent.KnowledgeBases.Create(
            "senderId",
            new() { Name = "Product FAQ" },
            TestContext.Current.CancellationToken
        );
        knowledgeBase.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var knowledgeBase = await this.client.Senders.Agent.KnowledgeBases.Retrieve(
            "kbId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
        knowledgeBase.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var knowledgeBase = await this.client.Senders.Agent.KnowledgeBases.Update(
            "kbId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
        knowledgeBase.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Senders.Agent.KnowledgeBases.List(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Senders.Agent.KnowledgeBases.Delete(
            "kbId",
            new() { SenderID = "senderId" },
            TestContext.Current.CancellationToken
        );
    }
}
