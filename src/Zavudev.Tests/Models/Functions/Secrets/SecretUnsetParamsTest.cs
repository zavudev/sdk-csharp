using System;
using Zavudev.Models.Functions.Secrets;

namespace Zavudev.Tests.Models.Functions.Secrets;

public class SecretUnsetParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SecretUnsetParams { FunctionID = "functionId", Key = "key" };

        string expectedFunctionID = "functionId";
        string expectedKey = "key";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
        Assert.Equal(expectedKey, parameters.Key);
    }

    [Fact]
    public void Url_Works()
    {
        SecretUnsetParams parameters = new() { FunctionID = "functionId", Key = "key" };

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
        var parameters = new SecretUnsetParams { FunctionID = "functionId", Key = "key" };

        SecretUnsetParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
