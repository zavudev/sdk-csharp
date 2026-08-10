using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageChannelTest : TestBase
{
    [Theory]
    [InlineData(MessageChannel.Auto)]
    [InlineData(MessageChannel.Sms)]
    [InlineData(MessageChannel.SmsOneway)]
    [InlineData(MessageChannel.Whatsapp)]
    [InlineData(MessageChannel.Telegram)]
    [InlineData(MessageChannel.Email)]
    [InlineData(MessageChannel.Instagram)]
    [InlineData(MessageChannel.Messenger)]
    [InlineData(MessageChannel.Voice)]
    public void Validation_Works(MessageChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessageChannel.Auto)]
    [InlineData(MessageChannel.Sms)]
    [InlineData(MessageChannel.SmsOneway)]
    [InlineData(MessageChannel.Whatsapp)]
    [InlineData(MessageChannel.Telegram)]
    [InlineData(MessageChannel.Email)]
    [InlineData(MessageChannel.Instagram)]
    [InlineData(MessageChannel.Messenger)]
    [InlineData(MessageChannel.Voice)]
    public void SerializationRoundtrip_Works(MessageChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
