using System;
using Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class ToolListTestRunsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ToolListTestRunsParams
        {
            SenderID = "senderId",
            ToolID = "toolId",
            Limit = 100,
        };

        string expectedSenderID = "senderId";
        string expectedToolID = "toolId";
        long expectedLimit = 100;

        Assert.Equal(expectedSenderID, parameters.SenderID);
        Assert.Equal(expectedToolID, parameters.ToolID);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ToolListTestRunsParams { SenderID = "senderId", ToolID = "toolId" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ToolListTestRunsParams
        {
            SenderID = "senderId",
            ToolID = "toolId",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        ToolListTestRunsParams parameters = new()
        {
            SenderID = "senderId",
            ToolID = "toolId",
            Limit = 100,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/senders/senderId/agent/tools/toolId/test-runs?limit=100"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ToolListTestRunsParams
        {
            SenderID = "senderId",
            ToolID = "toolId",
            Limit = 100,
        };

        ToolListTestRunsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
