using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class OwnedPhoneNumberPricingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OwnedPhoneNumberPricing
        {
            IsFreeNumber = true,
            MonthlyCost = 0,
            MonthlyPrice = 0,
            UpfrontCost = 0,
        };

        bool expectedIsFreeNumber = true;
        double expectedMonthlyCost = 0;
        double expectedMonthlyPrice = 0;
        double expectedUpfrontCost = 0;

        Assert.Equal(expectedIsFreeNumber, model.IsFreeNumber);
        Assert.Equal(expectedMonthlyCost, model.MonthlyCost);
        Assert.Equal(expectedMonthlyPrice, model.MonthlyPrice);
        Assert.Equal(expectedUpfrontCost, model.UpfrontCost);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OwnedPhoneNumberPricing
        {
            IsFreeNumber = true,
            MonthlyCost = 0,
            MonthlyPrice = 0,
            UpfrontCost = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OwnedPhoneNumberPricing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OwnedPhoneNumberPricing
        {
            IsFreeNumber = true,
            MonthlyCost = 0,
            MonthlyPrice = 0,
            UpfrontCost = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OwnedPhoneNumberPricing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsFreeNumber = true;
        double expectedMonthlyCost = 0;
        double expectedMonthlyPrice = 0;
        double expectedUpfrontCost = 0;

        Assert.Equal(expectedIsFreeNumber, deserialized.IsFreeNumber);
        Assert.Equal(expectedMonthlyCost, deserialized.MonthlyCost);
        Assert.Equal(expectedMonthlyPrice, deserialized.MonthlyPrice);
        Assert.Equal(expectedUpfrontCost, deserialized.UpfrontCost);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OwnedPhoneNumberPricing
        {
            IsFreeNumber = true,
            MonthlyCost = 0,
            MonthlyPrice = 0,
            UpfrontCost = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OwnedPhoneNumberPricing { };

        Assert.Null(model.IsFreeNumber);
        Assert.False(model.RawData.ContainsKey("isFreeNumber"));
        Assert.Null(model.MonthlyCost);
        Assert.False(model.RawData.ContainsKey("monthlyCost"));
        Assert.Null(model.MonthlyPrice);
        Assert.False(model.RawData.ContainsKey("monthlyPrice"));
        Assert.Null(model.UpfrontCost);
        Assert.False(model.RawData.ContainsKey("upfrontCost"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new OwnedPhoneNumberPricing { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new OwnedPhoneNumberPricing
        {
            // Null should be interpreted as omitted for these properties
            IsFreeNumber = null,
            MonthlyCost = null,
            MonthlyPrice = null,
            UpfrontCost = null,
        };

        Assert.Null(model.IsFreeNumber);
        Assert.False(model.RawData.ContainsKey("isFreeNumber"));
        Assert.Null(model.MonthlyCost);
        Assert.False(model.RawData.ContainsKey("monthlyCost"));
        Assert.Null(model.MonthlyPrice);
        Assert.False(model.RawData.ContainsKey("monthlyPrice"));
        Assert.Null(model.UpfrontCost);
        Assert.False(model.RawData.ContainsKey("upfrontCost"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OwnedPhoneNumberPricing
        {
            // Null should be interpreted as omitted for these properties
            IsFreeNumber = null,
            MonthlyCost = null,
            MonthlyPrice = null,
            UpfrontCost = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OwnedPhoneNumberPricing
        {
            IsFreeNumber = true,
            MonthlyCost = 0,
            MonthlyPrice = 0,
            UpfrontCost = 0,
        };

        OwnedPhoneNumberPricing copied = new(model);

        Assert.Equal(model, copied);
    }
}
