using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageTypeTest : TestBase
{
    [Theory]
    [InlineData(MessageType.Text)]
    [InlineData(MessageType.Image)]
    [InlineData(MessageType.Video)]
    [InlineData(MessageType.Audio)]
    [InlineData(MessageType.Document)]
    [InlineData(MessageType.Sticker)]
    [InlineData(MessageType.Location)]
    [InlineData(MessageType.Contact)]
    [InlineData(MessageType.Buttons)]
    [InlineData(MessageType.List)]
    [InlineData(MessageType.CtaUrl)]
    [InlineData(MessageType.RequestContactInfo)]
    [InlineData(MessageType.LocationRequest)]
    [InlineData(MessageType.Reaction)]
    [InlineData(MessageType.Template)]
    public void Validation_Works(MessageType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessageType.Text)]
    [InlineData(MessageType.Image)]
    [InlineData(MessageType.Video)]
    [InlineData(MessageType.Audio)]
    [InlineData(MessageType.Document)]
    [InlineData(MessageType.Sticker)]
    [InlineData(MessageType.Location)]
    [InlineData(MessageType.Contact)]
    [InlineData(MessageType.Buttons)]
    [InlineData(MessageType.List)]
    [InlineData(MessageType.CtaUrl)]
    [InlineData(MessageType.RequestContactInfo)]
    [InlineData(MessageType.LocationRequest)]
    [InlineData(MessageType.Reaction)]
    [InlineData(MessageType.Template)]
    public void SerializationRoundtrip_Works(MessageType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
