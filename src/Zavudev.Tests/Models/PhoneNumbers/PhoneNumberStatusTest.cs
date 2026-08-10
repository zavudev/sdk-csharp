using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberStatusTest : TestBase
{
    [Theory]
    [InlineData(PhoneNumberStatus.Active)]
    [InlineData(PhoneNumberStatus.Suspended)]
    [InlineData(PhoneNumberStatus.Pending)]
    public void Validation_Works(PhoneNumberStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhoneNumberStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhoneNumberStatus.Active)]
    [InlineData(PhoneNumberStatus.Suspended)]
    [InlineData(PhoneNumberStatus.Pending)]
    public void SerializationRoundtrip_Works(PhoneNumberStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhoneNumberStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
