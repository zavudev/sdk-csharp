using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class TemplateServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var template = await this.client.Templates.Create(
            new()
            {
                Body =
                    "Hi {{1}}, your order {{2}} has been confirmed and will ship within 24 hours.",
                Language = "en",
                Name = "order_confirmation",
            },
            TestContext.Current.CancellationToken
        );
        template.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var template = await this.client.Templates.Retrieve(
            "templateId",
            new(),
            TestContext.Current.CancellationToken
        );
        template.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Templates.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Templates.Delete(
            "templateId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Submit_Works()
    {
        var template = await this.client.Templates.Submit(
            "templateId",
            new() { SenderID = "sender_abc123" },
            TestContext.Current.CancellationToken
        );
        template.Validate();
    }
}
