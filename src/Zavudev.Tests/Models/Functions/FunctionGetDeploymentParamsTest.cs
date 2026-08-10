using System;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionGetDeploymentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FunctionGetDeploymentParams { DeploymentID = "deploymentId" };

        string expectedDeploymentID = "deploymentId";

        Assert.Equal(expectedDeploymentID, parameters.DeploymentID);
    }

    [Fact]
    public void Url_Works()
    {
        FunctionGetDeploymentParams parameters = new() { DeploymentID = "deploymentId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/functions/deployments/deploymentId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FunctionGetDeploymentParams { DeploymentID = "deploymentId" };

        FunctionGetDeploymentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
