using System;
using Zavudev.Models.Messages;

namespace Zavudev.Tests.Models.Messages;

public class MessageListAttachmentsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageListAttachmentsParams { MessageID = "messageId" };

        string expectedMessageID = "messageId";

        Assert.Equal(expectedMessageID, parameters.MessageID);
    }

    [Fact]
    public void Url_Works()
    {
        MessageListAttachmentsParams parameters = new() { MessageID = "messageId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/messages/messageId/attachments"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageListAttachmentsParams { MessageID = "messageId" };

        MessageListAttachmentsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
