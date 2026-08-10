using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastMessageTypeTest : TestBase
{
    [Theory]
    [InlineData(BroadcastMessageType.Text)]
    [InlineData(BroadcastMessageType.Image)]
    [InlineData(BroadcastMessageType.Video)]
    [InlineData(BroadcastMessageType.Audio)]
    [InlineData(BroadcastMessageType.Document)]
    [InlineData(BroadcastMessageType.Template)]
    public void Validation_Works(BroadcastMessageType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastMessageType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastMessageType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BroadcastMessageType.Text)]
    [InlineData(BroadcastMessageType.Image)]
    [InlineData(BroadcastMessageType.Video)]
    [InlineData(BroadcastMessageType.Audio)]
    [InlineData(BroadcastMessageType.Document)]
    [InlineData(BroadcastMessageType.Template)]
    public void SerializationRoundtrip_Works(BroadcastMessageType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastMessageType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BroadcastMessageType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastMessageType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BroadcastMessageType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
