using System;
using Zavudev.Models.Agents.Senders;

namespace Zavudev.Tests.Models.Agents.Senders;

public class SenderDisconnectParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SenderDisconnectParams { AgentID = "agentId", SenderID = "senderId" };

        string expectedAgentID = "agentId";
        string expectedSenderID = "senderId";

        Assert.Equal(expectedAgentID, parameters.AgentID);
        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void Url_Works()
    {
        SenderDisconnectParams parameters = new() { AgentID = "agentId", SenderID = "senderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/agents/agentId/senders/senderId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SenderDisconnectParams { AgentID = "agentId", SenderID = "senderId" };

        SenderDisconnectParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
