using System;
using Zavudev.Models.Senders.Agent.KnowledgeBases;

namespace Zavudev.Tests.Models.Senders.Agent.KnowledgeBases;

public class KnowledgeBaseRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new KnowledgeBaseRetrieveParams { SenderID = "senderId", KBID = "kbId" };

        string expectedSenderID = "senderId";
        string expectedKBID = "kbId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedKBID, parameters.KBID);
    }

    [Fact]
    public void Url_Works()
    {
        KnowledgeBaseRetrieveParams parameters = new() { SenderID = "senderId", KBID = "kbId" };

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
        var parameters = new KnowledgeBaseRetrieveParams { SenderID = "senderId", KBID = "kbId" };

        KnowledgeBaseRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
