using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class AgentTemplateServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var agentTemplate = await this.client.AgentTemplates.Retrieve(
            "fermi",
            new(),
            TestContext.Current.CancellationToken
        );
        agentTemplate.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var agentTemplates = await this.client.AgentTemplates.List(
            new(),
            TestContext.Current.CancellationToken
        );
        agentTemplates.Validate();
    }
}
