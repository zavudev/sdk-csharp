using System;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;
using Zavudev.Models.Senders.Agent.Executions;

namespace Zavudev.Tests.Models.Senders.Agent.Executions;

public class ExecutionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ExecutionListParams
        {
            SenderID = "senderId",
            Cursor = "cursor",
            Limit = 100,
            Status = AgentExecutionStatus.Success,
        };

        string expectedSenderID = "senderId";
        string expectedCursor = "cursor";
        long expectedLimit = 100;
        ApiEnum<string, AgentExecutionStatus> expectedStatus = AgentExecutionStatus.Success;

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedCursor, parameters.Cursor);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ExecutionListParams { SenderID = "senderId" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ExecutionListParams
        {
            SenderID = "senderId",

            // Null should be interpreted as omitted for these properties
            Cursor = null,
            Limit = null,
            Status = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        ExecutionListParams parameters = new()
        {
            SenderID = "senderId",
            Cursor = "cursor",
            Limit = 100,
            Status = AgentExecutionStatus.Success,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/senders/senderId/agent/executions?cursor=cursor&limit=100&status=success"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ExecutionListParams
        {
            SenderID = "senderId",
            Cursor = "cursor",
            Limit = 100,
            Status = AgentExecutionStatus.Success,
        };

        ExecutionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
