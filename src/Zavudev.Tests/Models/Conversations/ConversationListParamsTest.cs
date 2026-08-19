using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Conversations;

namespace Zavudev.Tests.Models.Conversations;

public class ConversationListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConversationListParams
        {
            Channel = Channel.Sms,
            Cursor = "cursor",
            Limit = 100,
            Search = "+56912345678",
            SenderID = "senderId",
        };

        ApiEnum<string, Channel> expectedChannel = Channel.Sms;
        string expectedCursor = "cursor";
        long expectedLimit = 100;
        string expectedSearch = "+56912345678";
        string expectedSenderID = "senderId";

        Assert.Equal(expectedChannel, parameters.Channel);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedSearch, parameters.Search);
        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConversationListParams { };

        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawQueryData.ContainsKey("channel"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.SenderID);
        Assert.False(parameters.RawQueryData.ContainsKey("senderId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConversationListParams
        {
            // Null should be interpreted as omitted for these properties
            Channel = null,
            Cursor = null,
            Limit = null,
            Search = null,
            SenderID = null,
        };

        Assert.Null(parameters.Channel);
        Assert.False(parameters.RawQueryData.ContainsKey("channel"));
        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Search);
        Assert.False(parameters.RawQueryData.ContainsKey("search"));
        Assert.Null(parameters.SenderID);
        Assert.False(parameters.RawQueryData.ContainsKey("senderId"));
    }

    [Fact]
    public void Url_Works()
    {
        ConversationListParams parameters = new()
        {
            Channel = Channel.Sms,
            Cursor = "cursor",
            Limit = 100,
            Search = "+56912345678",
            SenderID = "senderId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/conversations?channel=sms&cursor=cursor&limit=100&search=%2b56912345678&senderId=senderId"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ConversationListParams
        {
            Channel = Channel.Sms,
            Cursor = "cursor",
            Limit = 100,
            Search = "+56912345678",
            SenderID = "senderId",
        };

        ConversationListParams copied = new(parameters);

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
