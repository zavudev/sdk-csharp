using System;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageRetrieveParams { MessageID = "messageId" };

        string expectedMessageID = "messageId";

        Assert.Equal(expectedMessageID, parameters.MessageID);
    }

    [Fact]
    public void Url_Works()
    {
        MessageRetrieveParams parameters = new() { MessageID = "messageId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/messages/messageId"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageRetrieveParams { MessageID = "messageId" };

        MessageRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
