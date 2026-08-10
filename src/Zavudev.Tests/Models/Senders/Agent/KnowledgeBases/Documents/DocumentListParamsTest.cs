using System;
using Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases.Documents;

public class DocumentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DocumentListParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            Cursor = "cursor",
            Limit = 100,
        };

        string expectedSenderID = "senderId";
        string expectedKBID = "kbId";
        string expectedCursor = "cursor";
        long expectedLimit = 100;

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedKBID, parameters.KBID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DocumentListParams { SenderID = "senderId", KBID = "kbId" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DocumentListParams
        {
            SenderID = "senderId",
            KBID = "kbId",

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
        DocumentListParams parameters = new()
        {
            SenderID = "senderId",
            KBID = "kbId",
            Cursor = "cursor",
            Limit = 100,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/senders/senderId/agent/knowledge-bases/kbId/documents?cursor=cursor&limit=100"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DocumentListParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            Cursor = "cursor",
            Limit = 100,
        };

        DocumentListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
