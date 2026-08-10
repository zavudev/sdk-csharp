using System;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionRetrieveParams { FunctionID = "functionId" };

        string expectedFunctionID = "functionId";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
    }

    [Fact]
    public void Url_Works()
    {
        FunctionRetrieveParams parameters = new() { FunctionID = "functionId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/functions/functionId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionRetrieveParams { FunctionID = "functionId" };

        FunctionRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
