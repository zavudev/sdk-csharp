using System.Threading.Tasks;
using Zavudev.Models.Number10dlc.Brands;

namespace Zavudev.Tests.Services.Number10dlc;

public class BrandServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var brand = await this.client.Number10dlc.Brands.Create(
            new()
            {
                City = "San Francisco",
                Country = "US",
                DisplayName = "Acme Corp",
                Email = "compliance@acme.com",
                EntityType = EntityType.PrivateProfit,
                Phone = "+14155551234",
                PostalCode = "94102",
                State = "CA",
                Street = "123 Main St",
                Vertical = "Technology",
            },
            TestContext.Current.CancellationToken
        );
        brand.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var brand = await this.client.Number10dlc.Brands.Retrieve(
            "brandId",
            new(),
            TestContext.Current.CancellationToken
        );
        brand.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var brand = await this.client.Number10dlc.Brands.Update(
            "brandId",
            new(),
            TestContext.Current.CancellationToken
        );
        brand.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Number10dlc.Brands.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Number10dlc.Brands.Delete(
            "brandId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListUseCases_Works()
    {
        var response = await this.client.Number10dlc.Brands.ListUseCases(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Submit_Works()
    {
        var response = await this.client.Number10dlc.Brands.Submit(
            "brandId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task SyncStatus_Works()
    {
        var response = await this.client.Number10dlc.Brands.SyncStatus(
            "brandId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
