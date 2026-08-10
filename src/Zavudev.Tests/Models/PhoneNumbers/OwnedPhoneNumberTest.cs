using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class OwnedPhoneNumberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OwnedPhoneNumber
        {
            ID = "id",
            Capabilities = ["sms", "voice"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeNumber = true,
                MonthlyCost = 0,
                MonthlyPrice = 0,
                UpfrontCost = 0,
            },
            Status = PhoneNumberStatus.Active,
            Name = "name",
            NextRenewalDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<string> expectedCapabilities = ["sms", "voice"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPhoneNumber = "+15551234567";
        OwnedPhoneNumberPricing expectedPricing = new()
        {
            IsFreeNumber = true,
            MonthlyCost = 0,
            MonthlyPrice = 0,
            UpfrontCost = 0,
        };
        ApiEnum<string, PhoneNumberStatus> expectedStatus = PhoneNumberStatus.Active;
        string expectedName = "name";
        DateTimeOffset expectedNextRenewalDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSenderID = "senderId";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCapabilities.Count, model.Capabilities.Count);
        for (int i = 0; i < expectedCapabilities.Count; i++)
        {
            Assert.Equal(expectedCapabilities[i], model.Capabilities[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPricing, model.Pricing);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNextRenewalDate, model.NextRenewalDate);
        Assert.Equal(expectedSenderID, model.SenderID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OwnedPhoneNumber
        {
            ID = "id",
            Capabilities = ["sms", "voice"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeNumber = true,
                MonthlyCost = 0,
                MonthlyPrice = 0,
                UpfrontCost = 0,
            },
            Status = PhoneNumberStatus.Active,
            Name = "name",
            NextRenewalDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OwnedPhoneNumber>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OwnedPhoneNumber
        {
            ID = "id",
            Capabilities = ["sms", "voice"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeNumber = true,
                MonthlyCost = 0,
                MonthlyPrice = 0,
                UpfrontCost = 0,
            },
            Status = PhoneNumberStatus.Active,
            Name = "name",
            NextRenewalDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OwnedPhoneNumber>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<string> expectedCapabilities = ["sms", "voice"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPhoneNumber = "+15551234567";
        OwnedPhoneNumberPricing expectedPricing = new()
        {
            IsFreeNumber = true,
            MonthlyCost = 0,
            MonthlyPrice = 0,
            UpfrontCost = 0,
        };
        ApiEnum<string, PhoneNumberStatus> expectedStatus = PhoneNumberStatus.Active;
        string expectedName = "name";
        DateTimeOffset expectedNextRenewalDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSenderID = "senderId";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCapabilities.Count, deserialized.Capabilities.Count);
        for (int i = 0; i < expectedCapabilities.Count; i++)
        {
            Assert.Equal(expectedCapabilities[i], deserialized.Capabilities[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPricing, deserialized.Pricing);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNextRenewalDate, deserialized.NextRenewalDate);
        Assert.Equal(expectedSenderID, deserialized.SenderID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OwnedPhoneNumber
        {
            ID = "id",
            Capabilities = ["sms", "voice"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeNumber = true,
                MonthlyCost = 0,
                MonthlyPrice = 0,
                UpfrontCost = 0,
            },
            Status = PhoneNumberStatus.Active,
            Name = "name",
            NextRenewalDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OwnedPhoneNumber
        {
            ID = "id",
            Capabilities = ["sms", "voice"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeNumber = true,
                MonthlyCost = 0,
                MonthlyPrice = 0,
                UpfrontCost = 0,
            },
            Status = PhoneNumberStatus.Active,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.NextRenewalDate);
        Assert.False(model.RawData.ContainsKey("nextRenewalDate"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OwnedPhoneNumber
        {
            ID = "id",
            Capabilities = ["sms", "voice"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeNumber = true,
                MonthlyCost = 0,
                MonthlyPrice = 0,
                UpfrontCost = 0,
            },
            Status = PhoneNumberStatus.Active,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OwnedPhoneNumber
        {
            ID = "id",
            Capabilities = ["sms", "voice"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeNumber = true,
                MonthlyCost = 0,
                MonthlyPrice = 0,
                UpfrontCost = 0,
            },
            Status = PhoneNumberStatus.Active,

            // Null should be interpreted as omitted for these properties
            Name = null,
            NextRenewalDate = null,
            SenderID = null,
            UpdatedAt = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.NextRenewalDate);
        Assert.False(model.RawData.ContainsKey("nextRenewalDate"));
        Assert.Null(model.SenderID);
        Assert.False(model.RawData.ContainsKey("senderId"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OwnedPhoneNumber
        {
            ID = "id",
            Capabilities = ["sms", "voice"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeNumber = true,
                MonthlyCost = 0,
                MonthlyPrice = 0,
                UpfrontCost = 0,
            },
            Status = PhoneNumberStatus.Active,

            // Null should be interpreted as omitted for these properties
            Name = null,
            NextRenewalDate = null,
            SenderID = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OwnedPhoneNumber
        {
            ID = "id",
            Capabilities = ["sms", "voice"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeNumber = true,
                MonthlyCost = 0,
                MonthlyPrice = 0,
                UpfrontCost = 0,
            },
            Status = PhoneNumberStatus.Active,
            Name = "name",
            NextRenewalDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SenderID = "senderId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        OwnedPhoneNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}
