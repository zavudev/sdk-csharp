using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Number10dlc.Campaigns;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns;

public class TenDlcCampaignTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TenDlcCampaign
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

        string expectedID = "id";
        bool expectedAffiliateMarketing = true;
        bool expectedAgeGated = true;
        string expectedBrandID = "brandId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        bool expectedDirectLending = true;
        bool expectedEmbeddedLink = true;
        bool expectedEmbeddedPhone = true;
        string expectedName = "Order Notifications";
        bool expectedNumberPooling = true;
        List<string> expectedSampleMessages = ["string"];
        ApiEnum<string, Status> expectedStatus = Status.Draft;
        bool expectedSubscriberHelp = true;
        bool expectedSubscriberOptIn = true;
        bool expectedSubscriberOptOut = true;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUseCase = "ACCOUNT_NOTIFICATION";
        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDailyLimit = 0;
        string expectedFailureReason = "failureReason";
        string expectedHelpMessage = "helpMessage";
        string expectedMessageFlow = "messageFlow";
        long expectedMonthlyFeeCents = 0;
        List<string> expectedOptInKeywords = ["string"];
        List<string> expectedOptOutKeywords = ["string"];
        long expectedRegistrationCostCents = 0;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedSubUseCases = ["string"];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAffiliateMarketing, model.AffiliateMarketing);
        Assert.Equal(expectedAgeGated, model.AgeGated);
        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDirectLending, model.DirectLending);
        Assert.Equal(expectedEmbeddedLink, model.EmbeddedLink);
        Assert.Equal(expectedEmbeddedPhone, model.EmbeddedPhone);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNumberPooling, model.NumberPooling);
        Assert.Equal(expectedSampleMessages.Count, model.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], model.SampleMessages[i]);
        }
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubscriberHelp, model.SubscriberHelp);
        Assert.Equal(expectedSubscriberOptIn, model.SubscriberOptIn);
        Assert.Equal(expectedSubscriberOptOut, model.SubscriberOptOut);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedUseCase, model.UseCase);
        Assert.Equal(expectedApprovedAt, model.ApprovedAt);
        Assert.Equal(expectedDailyLimit, model.DailyLimit);
        Assert.Equal(expectedFailureReason, model.FailureReason);
        Assert.Equal(expectedHelpMessage, model.HelpMessage);
        Assert.Equal(expectedMessageFlow, model.MessageFlow);
        Assert.Equal(expectedMonthlyFeeCents, model.MonthlyFeeCents);
        Assert.NotNull(model.OptInKeywords);
        Assert.Equal(expectedOptInKeywords.Count, model.OptInKeywords.Count);
        for (int i = 0; i < expectedOptInKeywords.Count; i++)
        {
            Assert.Equal(expectedOptInKeywords[i], model.OptInKeywords[i]);
        }
        Assert.NotNull(model.OptOutKeywords);
        Assert.Equal(expectedOptOutKeywords.Count, model.OptOutKeywords.Count);
        for (int i = 0; i < expectedOptOutKeywords.Count; i++)
        {
            Assert.Equal(expectedOptOutKeywords[i], model.OptOutKeywords[i]);
        }
        Assert.Equal(expectedRegistrationCostCents, model.RegistrationCostCents);
        Assert.Equal(expectedSubmittedAt, model.SubmittedAt);
        Assert.NotNull(model.SubUseCases);
        Assert.Equal(expectedSubUseCases.Count, model.SubUseCases.Count);
        for (int i = 0; i < expectedSubUseCases.Count; i++)
        {
            Assert.Equal(expectedSubUseCases[i], model.SubUseCases[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TenDlcCampaign
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenDlcCampaign>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TenDlcCampaign
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenDlcCampaign>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedAffiliateMarketing = true;
        bool expectedAgeGated = true;
        string expectedBrandID = "brandId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        bool expectedDirectLending = true;
        bool expectedEmbeddedLink = true;
        bool expectedEmbeddedPhone = true;
        string expectedName = "Order Notifications";
        bool expectedNumberPooling = true;
        List<string> expectedSampleMessages = ["string"];
        ApiEnum<string, Status> expectedStatus = Status.Draft;
        bool expectedSubscriberHelp = true;
        bool expectedSubscriberOptIn = true;
        bool expectedSubscriberOptOut = true;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedUseCase = "ACCOUNT_NOTIFICATION";
        DateTimeOffset expectedApprovedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDailyLimit = 0;
        string expectedFailureReason = "failureReason";
        string expectedHelpMessage = "helpMessage";
        string expectedMessageFlow = "messageFlow";
        long expectedMonthlyFeeCents = 0;
        List<string> expectedOptInKeywords = ["string"];
        List<string> expectedOptOutKeywords = ["string"];
        long expectedRegistrationCostCents = 0;
        DateTimeOffset expectedSubmittedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedSubUseCases = ["string"];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAffiliateMarketing, deserialized.AffiliateMarketing);
        Assert.Equal(expectedAgeGated, deserialized.AgeGated);
        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDirectLending, deserialized.DirectLending);
        Assert.Equal(expectedEmbeddedLink, deserialized.EmbeddedLink);
        Assert.Equal(expectedEmbeddedPhone, deserialized.EmbeddedPhone);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNumberPooling, deserialized.NumberPooling);
        Assert.Equal(expectedSampleMessages.Count, deserialized.SampleMessages.Count);
        for (int i = 0; i < expectedSampleMessages.Count; i++)
        {
            Assert.Equal(expectedSampleMessages[i], deserialized.SampleMessages[i]);
        }
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscriberHelp, deserialized.SubscriberHelp);
        Assert.Equal(expectedSubscriberOptIn, deserialized.SubscriberOptIn);
        Assert.Equal(expectedSubscriberOptOut, deserialized.SubscriberOptOut);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedUseCase, deserialized.UseCase);
        Assert.Equal(expectedApprovedAt, deserialized.ApprovedAt);
        Assert.Equal(expectedDailyLimit, deserialized.DailyLimit);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
        Assert.Equal(expectedHelpMessage, deserialized.HelpMessage);
        Assert.Equal(expectedMessageFlow, deserialized.MessageFlow);
        Assert.Equal(expectedMonthlyFeeCents, deserialized.MonthlyFeeCents);
        Assert.NotNull(deserialized.OptInKeywords);
        Assert.Equal(expectedOptInKeywords.Count, deserialized.OptInKeywords.Count);
        for (int i = 0; i < expectedOptInKeywords.Count; i++)
        {
            Assert.Equal(expectedOptInKeywords[i], deserialized.OptInKeywords[i]);
        }
        Assert.NotNull(deserialized.OptOutKeywords);
        Assert.Equal(expectedOptOutKeywords.Count, deserialized.OptOutKeywords.Count);
        for (int i = 0; i < expectedOptOutKeywords.Count; i++)
        {
            Assert.Equal(expectedOptOutKeywords[i], deserialized.OptOutKeywords[i]);
        }
        Assert.Equal(expectedRegistrationCostCents, deserialized.RegistrationCostCents);
        Assert.Equal(expectedSubmittedAt, deserialized.SubmittedAt);
        Assert.NotNull(deserialized.SubUseCases);
        Assert.Equal(expectedSubUseCases.Count, deserialized.SubUseCases.Count);
        for (int i = 0; i < expectedSubUseCases.Count; i++)
        {
            Assert.Equal(expectedSubUseCases[i], deserialized.SubUseCases[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TenDlcCampaign
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TenDlcCampaign
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
        };

        Assert.Null(model.ApprovedAt);
        Assert.False(model.RawData.ContainsKey("approvedAt"));
        Assert.Null(model.DailyLimit);
        Assert.False(model.RawData.ContainsKey("dailyLimit"));
        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failureReason"));
        Assert.Null(model.HelpMessage);
        Assert.False(model.RawData.ContainsKey("helpMessage"));
        Assert.Null(model.MessageFlow);
        Assert.False(model.RawData.ContainsKey("messageFlow"));
        Assert.Null(model.MonthlyFeeCents);
        Assert.False(model.RawData.ContainsKey("monthlyFeeCents"));
        Assert.Null(model.OptInKeywords);
        Assert.False(model.RawData.ContainsKey("optInKeywords"));
        Assert.Null(model.OptOutKeywords);
        Assert.False(model.RawData.ContainsKey("optOutKeywords"));
        Assert.Null(model.RegistrationCostCents);
        Assert.False(model.RawData.ContainsKey("registrationCostCents"));
        Assert.Null(model.SubmittedAt);
        Assert.False(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.SubUseCases);
        Assert.False(model.RawData.ContainsKey("subUseCases"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TenDlcCampaign
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TenDlcCampaign
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

            ApprovedAt = null,
            DailyLimit = null,
            FailureReason = null,
            HelpMessage = null,
            MessageFlow = null,
            MonthlyFeeCents = null,
            OptInKeywords = null,
            OptOutKeywords = null,
            RegistrationCostCents = null,
            SubmittedAt = null,
            SubUseCases = null,
        };

        Assert.Null(model.ApprovedAt);
        Assert.True(model.RawData.ContainsKey("approvedAt"));
        Assert.Null(model.DailyLimit);
        Assert.True(model.RawData.ContainsKey("dailyLimit"));
        Assert.Null(model.FailureReason);
        Assert.True(model.RawData.ContainsKey("failureReason"));
        Assert.Null(model.HelpMessage);
        Assert.True(model.RawData.ContainsKey("helpMessage"));
        Assert.Null(model.MessageFlow);
        Assert.True(model.RawData.ContainsKey("messageFlow"));
        Assert.Null(model.MonthlyFeeCents);
        Assert.True(model.RawData.ContainsKey("monthlyFeeCents"));
        Assert.Null(model.OptInKeywords);
        Assert.True(model.RawData.ContainsKey("optInKeywords"));
        Assert.Null(model.OptOutKeywords);
        Assert.True(model.RawData.ContainsKey("optOutKeywords"));
        Assert.Null(model.RegistrationCostCents);
        Assert.True(model.RawData.ContainsKey("registrationCostCents"));
        Assert.Null(model.SubmittedAt);
        Assert.True(model.RawData.ContainsKey("submittedAt"));
        Assert.Null(model.SubUseCases);
        Assert.True(model.RawData.ContainsKey("subUseCases"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TenDlcCampaign
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

            ApprovedAt = null,
            DailyLimit = null,
            FailureReason = null,
            HelpMessage = null,
            MessageFlow = null,
            MonthlyFeeCents = null,
            OptInKeywords = null,
            OptOutKeywords = null,
            RegistrationCostCents = null,
            SubmittedAt = null,
            SubUseCases = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TenDlcCampaign
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

        TenDlcCampaign copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Approved)]
    [InlineData(Status.Rejected)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Pending)]
    [InlineData(Status.Approved)]
    [InlineData(Status.Rejected)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
