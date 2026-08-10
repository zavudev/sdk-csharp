using System;
using Zavudev.Models.Number10dlc.Campaigns;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns;

public class CampaignDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignDeleteParams { CampaignID = "campaignId" };

        string expectedCampaignID = "campaignId";

        Assert.Equal(expectedCampaignID, parameters.CampaignID);
    }

    [Fact]
    public void Url_Works()
    {
        CampaignDeleteParams parameters = new() { CampaignID = "campaignId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/10dlc/campaigns/campaignId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignDeleteParams { CampaignID = "campaignId" };

        CampaignDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
