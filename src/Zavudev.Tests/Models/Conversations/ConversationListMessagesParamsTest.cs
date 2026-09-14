using System;
using Zavudev.Models.Conversations;

namespace Zavudev.Tests.Models.Conversations;

public class ConversationListMessagesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConversationListMessagesParams
        {
            ConversationID = "conversationId",
            Cursor = "cursor",
            Limit = 100,
        };

        string expectedConversationID = "conversationId";
        string expectedCursor = "cursor";
        long expectedLimit = 100;

        Assert.Equal(expectedConversationID, parameters.ConversationID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConversationListMessagesParams { ConversationID = "conversationId" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConversationListMessagesParams
        {
            ConversationID = "conversationId",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ConversationListMessagesParams parameters = new()
        {
            ConversationID = "conversationId",
            Cursor = "cursor",
            Limit = 100,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/conversations/conversationId/messages?cursor=cursor&limit=100"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ConversationListMessagesParams
        {
            ConversationID = "conversationId",
            Cursor = "cursor",
            Limit = 100,
        };

        ConversationListMessagesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
