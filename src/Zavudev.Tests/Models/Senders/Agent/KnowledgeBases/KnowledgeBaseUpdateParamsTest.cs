using System;
using Zavudev.Models.Senders.Agent.KnowledgeBases;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases;

public class KnowledgeBaseUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new KnowledgeBaseUpdateParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            Description = "description",
            Name = "name",
        };

        string expectedSenderID = "senderId";
        string expectedKBID = "kbId";
        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedKBID, parameters.KBID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new KnowledgeBaseUpdateParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            Description = "description",
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new KnowledgeBaseUpdateParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            Description = "description",

            // Null should be interpreted as omitted for these properties
            Name = null,
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new KnowledgeBaseUpdateParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            Name = "name",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new KnowledgeBaseUpdateParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            Name = "name",

            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        KnowledgeBaseUpdateParams parameters = new() { SenderID = "senderId", KBID = "kbId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/agent/knowledge-bases/kbId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new KnowledgeBaseUpdateParams
        {
            SenderID = "senderId",
            KBID = "kbId",
            Description = "description",
            Name = "name",
        };

        KnowledgeBaseUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
