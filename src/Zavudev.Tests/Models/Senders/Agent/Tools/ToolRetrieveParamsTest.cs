using System;
using Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class ToolRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ToolRetrieveParams { SenderID = "senderId", ToolID = "toolId" };

        string expectedSenderID = "senderId";
        string expectedToolID = "toolId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedToolID, parameters.ToolID);
    }

    [Fact]
    public void Url_Works()
    {
        ToolRetrieveParams parameters = new() { SenderID = "senderId", ToolID = "toolId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/agent/tools/toolId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ToolRetrieveParams { SenderID = "senderId", ToolID = "toolId" };

        ToolRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
