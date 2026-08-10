using System;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Models.Senders.Agent;

public class AgentDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentDeleteParams { SenderID = "senderId" };

        string expectedSenderID = "senderId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void Url_Works()
    {
        AgentDeleteParams parameters = new() { SenderID = "senderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders/senderId/agent"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentDeleteParams { SenderID = "senderId" };

        AgentDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
