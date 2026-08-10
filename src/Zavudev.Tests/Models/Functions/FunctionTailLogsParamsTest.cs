using System;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionTailLogsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionTailLogsParams
        {
            FunctionID = "functionId",
            EndTime = 0,
            FilterPattern = "filterPattern",
            Limit = 1,
            NextToken = "nextToken",
            StartTime = 0,
        };

        string expectedFunctionID = "functionId";
        long expectedEndTime = 0;
        string expectedFilterPattern = "filterPattern";
        long expectedLimit = 1;
        string expectedNextToken = "nextToken";
        long expectedStartTime = 0;

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
        Assert.Equal(expectedEndTime, parameters.EndTime);
        Assert.Equal(expectedFilterPattern, parameters.FilterPattern);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedNextToken, parameters.NextToken);
        Assert.Equal(expectedStartTime, parameters.StartTime);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FunctionTailLogsParams { FunctionID = "functionId" };

        Assert.Null(parameters.EndTime);
        Assert.False(parameters.RawQueryData.ContainsKey("endTime"));
        Assert.Null(parameters.FilterPattern);
        Assert.False(parameters.RawQueryData.ContainsKey("filterPattern"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.NextToken);
        Assert.False(parameters.RawQueryData.ContainsKey("nextToken"));
        Assert.Null(parameters.StartTime);
        Assert.False(parameters.RawQueryData.ContainsKey("startTime"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FunctionTailLogsParams
        {
            FunctionID = "functionId",

            // Null should be interpreted as omitted for these properties
            EndTime = null,
            FilterPattern = null,
            Limit = null,
            NextToken = null,
            StartTime = null,
        };

        Assert.Null(parameters.EndTime);
        Assert.False(parameters.RawQueryData.ContainsKey("endTime"));
        Assert.Null(parameters.FilterPattern);
        Assert.False(parameters.RawQueryData.ContainsKey("filterPattern"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.NextToken);
        Assert.False(parameters.RawQueryData.ContainsKey("nextToken"));
        Assert.Null(parameters.StartTime);
        Assert.False(parameters.RawQueryData.ContainsKey("startTime"));
    }

    [Fact]
    public void Url_Works()
    {
        FunctionTailLogsParams parameters = new()
        {
            FunctionID = "functionId",
            EndTime = 0,
            FilterPattern = "filterPattern",
            Limit = 1,
            NextToken = "nextToken",
            StartTime = 0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.zavu.dev/v1/functions/functionId/logs?endTime=0&filterPattern=filterPattern&limit=1&nextToken=nextToken&startTime=0"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionTailLogsParams
        {
            FunctionID = "functionId",
            EndTime = 0,
            FilterPattern = "filterPattern",
            Limit = 1,
            NextToken = "nextToken",
            StartTime = 0,
        };

        FunctionTailLogsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
