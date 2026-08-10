using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Number10dlc.Campaigns;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns;

public class CampaignRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CampaignRetrieveResponse
        {
            Campaign = new()
            {
                ID = "id",
                AffiliateMarketing = true,
                AgeGated = true,
                BrandID = "brandId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DirectLending = true,
                EmbeddedLink = true,
                EmbeddedPhone = true,
                Name = "Order Notifications",
                NumberPooling = true,
                SampleMessages = ["string"],
                Status = Status.Draft,
                SubscriberHelp = true,
                SubscriberOptIn = true,
                SubscriberOptOut = true,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UseCase = "ACCOUNT_NOTIFICATION",
                ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DailyLimit = 0,
                FailureReason = "failureReason",
                HelpMessage = "helpMessage",
                MessageFlow = "messageFlow",
                MonthlyFeeCents = 0,
                OptInKeywords = ["string"],
                OptOutKeywords = ["string"],
                RegistrationCostCents = 0,
                SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubUseCases = ["string"],
            },
        };

        TenDlcCampaign expectedCampaign = new()
        {
            ID = "id",
            AffiliateMarketing = true,
            AgeGated = true,
            BrandID = "brandId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DirectLending = true,
            EmbeddedLink = true,
            EmbeddedPhone = true,
            Name = "Order Notifications",
            NumberPooling = true,
            SampleMessages = ["string"],
            Status = Status.Draft,
            SubscriberHelp = true,
            SubscriberOptIn = true,
            SubscriberOptOut = true,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UseCase = "ACCOUNT_NOTIFICATION",
            ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DailyLimit = 0,
            FailureReason = "failureReason",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            MonthlyFeeCents = 0,
            OptInKeywords = ["string"],
            OptOutKeywords = ["string"],
            RegistrationCostCents = 0,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubUseCases = ["string"],
        };

        Assert.Equal(expectedCampaign, model.Campaign);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CampaignRetrieveResponse
        {
            Campaign = new()
            {
                ID = "id",
                AffiliateMarketing = true,
                AgeGated = true,
                BrandID = "brandId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DirectLending = true,
                EmbeddedLink = true,
                EmbeddedPhone = true,
                Name = "Order Notifications",
                NumberPooling = true,
                SampleMessages = ["string"],
                Status = Status.Draft,
                SubscriberHelp = true,
                SubscriberOptIn = true,
                SubscriberOptOut = true,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UseCase = "ACCOUNT_NOTIFICATION",
                ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DailyLimit = 0,
                FailureReason = "failureReason",
                HelpMessage = "helpMessage",
                MessageFlow = "messageFlow",
                MonthlyFeeCents = 0,
                OptInKeywords = ["string"],
                OptOutKeywords = ["string"],
                RegistrationCostCents = 0,
                SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubUseCases = ["string"],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CampaignRetrieveResponse
        {
            Campaign = new()
            {
                ID = "id",
                AffiliateMarketing = true,
                AgeGated = true,
                BrandID = "brandId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DirectLending = true,
                EmbeddedLink = true,
                EmbeddedPhone = true,
                Name = "Order Notifications",
                NumberPooling = true,
                SampleMessages = ["string"],
                Status = Status.Draft,
                SubscriberHelp = true,
                SubscriberOptIn = true,
                SubscriberOptOut = true,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UseCase = "ACCOUNT_NOTIFICATION",
                ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DailyLimit = 0,
                FailureReason = "failureReason",
                HelpMessage = "helpMessage",
                MessageFlow = "messageFlow",
                MonthlyFeeCents = 0,
                OptInKeywords = ["string"],
                OptOutKeywords = ["string"],
                RegistrationCostCents = 0,
                SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubUseCases = ["string"],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TenDlcCampaign expectedCampaign = new()
        {
            ID = "id",
            AffiliateMarketing = true,
            AgeGated = true,
            BrandID = "brandId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DirectLending = true,
            EmbeddedLink = true,
            EmbeddedPhone = true,
            Name = "Order Notifications",
            NumberPooling = true,
            SampleMessages = ["string"],
            Status = Status.Draft,
            SubscriberHelp = true,
            SubscriberOptIn = true,
            SubscriberOptOut = true,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UseCase = "ACCOUNT_NOTIFICATION",
            ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DailyLimit = 0,
            FailureReason = "failureReason",
            HelpMessage = "helpMessage",
            MessageFlow = "messageFlow",
            MonthlyFeeCents = 0,
            OptInKeywords = ["string"],
            OptOutKeywords = ["string"],
            RegistrationCostCents = 0,
            SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubUseCases = ["string"],
        };

        Assert.Equal(expectedCampaign, deserialized.Campaign);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CampaignRetrieveResponse
        {
            Campaign = new()
            {
                ID = "id",
                AffiliateMarketing = true,
                AgeGated = true,
                BrandID = "brandId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DirectLending = true,
                EmbeddedLink = true,
                EmbeddedPhone = true,
                Name = "Order Notifications",
                NumberPooling = true,
                SampleMessages = ["string"],
                Status = Status.Draft,
                SubscriberHelp = true,
                SubscriberOptIn = true,
                SubscriberOptOut = true,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UseCase = "ACCOUNT_NOTIFICATION",
                ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DailyLimit = 0,
                FailureReason = "failureReason",
                HelpMessage = "helpMessage",
                MessageFlow = "messageFlow",
                MonthlyFeeCents = 0,
                OptInKeywords = ["string"],
                OptOutKeywords = ["string"],
                RegistrationCostCents = 0,
                SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubUseCases = ["string"],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CampaignRetrieveResponse
        {
            Campaign = new()
            {
                ID = "id",
                AffiliateMarketing = true,
                AgeGated = true,
                BrandID = "brandId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DirectLending = true,
                EmbeddedLink = true,
                EmbeddedPhone = true,
                Name = "Order Notifications",
                NumberPooling = true,
                SampleMessages = ["string"],
                Status = Status.Draft,
                SubscriberHelp = true,
                SubscriberOptIn = true,
                SubscriberOptOut = true,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UseCase = "ACCOUNT_NOTIFICATION",
                ApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DailyLimit = 0,
                FailureReason = "failureReason",
                HelpMessage = "helpMessage",
                MessageFlow = "messageFlow",
                MonthlyFeeCents = 0,
                OptInKeywords = ["string"],
                OptOutKeywords = ["string"],
                RegistrationCostCents = 0,
                SubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubUseCases = ["string"],
            },
        };

        CampaignRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
