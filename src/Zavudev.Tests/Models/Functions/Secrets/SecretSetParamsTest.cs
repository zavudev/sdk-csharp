using System;
using Zavudev.Models.Functions.Secrets;

namespace Zavudev.Tests.Models.Functions.Secrets;

public class SecretSetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SecretSetParams
        {
            FunctionID = "functionId",
            Key = "key",
            Value = "value",
        };

        string expectedFunctionID = "functionId";
        string expectedKey = "key";
        string expectedValue = "value";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
        Assert.Equal(expectedKey, parameters.Key);
        Assert.Equal(expectedValue, parameters.Value);
    }

    [Fact]
    public void Url_Works()
    {
        SecretSetParams parameters = new()
        {
            FunctionID = "functionId",
            Key = "key",
            Value = "value",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/functions/functionId/secrets/key"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SecretSetParams
        {
            FunctionID = "functionId",
            Key = "key",
            Value = "value",
        };

        SecretSetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
