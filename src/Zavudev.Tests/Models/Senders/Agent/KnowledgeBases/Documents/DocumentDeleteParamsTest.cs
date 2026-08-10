using System;
using Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases.Documents;

public class DocumentDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentDeleteParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            DocID = "docId",
        };

        string expectedSenderID = "senderId";
        string expectedKBID = "kbId";
        string expectedDocID = "docId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedKBID, parameters.KBID);
        Assert.Equal(expectedDocID, parameters.DocID);
    }

    [Fact]
    public void Url_Works()
    {
        DocumentDeleteParams parameters = new()
        {
            SenderID = "senderId",
            KBID = "kbId",
            DocID = "docId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/senders/senderId/agent/knowledge-bases/kbId/documents/docId"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DocumentDeleteParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            DocID = "docId",
        };

        DocumentDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
