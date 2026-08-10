using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Broadcasts;

namespace Zavudev.Tests.Models.Broadcasts;

public class BroadcastChannelTest : TestBase
{
    [Theory]
    [InlineData(BroadcastChannel.Smart)]
    [InlineData(BroadcastChannel.Sms)]
    [InlineData(BroadcastChannel.SmsOneway)]
    [InlineData(BroadcastChannel.Whatsapp)]
    [InlineData(BroadcastChannel.Telegram)]
    [InlineData(BroadcastChannel.Email)]
    public void Validation_Works(BroadcastChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastChannel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BroadcastChannel.Smart)]
    [InlineData(BroadcastChannel.Sms)]
    [InlineData(BroadcastChannel.SmsOneway)]
    [InlineData(BroadcastChannel.Whatsapp)]
    [InlineData(BroadcastChannel.Telegram)]
    [InlineData(BroadcastChannel.Email)]
    public void SerializationRoundtrip_Works(BroadcastChannel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BroadcastChannel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BroadcastChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BroadcastChannel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BroadcastChannel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
