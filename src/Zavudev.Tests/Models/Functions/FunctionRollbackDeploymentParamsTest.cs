using System;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionRollbackDeploymentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionRollbackDeploymentParams
        {
            FunctionID = "functionId",
            DeploymentID = "fnd_abc123",
        };

        string expectedFunctionID = "functionId";
        string expectedDeploymentID = "fnd_abc123";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
        Assert.Equal(expectedDeploymentID, parameters.DeploymentID);
    }

    [Fact]
    public void Url_Works()
    {
        FunctionRollbackDeploymentParams parameters = new()
        {
            FunctionID = "functionId",
            DeploymentID = "fnd_abc123",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/functions/functionId/rollback"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionRollbackDeploymentParams
        {
            FunctionID = "functionId",
            DeploymentID = "fnd_abc123",
        };

        FunctionRollbackDeploymentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
