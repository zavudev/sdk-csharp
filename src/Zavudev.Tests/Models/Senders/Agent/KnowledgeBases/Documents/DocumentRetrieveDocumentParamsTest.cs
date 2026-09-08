using System;
using Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases.Documents;

public class DocumentRetrieveDocumentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentRetrieveDocumentParams
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
        DocumentRetrieveDocumentParams parameters = new()
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
        var parameters = new DocumentRetrieveDocumentParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            DocID = "docId",
        };

        DocumentRetrieveDocumentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
