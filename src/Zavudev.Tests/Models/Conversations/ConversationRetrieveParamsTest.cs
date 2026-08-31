using System;
using Zavudev.Models.Conversations;

namespace Zavudev.Tests.Models.Conversations;

public class ConversationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConversationRetrieveParams { ConversationID = "conversationId" };

        string expectedConversationID = "conversationId";

        Assert.Equal(expectedConversationID, parameters.ConversationID);
    }

    [Fact]
    public void Url_Works()
    {
        ConversationRetrieveParams parameters = new() { ConversationID = "conversationId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/conversations/conversationId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ConversationRetrieveParams { ConversationID = "conversationId" };

        ConversationRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
