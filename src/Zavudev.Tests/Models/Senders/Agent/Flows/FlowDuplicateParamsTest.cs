using System;
using Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Tests.Models.Senders.Agent.Flows;

public class FlowDuplicateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FlowDuplicateParams
        {
            SenderID = "senderId",
            FlowID = "flowId",
            NewName = "Lead Capture (Copy)",
        };

        string expectedSenderID = "senderId";
        string expectedFlowID = "flowId";
        string expectedNewName = "Lead Capture (Copy)";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedFlowID, parameters.FlowID);
        Assert.Equal(expectedNewName, parameters.NewName);
    }

    [Fact]
    public void Url_Works()
    {
        FlowDuplicateParams parameters = new()
        {
            SenderID = "senderId",
            FlowID = "flowId",
            NewName = "Lead Capture (Copy)",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/agent/flows/flowId/duplicate"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FlowDuplicateParams
        {
            SenderID = "senderId",
            FlowID = "flowId",
            NewName = "Lead Capture (Copy)",
        };

        FlowDuplicateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
