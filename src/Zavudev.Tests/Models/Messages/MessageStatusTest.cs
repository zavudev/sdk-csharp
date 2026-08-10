using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageStatusTest : TestBase
{
    [Theory]
    [InlineData(MessageStatus.Queued)]
    [InlineData(MessageStatus.Sending)]
    [InlineData(MessageStatus.Sent)]
    [InlineData(MessageStatus.Delivered)]
    [InlineData(MessageStatus.Read)]
    [InlineData(MessageStatus.Failed)]
    [InlineData(MessageStatus.Received)]
    [InlineData(MessageStatus.PendingUrlVerification)]
    public void Validation_Works(MessageStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MessageStatus.Queued)]
    [InlineData(MessageStatus.Sending)]
    [InlineData(MessageStatus.Sent)]
    [InlineData(MessageStatus.Delivered)]
    [InlineData(MessageStatus.Read)]
    [InlineData(MessageStatus.Failed)]
    [InlineData(MessageStatus.Received)]
    [InlineData(MessageStatus.PendingUrlVerification)]
    public void SerializationRoundtrip_Works(MessageStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MessageStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MessageStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MessageStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
