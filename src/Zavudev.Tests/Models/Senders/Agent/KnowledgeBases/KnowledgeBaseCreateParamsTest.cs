using System;
using Zavudev.Models.Senders.Agent.KnowledgeBases;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases;

public class KnowledgeBaseCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new KnowledgeBaseCreateParams
        {
            SenderID = "senderId",
            Name = "Product FAQ",
            Description = "Frequently asked questions about our products",
        };

        string expectedSenderID = "senderId";
        string expectedName = "Product FAQ";
        string expectedDescription = "Frequently asked questions about our products";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDescription, parameters.Description);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new KnowledgeBaseCreateParams
        {
            SenderID = "senderId",
            Name = "Product FAQ",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new KnowledgeBaseCreateParams
        {
            SenderID = "senderId",
            Name = "Product FAQ",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
    }

    [Fact]
    public void Url_Works()
    {
        KnowledgeBaseCreateParams parameters = new()
        {
            SenderID = "senderId",
            Name = "Product FAQ",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/agent/knowledge-bases"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new KnowledgeBaseCreateParams
        {
            SenderID = "senderId",
            Name = "Product FAQ",
            Description = "Frequently asked questions about our products",
        };

        KnowledgeBaseCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
