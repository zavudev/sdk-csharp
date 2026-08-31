using System;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionListDeploymentsParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionListDeploymentsParams
        {
            FunctionID = "functionId",
            Limit = 100,
        };

        string expectedFunctionID = "functionId";
        long expectedLimit = 100;

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
        Assert.Equal(expectedLimit, parameters.Limit);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new FunctionListDeploymentsParams { FunctionID = "functionId" };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new FunctionListDeploymentsParams
        {
            FunctionID = "functionId",

            // Null should be interpreted as omitted for these properties
            Limit = null,
        };

        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
    }

    [Fact]
    public void Url_Works()
    {
        FunctionListDeploymentsParams parameters = new() { FunctionID = "functionId", Limit = 100 };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/functions/functionId/deployments?limit=100"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionListDeploymentsParams
        {
            FunctionID = "functionId",
            Limit = 100,
        };

        FunctionListDeploymentsParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
