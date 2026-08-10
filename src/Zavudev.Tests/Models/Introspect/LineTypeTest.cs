using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Introspect;

namespace Zavudev.Tests.Models.Introspect;

public class LineTypeTest : TestBase
{
    [Theory]
    [InlineData(LineType.Mobile)]
    [InlineData(LineType.Landline)]
    [InlineData(LineType.Voip)]
    [InlineData(LineType.TollFree)]
    [InlineData(LineType.Unknown)]
    public void Validation_Works(LineType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LineType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LineType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(LineType.Mobile)]
    [InlineData(LineType.Landline)]
    [InlineData(LineType.Voip)]
    [InlineData(LineType.TollFree)]
    [InlineData(LineType.Unknown)]
    public void SerializationRoundtrip_Works(LineType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, LineType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LineType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, LineType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, LineType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
