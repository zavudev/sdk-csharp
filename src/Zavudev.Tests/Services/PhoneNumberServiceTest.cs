using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class PhoneNumberServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var phoneNumber = await this.client.PhoneNumbers.Retrieve(
            "phoneNumberId",
            new(),
            TestContext.Current.CancellationToken
        );
        phoneNumber.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var phoneNumber = await this.client.PhoneNumbers.Update(
            "phoneNumberId",
            new(),
            TestContext.Current.CancellationToken
        );
        phoneNumber.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.PhoneNumbers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Purchase_Works()
    {
        var response = await this.client.PhoneNumbers.Purchase(
            new() { PhoneNumber = "+15551234567" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Release_Works()
    {
        await this.client.PhoneNumbers.Release(
            "phoneNumberId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Requirements_Works()
    {
        var response = await this.client.PhoneNumbers.Requirements(
            new() { CountryCode = "xx" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task SearchAvailable_Works()
    {
        var response = await this.client.PhoneNumbers.SearchAvailable(
            new() { CountryCode = "xx" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
