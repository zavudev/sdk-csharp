using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Addresses;

namespace Zavudev.Tests.Models.Addresses;

public class AddressStatusTest : TestBase
{
    [Theory]
    [InlineData(AddressStatus.Pending)]
    [InlineData(AddressStatus.Verified)]
    [InlineData(AddressStatus.Rejected)]
    public void Validation_Works(AddressStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddressStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddressStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddressStatus.Pending)]
    [InlineData(AddressStatus.Verified)]
    [InlineData(AddressStatus.Rejected)]
    public void SerializationRoundtrip_Works(AddressStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddressStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AddressStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddressStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AddressStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
