using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class EmailDomainServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var emailDomain = await this.client.EmailDomains.Create(
            new() { Domain = "example.com" },
            TestContext.Current.CancellationToken
        );
        emailDomain.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var emailDomain = await this.client.EmailDomains.Retrieve(
            "domainId",
            new(),
            TestContext.Current.CancellationToken
        );
        emailDomain.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var emailDomains = await this.client.EmailDomains.List(
            new(),
            TestContext.Current.CancellationToken
        );
        emailDomains.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.EmailDomains.Delete(
            "domainId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Verify_Works()
    {
        var response = await this.client.EmailDomains.Verify(
            "domainId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
