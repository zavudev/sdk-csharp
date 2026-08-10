using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class FunctionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var function = await this.client.Functions.Create(
            new() { Name = "Order Bot", Slug = "order-bot" },
            TestContext.Current.CancellationToken
        );
        function.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var function = await this.client.Functions.Retrieve(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
        function.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var function = await this.client.Functions.Update(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
        function.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var function = await this.client.Functions.Delete(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
        function.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Deploy_Works()
    {
        var response = await this.client.Functions.Deploy(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetDeployment_Works()
    {
        var response = await this.client.Functions.GetDeployment(
            "deploymentId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task TailLogs_Works()
    {
        var response = await this.client.Functions.TailLogs(
            "functionId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
