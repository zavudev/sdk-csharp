using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Number10dlc.Campaigns;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns;

public class CampaignListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CampaignListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        List<TenDlcCampaign> expectedItems =
        [
            new()
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
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CampaignListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CampaignListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CampaignListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TenDlcCampaign> expectedItems =
        [
            new()
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
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CampaignListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CampaignListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CampaignListPageResponse
        {
            Items =
            [
                new()
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
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CampaignListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CampaignListPageResponse
        {
            Items =
            [
                new()
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
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CampaignListPageResponse
        {
            Items =
            [
                new()
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
            ],
            NextCursor = "nextCursor",
        };

        CampaignListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
