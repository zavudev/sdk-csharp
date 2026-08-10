using System;
using Zavudev.Models.Functions.Secrets;

namespace Zavudev.Tests.Models.Functions.Secrets;

public class SecretListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SecretListParams { FunctionID = "functionId" };

        string expectedFunctionID = "functionId";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
    }

    [Fact]
    public void Url_Works()
    {
        SecretListParams parameters = new() { FunctionID = "functionId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/functions/functionId/secrets"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SecretListParams { FunctionID = "functionId" };

        SecretListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
