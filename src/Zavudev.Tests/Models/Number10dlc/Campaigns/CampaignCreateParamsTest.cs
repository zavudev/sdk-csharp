using System;
using System.Collections.Generic;
using Zavudev.Models.Number10dlc.Campaigns;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns;

public class CampaignCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CampaignCreateParams
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
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptInKeywords = ["string"],
            OptOutKeywords = ["string"],
            SubUseCases = ["string"],
        };

        bool expectedAffiliateMarketing = false;
        bool expectedAgeGated = false;
        string expectedBrandID = "brand_abc123";
        string expectedDescription =
            "Send order status updates and shipping notifications to customers who opted in.";
        bool expectedDirectLending = false;
        bool expectedEmbeddedLink = true;
        bool expectedEmbeddedPhone = false;
        string expectedName = "Order Notifications";
        bool expectedNumberPooling = false;
        List<string> expectedSampleMessages =
        [
            "Hi {{name}}, your order #{{order_id}} has shipped! Track it at {{url}}",
            "Your order #{{order_id}} has been delivered. Thank you for your purchase!",
        ];
        bool expectedSubscriberHelp = true;
        bool expectedSubscriberOptIn = true;
        bool expectedSubscriberOptOut = true;
        string expectedUseCase = "ACCOUNT_NOTIFICATION";
        string expectedHelpMessage = "helpMessage";
        string expectedMessageFlow = "messageFlow";
        List<string> expectedOptInKeywords = ["string"];
        List<string> expectedOptOutKeywords = ["string"];
        List<string> expectedSubUseCases = ["string"];

        Assert.Equal(expectedAffiliateMarketing, parameters.AffiliateMarketing);
        Assert.Equal(expectedAgeGated, parameters.AgeGated);
        Assert.Equal(expectedBrandID, parameters.BrandID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDirectLending, parameters.DirectLending);
        Assert.Equal(expectedEmbeddedLink, parameters.EmbeddedLink);
        Assert.Equal(expectedEmbeddedPhone, parameters.EmbeddedPhone);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedNumberPooling, parameters.NumberPooling);
        Assert.Equal(expectedSampleMessages.Count, parameters.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], parameters.SampleMessages[i]);
        }
        Assert.Equal(expectedSubscriberHelp, parameters.SubscriberHelp);
        Assert.Equal(expectedSubscriberOptIn, parameters.SubscriberOptIn);
        Assert.Equal(expectedSubscriberOptOut, parameters.SubscriberOptOut);
        Assert.Equal(expectedUseCase, parameters.UseCase);
        Assert.Equal(expectedHelpMessage, parameters.HelpMessage);
        Assert.Equal(expectedMessageFlow, parameters.MessageFlow);
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
        Assert.NotNull(parameters.SubUseCases);
        Assert.Equal(expectedSubUseCases.Count, parameters.SubUseCases.Count);
        for (int i = 0; i < expectedSubUseCases.Count; i++)
        {
            Assert.Equal(expectedSubUseCases[i], parameters.SubUseCases[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CampaignCreateParams
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
        };

        Assert.Null(parameters.HelpMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("helpMessage"));
        Assert.Null(parameters.MessageFlow);
        Assert.False(parameters.RawBodyData.ContainsKey("messageFlow"));
        Assert.Null(parameters.OptInKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("optInKeywords"));
        Assert.Null(parameters.OptOutKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("optOutKeywords"));
        Assert.Null(parameters.SubUseCases);
        Assert.False(parameters.RawBodyData.ContainsKey("subUseCases"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CampaignCreateParams
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

            // Null should be interpreted as omitted for these properties
            HelpMessage = null,
            MessageFlow = null,
            OptInKeywords = null,
            OptOutKeywords = null,
            SubUseCases = null,
        };

        Assert.Null(parameters.HelpMessage);
        Assert.False(parameters.RawBodyData.ContainsKey("helpMessage"));
        Assert.Null(parameters.MessageFlow);
        Assert.False(parameters.RawBodyData.ContainsKey("messageFlow"));
        Assert.Null(parameters.OptInKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("optInKeywords"));
        Assert.Null(parameters.OptOutKeywords);
        Assert.False(parameters.RawBodyData.ContainsKey("optOutKeywords"));
        Assert.Null(parameters.SubUseCases);
        Assert.False(parameters.RawBodyData.ContainsKey("subUseCases"));
    }

    [Fact]
    public void Url_Works()
    {
        CampaignCreateParams parameters = new()
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
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/10dlc/campaigns"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CampaignCreateParams
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
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            OptInKeywords = ["string"],
            OptOutKeywords = ["string"],
            SubUseCases = ["string"],
        };

        CampaignCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
