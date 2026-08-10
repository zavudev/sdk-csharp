using System;
using System.Net.Http;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageReactParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageReactParams
        {
            MessageID = "messageId",
            Emoji = "👍",
            ZavuSender = "sender_12345",
        };

        string expectedMessageID = "messageId";
        string expectedEmoji = "👍";
        string expectedZavuSender = "sender_12345";

        Assert.Equal(expectedMessageID, parameters.MessageID);
        Assert.Equal(expectedEmoji, parameters.Emoji);
        Assert.Equal(expectedZavuSender, parameters.ZavuSender);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new MessageReactParams { MessageID = "messageId", Emoji = "👍" };

        Assert.Null(parameters.ZavuSender);
        Assert.False(parameters.RawHeaderData.ContainsKey("Zavu-Sender"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new MessageReactParams
        {
            MessageID = "messageId",
            Emoji = "👍",

            // Null should be interpreted as omitted for these properties
            ZavuSender = null,
        };

        Assert.Null(parameters.ZavuSender);
        Assert.False(parameters.RawHeaderData.ContainsKey("Zavu-Sender"));
    }

    [Fact]
    public void Url_Works()
    {
        MessageReactParams parameters = new() { MessageID = "messageId", Emoji = "👍" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/messages/messageId/reactions"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        MessageReactParams parameters = new()
        {
            MessageID = "messageId",
            Emoji = "👍",
            ZavuSender = "sender_12345",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["sender_12345"], requestMessage.Headers.GetValues("Zavu-Sender"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageReactParams
        {
            MessageID = "messageId",
            Emoji = "👍",
            ZavuSender = "sender_12345",
        };

        MessageReactParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
