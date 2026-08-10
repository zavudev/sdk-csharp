using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberCapabilitiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneNumberCapabilities
        {
            Mms = true,
            Sms = true,
            Voice = true,
        };

        bool expectedMms = true;
        bool expectedSms = true;
        bool expectedVoice = true;

        Assert.Equal(expectedMms, model.Mms);
        Assert.Equal(expectedSms, model.Sms);
        Assert.Equal(expectedVoice, model.Voice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneNumberCapabilities
        {
            Mms = true,
            Sms = true,
            Voice = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberCapabilities>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneNumberCapabilities
        {
            Mms = true,
            Sms = true,
            Voice = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberCapabilities>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedMms = true;
        bool expectedSms = true;
        bool expectedVoice = true;

        Assert.Equal(expectedMms, deserialized.Mms);
        Assert.Equal(expectedSms, deserialized.Sms);
        Assert.Equal(expectedVoice, deserialized.Voice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneNumberCapabilities
        {
            Mms = true,
            Sms = true,
            Voice = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PhoneNumberCapabilities { };

        Assert.Null(model.Mms);
        Assert.False(model.RawData.ContainsKey("mms"));
        Assert.Null(model.Sms);
        Assert.False(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Voice);
        Assert.False(model.RawData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PhoneNumberCapabilities { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PhoneNumberCapabilities
        {
            // Null should be interpreted as omitted for these properties
            Mms = null,
            Sms = null,
            Voice = null,
        };

        Assert.Null(model.Mms);
        Assert.False(model.RawData.ContainsKey("mms"));
        Assert.Null(model.Sms);
        Assert.False(model.RawData.ContainsKey("sms"));
        Assert.Null(model.Voice);
        Assert.False(model.RawData.ContainsKey("voice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PhoneNumberCapabilities
        {
            // Null should be interpreted as omitted for these properties
            Mms = null,
            Sms = null,
            Voice = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneNumberCapabilities
        {
            Mms = true,
            Sms = true,
            Voice = true,
        };

        PhoneNumberCapabilities copied = new(model);

        Assert.Equal(model, copied);
    }
}
