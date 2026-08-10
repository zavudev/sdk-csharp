using System;
using Zavudev.Models.Senders.Agent.KnowledgeBases;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases;

public class KnowledgeBaseListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new KnowledgeBaseListParams
        {
            SenderID = "senderId",
            Cursor = "cursor",
            Limit = 100,
        };

        string expectedSenderID = "senderId";
        string expectedCursor = "cursor";
        long expectedLimit = 100;

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new KnowledgeBaseListParams { SenderID = "senderId" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new KnowledgeBaseListParams
        {
            SenderID = "senderId",

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
        KnowledgeBaseListParams parameters = new()
        {
            SenderID = "senderId",
            Cursor = "cursor",
            Limit = 100,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/senders/senderId/agent/knowledge-bases?cursor=cursor&limit=100"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new KnowledgeBaseListParams
        {
            SenderID = "senderId",
            Cursor = "cursor",
            Limit = 100,
        };

        KnowledgeBaseListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
