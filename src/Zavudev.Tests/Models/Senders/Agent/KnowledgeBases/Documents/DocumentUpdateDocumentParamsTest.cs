using System;
using Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases.Documents;

public class DocumentUpdateDocumentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentUpdateDocumentParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            DocID = "docId",
            Content = "content",
            Title = "title",
        };

        string expectedSenderID = "senderId";
        string expectedKBID = "kbId";
        string expectedDocID = "docId";
        string expectedContent = "content";
        string expectedTitle = "title";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedKBID, parameters.KBID);
        Assert.Equal(expectedDocID, parameters.DocID);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedTitle, parameters.Title);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DocumentUpdateDocumentParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            DocID = "docId",
        };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DocumentUpdateDocumentParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            DocID = "docId",

            // Null should be interpreted as omitted for these properties
            Content = null,
            Title = null,
        };

        Assert.Null(parameters.Content);
        Assert.False(parameters.RawBodyData.ContainsKey("content"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
    }

    [Fact]
    public void Url_Works()
    {
        DocumentUpdateDocumentParams parameters = new()
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
        var parameters = new DocumentUpdateDocumentParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            DocID = "docId",
            Content = "content",
            Title = "title",
        };

        DocumentUpdateDocumentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
