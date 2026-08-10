using System;
using Zavudev.Models.Senders.Agent.Executions;

namespace Zavudev.Tests.Models.Senders.Agent.Executions;

public class ExecutionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExecutionRetrieveParams
        {
            SenderID = "senderId",
            ExecutionID = "executionId",
        };

        string expectedSenderID = "senderId";
        string expectedExecutionID = "executionId";

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedExecutionID, parameters.ExecutionID);
    }

    [Fact]
    public void Url_Works()
    {
        ExecutionRetrieveParams parameters = new()
        {
            SenderID = "senderId",
            ExecutionID = "executionId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/senders/senderId/agent/executions/executionId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExecutionRetrieveParams
        {
            SenderID = "senderId",
            ExecutionID = "executionId",
        };

        ExecutionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
