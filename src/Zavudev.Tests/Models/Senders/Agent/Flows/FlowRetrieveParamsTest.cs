using System;
using Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Models.Senders.Agent.Flows;

public class FlowRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FlowRetrieveParams { SenderID = "senderId", FlowID = "flowId" };

        string expectedSenderID = "senderId";
        string expectedFlowID = "flowId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedFlowID, parameters.FlowID);
    }

    [Fact]
    public void Url_Works()
    {
        FlowRetrieveParams parameters = new() { SenderID = "senderId", FlowID = "flowId" };

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
        var parameters = new FlowRetrieveParams { SenderID = "senderId", FlowID = "flowId" };

        FlowRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
