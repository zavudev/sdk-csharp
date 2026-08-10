using System;
using Zavudev.Models.Number10dlc.Campaigns;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns;

public class CampaignSubmitParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignSubmitParams { CampaignID = "campaignId" };

        string expectedCampaignID = "campaignId";

        Assert.Equal(expectedCampaignID, parameters.CampaignID);
    }

    [Fact]
    public void Url_Works()
    {
        CampaignSubmitParams parameters = new() { CampaignID = "campaignId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/10dlc/campaigns/campaignId/submit"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignSubmitParams { CampaignID = "campaignId" };

        CampaignSubmitParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
