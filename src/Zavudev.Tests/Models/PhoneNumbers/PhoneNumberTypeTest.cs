using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberTypeTest : TestBase
{
    [Theory]
    [InlineData(PhoneNumberType.Local)]
    [InlineData(PhoneNumberType.National)]
    [InlineData(PhoneNumberType.TollFree)]
    public void Validation_Works(PhoneNumberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhoneNumberType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PhoneNumberType.Local)]
    [InlineData(PhoneNumberType.National)]
    [InlineData(PhoneNumberType.TollFree)]
    public void SerializationRoundtrip_Works(PhoneNumberType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PhoneNumberType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PhoneNumberType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
