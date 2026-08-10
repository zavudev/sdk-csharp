using System.Threading.Tasks;

namespace Zavudev.Tests.Services;

public class AddressServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var address = await this.client.Addresses.Create(
            new()
            {
                CountryCode = "DE",
                Locality = "Berlin",
                PostalCode = "10115",
                StreetAddress = "123 Main St",
            },
            TestContext.Current.CancellationToken
        );
        address.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var address = await this.client.Addresses.Retrieve(
            "addressId",
            new(),
            TestContext.Current.CancellationToken
        );
        address.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Addresses.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Addresses.Delete(
            "addressId",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
