using System;
using System.Collections.Generic;
using Zavudev.Models.Number10dlc.Campaigns;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns;

public class CampaignUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignUpdateParams
        {
            CampaignID = "campaignId",
            Description = "description",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            Name = "name",
            OptInKeywords = ["string"],
            OptOutKeywords = ["string"],
            SampleMessages = ["string"],
        };

        string expectedCampaignID = "campaignId";
        string expectedDescription = "description";
        string expectedHelpMessage = "helpMessage";
        string expectedMessageFlow = "messageFlow";
        string expectedName = "name";
        List<string> expectedOptInKeywords = ["string"];
        List<string> expectedOptOutKeywords = ["string"];
        List<string> expectedSampleMessages = ["string"];

        Assert.Equal(expectedCampaignID, parameters.CampaignID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedHelpMessage, parameters.HelpMessage);
        Assert.Equal(expectedMessageFlow, parameters.MessageFlow);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.OptInKeywords);
        Assert.Equal(expectedOptInKeywords.Count, parameters.OptInKeywords.Count);
        for (int i = 0; i < expectedOptInKeywords.Count; i++)
        {
            Assert.Equal(expectedOptInKeywords[i], parameters.OptInKeywords[i]);
        }
        Assert.NotNull(parameters.OptOutKeywords);
        Assert.Equal(expectedOptOutKeywords.Count, parameters.OptOutKeywords.Count);
        for (int i = 0; i < expectedOptOutKeywords.Count; i++)
        {
            Assert.Equal(expectedOptOutKeywords[i], parameters.OptOutKeywords[i]);
        }
        Assert.NotNull(parameters.SampleMessages);
        Assert.Equal(expectedSampleMessages.Count, parameters.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], parameters.SampleMessages[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CampaignUpdateParams { CampaignID = "campaignId" };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.HelpMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("helpMessage"));
        Assert.Null(parameters.MessageFlow);
        Assert.False(parameters.RawBodyData.ContainsKey("messageFlow"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.OptInKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("optInKeywords"));
        Assert.Null(parameters.OptOutKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("optOutKeywords"));
        Assert.Null(parameters.SampleMessages);
        Assert.False(parameters.RawBodyData.ContainsKey("sampleMessages"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CampaignUpdateParams
        {
            CampaignID = "campaignId",

            // Null should be interpreted as omitted for these properties
            Description = null,
            HelpMessage = null,
            MessageFlow = null,
            Name = null,
            OptInKeywords = null,
            OptOutKeywords = null,
            SampleMessages = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.HelpMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("helpMessage"));
        Assert.Null(parameters.MessageFlow);
        Assert.False(parameters.RawBodyData.ContainsKey("messageFlow"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.OptInKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("optInKeywords"));
        Assert.Null(parameters.OptOutKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("optOutKeywords"));
        Assert.Null(parameters.SampleMessages);
        Assert.False(parameters.RawBodyData.ContainsKey("sampleMessages"));
    }

    [Fact]
    public void Url_Works()
    {
        CampaignUpdateParams parameters = new() { CampaignID = "campaignId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/10dlc/campaigns/campaignId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignUpdateParams
        {
            CampaignID = "campaignId",
            Description = "description",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            Name = "name",
            OptInKeywords = ["string"],
            OptOutKeywords = ["string"],
            SampleMessages = ["string"],
        };

        CampaignUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
