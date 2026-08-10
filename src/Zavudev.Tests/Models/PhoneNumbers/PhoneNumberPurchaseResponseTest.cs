using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberPurchaseResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneNumberPurchaseResponse
        {
            PhoneNumber = new()
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
            },
        };

        OwnedPhoneNumber expectedPhoneNumber = new()
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

        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneNumberPurchaseResponse
        {
            PhoneNumber = new()
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
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberPurchaseResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneNumberPurchaseResponse
        {
            PhoneNumber = new()
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
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberPurchaseResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        OwnedPhoneNumber expectedPhoneNumber = new()
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

        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneNumberPurchaseResponse
        {
            PhoneNumber = new()
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneNumberPurchaseResponse
        {
            PhoneNumber = new()
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
            },
        };

        PhoneNumberPurchaseResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
