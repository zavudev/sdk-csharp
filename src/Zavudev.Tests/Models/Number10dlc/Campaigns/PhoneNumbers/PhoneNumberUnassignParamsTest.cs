using System;
using Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns.PhoneNumbers;

public class PhoneNumberUnassignParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberUnassignParams
        {
            CampaignID = "campaignId",
            AssignmentID = "assignmentId",
        };

        string expectedCampaignID = "campaignId";
        string expectedAssignmentID = "assignmentId";

        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedAssignmentID, parameters.AssignmentID);
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberUnassignParams parameters = new()
        {
            CampaignID = "campaignId",
            AssignmentID = "assignmentId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/10dlc/campaigns/campaignId/phone-numbers/assignmentId"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhoneNumberUnassignParams
        {
            CampaignID = "campaignId",
            AssignmentID = "assignmentId",
        };

        PhoneNumberUnassignParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
