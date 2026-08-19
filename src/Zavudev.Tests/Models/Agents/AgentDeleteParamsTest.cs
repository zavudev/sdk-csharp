using System;
using Zavudev.Models.Agents;

namespace Zavudev.Tests.Models.Agents;

public class AgentDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentDeleteParams { AgentID = "agentId" };

        string expectedAgentID = "agentId";

        Assert.Equal(expectedAgentID, parameters.AgentID);
    }

    [Fact]
    public void Url_Works()
    {
        AgentDeleteParams parameters = new() { AgentID = "agentId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/agents/agentId"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentDeleteParams { AgentID = "agentId" };

        AgentDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
