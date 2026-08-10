using System;
using Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns.PhoneNumbers;

public class PhoneNumberListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberListParams { CampaignID = "campaignId" };

        string expectedCampaignID = "campaignId";

        Assert.Equal(expectedCampaignID, parameters.CampaignID);
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberListParams parameters = new() { CampaignID = "campaignId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/10dlc/campaigns/campaignId/phone-numbers"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhoneNumberListParams { CampaignID = "campaignId" };

        PhoneNumberListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
