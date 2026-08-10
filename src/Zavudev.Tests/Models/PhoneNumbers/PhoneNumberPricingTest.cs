using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberPricingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneNumberPricing
        {
            IsFreeEligible = true,
            MonthlyPrice = 0,
            UpfrontPrice = 0,
        };

        bool expectedIsFreeEligible = true;
        double expectedMonthlyPrice = 0;
        double expectedUpfrontPrice = 0;

        Assert.Equal(expectedIsFreeEligible, model.IsFreeEligible);
        Assert.Equal(expectedMonthlyPrice, model.MonthlyPrice);
        Assert.Equal(expectedUpfrontPrice, model.UpfrontPrice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneNumberPricing
        {
            IsFreeEligible = true,
            MonthlyPrice = 0,
            UpfrontPrice = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberPricing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneNumberPricing
        {
            IsFreeEligible = true,
            MonthlyPrice = 0,
            UpfrontPrice = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberPricing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsFreeEligible = true;
        double expectedMonthlyPrice = 0;
        double expectedUpfrontPrice = 0;

        Assert.Equal(expectedIsFreeEligible, deserialized.IsFreeEligible);
        Assert.Equal(expectedMonthlyPrice, deserialized.MonthlyPrice);
        Assert.Equal(expectedUpfrontPrice, deserialized.UpfrontPrice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneNumberPricing
        {
            IsFreeEligible = true,
            MonthlyPrice = 0,
            UpfrontPrice = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PhoneNumberPricing { };

        Assert.Null(model.IsFreeEligible);
        Assert.False(model.RawData.ContainsKey("isFreeEligible"));
        Assert.Null(model.MonthlyPrice);
        Assert.False(model.RawData.ContainsKey("monthlyPrice"));
        Assert.Null(model.UpfrontPrice);
        Assert.False(model.RawData.ContainsKey("upfrontPrice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PhoneNumberPricing { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PhoneNumberPricing
        {
            // Null should be interpreted as omitted for these properties
            IsFreeEligible = null,
            MonthlyPrice = null,
            UpfrontPrice = null,
        };

        Assert.Null(model.IsFreeEligible);
        Assert.False(model.RawData.ContainsKey("isFreeEligible"));
        Assert.Null(model.MonthlyPrice);
        Assert.False(model.RawData.ContainsKey("monthlyPrice"));
        Assert.Null(model.UpfrontPrice);
        Assert.False(model.RawData.ContainsKey("upfrontPrice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PhoneNumberPricing
        {
            // Null should be interpreted as omitted for these properties
            IsFreeEligible = null,
            MonthlyPrice = null,
            UpfrontPrice = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneNumberPricing
        {
            IsFreeEligible = true,
            MonthlyPrice = 0,
            UpfrontPrice = 0,
        };

        PhoneNumberPricing copied = new(model);

        Assert.Equal(model, copied);
    }
}
