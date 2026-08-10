using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Number10dlc;

public class CampaignServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var campaign = await this.client.Number10dlc.Campaigns.Create(
            new()
            {
                AffiliateMarketing = false,
                AgeGated = false,
                BrandID = "brand_abc123",
                Description =
                    "Send order status updates and shipping notifications to customers who opted in.",
                DirectLending = false,
                EmbeddedLink = true,
                EmbeddedPhone = false,
                Name = "Order Notifications",
                NumberPooling = false,
                SampleMessages =
                [
                    "Hi {{name}}, your order #{{order_id}} has shipped! Track it at {{url}}",
                    "Your order #{{order_id}} has been delivered. Thank you for your purchase!",
                ],
                SubscriberHelp = true,
                SubscriberOptIn = true,
                SubscriberOptOut = true,
                UseCase = "ACCOUNT_NOTIFICATION",
            },
            TestContext.Current.CancellationToken
        );
        campaign.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var campaign = await this.client.Number10dlc.Campaigns.Retrieve(
            "campaignId",
            new(),
            TestContext.Current.CancellationToken
        );
        campaign.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var campaign = await this.client.Number10dlc.Campaigns.Update(
            "campaignId",
            new(),
            TestContext.Current.CancellationToken
        );
        campaign.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Number10dlc.Campaigns.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Number10dlc.Campaigns.Delete(
            "campaignId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Submit_Works()
    {
        var response = await this.client.Number10dlc.Campaigns.Submit(
            "campaignId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task SyncStatus_Works()
    {
        var response = await this.client.Number10dlc.Campaigns.SyncStatus(
            "campaignId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
