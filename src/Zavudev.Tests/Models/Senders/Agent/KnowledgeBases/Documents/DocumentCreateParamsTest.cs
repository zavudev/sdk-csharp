using System;
using Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases.Documents;

public class DocumentCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentCreateParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            Content = "Our return policy allows returns within 30 days of purchase...",
            Title = "Return Policy",
        };

        string expectedSenderID = "senderId";
        string expectedKBID = "kbId";
        string expectedContent = "Our return policy allows returns within 30 days of purchase...";
        string expectedTitle = "Return Policy";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedKBID, parameters.KBID);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedTitle, parameters.Title);
    }

    [Fact]
    public void Url_Works()
    {
        DocumentCreateParams parameters = new()
        {
            SenderID = "senderId",
            KBID = "kbId",
            Content = "Our return policy allows returns within 30 days of purchase...",
            Title = "Return Policy",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/senders/senderId/agent/knowledge-bases/kbId/documents"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DocumentCreateParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            Content = "Our return policy allows returns within 30 days of purchase...",
            Title = "Return Policy",
        };

        DocumentCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
