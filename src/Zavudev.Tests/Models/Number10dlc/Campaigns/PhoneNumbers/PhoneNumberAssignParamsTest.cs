using System;
using Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns.PhoneNumbers;

public class PhoneNumberAssignParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberAssignParams
        {
            CampaignID = "campaignId",
            PhoneNumberID = "pn_abc123",
        };

        string expectedCampaignID = "campaignId";
        string expectedPhoneNumberID = "pn_abc123";

        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedPhoneNumberID, parameters.PhoneNumberID);
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberAssignParams parameters = new()
        {
            CampaignID = "campaignId",
            PhoneNumberID = "pn_abc123",
        };

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
        var parameters = new PhoneNumberAssignParams
        {
            CampaignID = "campaignId",
            PhoneNumberID = "pn_abc123",
        };

        PhoneNumberAssignParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
