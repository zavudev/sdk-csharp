using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class AvailablePhoneNumberTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AvailablePhoneNumber
        {
            Capabilities = new()
            {
                Mms = true,
                Sms = true,
                Voice = true,
            },
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeEligible = true,
                MonthlyPrice = 0,
                UpfrontPrice = 0,
            },
            FriendlyName = "(555) 123-4567",
            Locality = "San Francisco",
            Region = "CA",
        };

        PhoneNumberCapabilities expectedCapabilities = new()
        {
            Mms = true,
            Sms = true,
            Voice = true,
        };
        string expectedPhoneNumber = "+15551234567";
        PhoneNumberPricing expectedPricing = new()
        {
            IsFreeEligible = true,
            MonthlyPrice = 0,
            UpfrontPrice = 0,
        };
        string expectedFriendlyName = "(555) 123-4567";
        string expectedLocality = "San Francisco";
        string expectedRegion = "CA";

        Assert.Equal(expectedCapabilities, model.Capabilities);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPricing, model.Pricing);
        Assert.Equal(expectedFriendlyName, model.FriendlyName);
        Assert.Equal(expectedLocality, model.Locality);
        Assert.Equal(expectedRegion, model.Region);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AvailablePhoneNumber
        {
            Capabilities = new()
            {
                Mms = true,
                Sms = true,
                Voice = true,
            },
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeEligible = true,
                MonthlyPrice = 0,
                UpfrontPrice = 0,
            },
            FriendlyName = "(555) 123-4567",
            Locality = "San Francisco",
            Region = "CA",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AvailablePhoneNumber>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AvailablePhoneNumber
        {
            Capabilities = new()
            {
                Mms = true,
                Sms = true,
                Voice = true,
            },
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeEligible = true,
                MonthlyPrice = 0,
                UpfrontPrice = 0,
            },
            FriendlyName = "(555) 123-4567",
            Locality = "San Francisco",
            Region = "CA",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AvailablePhoneNumber>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PhoneNumberCapabilities expectedCapabilities = new()
        {
            Mms = true,
            Sms = true,
            Voice = true,
        };
        string expectedPhoneNumber = "+15551234567";
        PhoneNumberPricing expectedPricing = new()
        {
            IsFreeEligible = true,
            MonthlyPrice = 0,
            UpfrontPrice = 0,
        };
        string expectedFriendlyName = "(555) 123-4567";
        string expectedLocality = "San Francisco";
        string expectedRegion = "CA";

        Assert.Equal(expectedCapabilities, deserialized.Capabilities);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPricing, deserialized.Pricing);
        Assert.Equal(expectedFriendlyName, deserialized.FriendlyName);
        Assert.Equal(expectedLocality, deserialized.Locality);
        Assert.Equal(expectedRegion, deserialized.Region);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AvailablePhoneNumber
        {
            Capabilities = new()
            {
                Mms = true,
                Sms = true,
                Voice = true,
            },
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeEligible = true,
                MonthlyPrice = 0,
                UpfrontPrice = 0,
            },
            FriendlyName = "(555) 123-4567",
            Locality = "San Francisco",
            Region = "CA",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AvailablePhoneNumber
        {
            Capabilities = new()
            {
                Mms = true,
                Sms = true,
                Voice = true,
            },
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeEligible = true,
                MonthlyPrice = 0,
                UpfrontPrice = 0,
            },
        };

        Assert.Null(model.FriendlyName);
        Assert.False(model.RawData.ContainsKey("friendlyName"));
        Assert.Null(model.Locality);
        Assert.False(model.RawData.ContainsKey("locality"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new AvailablePhoneNumber
        {
            Capabilities = new()
            {
                Mms = true,
                Sms = true,
                Voice = true,
            },
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeEligible = true,
                MonthlyPrice = 0,
                UpfrontPrice = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new AvailablePhoneNumber
        {
            Capabilities = new()
            {
                Mms = true,
                Sms = true,
                Voice = true,
            },
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeEligible = true,
                MonthlyPrice = 0,
                UpfrontPrice = 0,
            },

            // Null should be interpreted as omitted for these properties
            FriendlyName = null,
            Locality = null,
            Region = null,
        };

        Assert.Null(model.FriendlyName);
        Assert.False(model.RawData.ContainsKey("friendlyName"));
        Assert.Null(model.Locality);
        Assert.False(model.RawData.ContainsKey("locality"));
        Assert.Null(model.Region);
        Assert.False(model.RawData.ContainsKey("region"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new AvailablePhoneNumber
        {
            Capabilities = new()
            {
                Mms = true,
                Sms = true,
                Voice = true,
            },
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeEligible = true,
                MonthlyPrice = 0,
                UpfrontPrice = 0,
            },

            // Null should be interpreted as omitted for these properties
            FriendlyName = null,
            Locality = null,
            Region = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AvailablePhoneNumber
        {
            Capabilities = new()
            {
                Mms = true,
                Sms = true,
                Voice = true,
            },
            PhoneNumber = "+15551234567",
            Pricing = new()
            {
                IsFreeEligible = true,
                MonthlyPrice = 0,
                UpfrontPrice = 0,
            },
            FriendlyName = "(555) 123-4567",
            Locality = "San Francisco",
            Region = "CA",
        };

        AvailablePhoneNumber copied = new(model);

        Assert.Equal(model, copied);
    }
}
