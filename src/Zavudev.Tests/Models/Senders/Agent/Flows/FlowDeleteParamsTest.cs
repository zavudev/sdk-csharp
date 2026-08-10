using System;
using Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Models.Senders.Agent.Flows;

public class FlowDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FlowDeleteParams { SenderID = "senderId", FlowID = "flowId" };

        string expectedSenderID = "senderId";
        string expectedFlowID = "flowId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedFlowID, parameters.FlowID);
    }

    [Fact]
    public void Url_Works()
    {
        FlowDeleteParams parameters = new() { SenderID = "senderId", FlowID = "flowId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/agent/flows/flowId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FlowDeleteParams { SenderID = "senderId", FlowID = "flowId" };

        FlowDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
