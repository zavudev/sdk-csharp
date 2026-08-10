using System.Threading.Tasks;

namespace Zavudev.Tests.Services.Number10dlc.Campaigns;

public class PhoneNumberServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var phoneNumbers = await this.client.Number10dlc.Campaigns.PhoneNumbers.List(
            "campaignId",
            new(),
            TestContext.Current.CancellationToken
        );
        phoneNumbers.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Assign_Works()
    {
        var response = await this.client.Number10dlc.Campaigns.PhoneNumbers.Assign(
            "campaignId",
            new() { PhoneNumberID = "pn_abc123" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Unassign_Works()
    {
        await this.client.Number10dlc.Campaigns.PhoneNumbers.Unassign(
            "assignmentId",
            new() { CampaignID = "campaignId" },
            TestContext.Current.CancellationToken
        );
    }
}
