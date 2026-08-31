using System;
using Zavudev.Models.Conversations;

namespace Zavudev.Tests.Models.Conversations;

public class ConversationMarkAsReadParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConversationMarkAsReadParams { ConversationID = "conversationId" };

        string expectedConversationID = "conversationId";

        Assert.Equal(expectedConversationID, parameters.ConversationID);
    }

    [Fact]
    public void Url_Works()
    {
        ConversationMarkAsReadParams parameters = new() { ConversationID = "conversationId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/conversations/conversationId/read"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ConversationMarkAsReadParams { ConversationID = "conversationId" };

        ConversationMarkAsReadParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
