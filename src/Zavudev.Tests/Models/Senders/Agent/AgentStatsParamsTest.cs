using System;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Tests.Models.Senders.Agent;

public class AgentStatsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentStatsParams { SenderID = "senderId" };

        string expectedSenderID = "senderId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
    }

    [Fact]
    public void Url_Works()
    {
        AgentStatsParams parameters = new() { SenderID = "senderId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/senders/senderId/agent/stats"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentStatsParams { SenderID = "senderId" };

        AgentStatsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
