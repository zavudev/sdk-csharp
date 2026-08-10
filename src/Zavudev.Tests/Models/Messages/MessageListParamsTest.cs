using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageListParams
        {
            Channel = Channel.Sms,
            Cursor = "cursor",
            Limit = 100,
            Status = Status.Queued,
            To = "to",
        };

        ApiEnum<string, Channel> expectedChannel = Channel.Sms;
        string expectedCursor = "cursor";
        long expectedLimit = 100;
        ApiEnum<string, Status> expectedStatus = Status.Queued;
        string expectedTo = "to";

        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedTo, parameters.To);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageListParams { };

        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawQueryData.ContainsKey("channel"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawQueryData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MessageListParams
        {
            // Null should be interpreted as omitted for these properties
            Channel = null,
            Cursor = null,
            Limit = null,
            Status = null,
            To = null,
        };

        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawQueryData.ContainsKey("channel"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
        Assert.Null(parameters.To);
        Assert.False(parameters.RawQueryData.ContainsKey("to"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageListParams parameters = new()
        {
            Channel = Channel.Sms,
            Cursor = "cursor",
            Limit = 100,
            Status = Status.Queued,
            To = "to",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/messages?channel=sms&cursor=cursor&limit=100&status=queued&to=to"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageListParams
        {
            Channel = Channel.Sms,
            Cursor = "cursor",
            Limit = 100,
            Status = Status.Queued,
            To = "to",
        };

        MessageListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ChannelTest : TestBase
{
    [Theory]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.SmsOneway)]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Email)]
    [InlineData(Channel.Telegram)]
    [InlineData(Channel.Instagram)]
    [InlineData(Channel.Messenger)]
    [InlineData(Channel.Voice)]
    public void Validation_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Channel.Sms)]
    [InlineData(Channel.SmsOneway)]
    [InlineData(Channel.Whatsapp)]
    [InlineData(Channel.Email)]
    [InlineData(Channel.Telegram)]
    [InlineData(Channel.Instagram)]
    [InlineData(Channel.Messenger)]
    [InlineData(Channel.Voice)]
    public void SerializationRoundtrip_Works(Channel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Channel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Channel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Queued)]
    [InlineData(Status.Sending)]
    [InlineData(Status.Sent)]
    [InlineData(Status.Delivered)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Received)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Queued)]
    [InlineData(Status.Sending)]
    [InlineData(Status.Sent)]
    [InlineData(Status.Delivered)]
    [InlineData(Status.Failed)]
    [InlineData(Status.Received)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
