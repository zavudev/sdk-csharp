using System;
using Zavudev.Models.Functions.GitLink;

namespace Zavudev.Tests.Models.Functions.GitLink;

public class GitLinkDeployNowParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GitLinkDeployNowParams { FunctionID = "functionId" };

        string expectedFunctionID = "functionId";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
    }

    [Fact]
    public void Url_Works()
    {
        GitLinkDeployNowParams parameters = new() { FunctionID = "functionId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/functions/functionId/git-link/deploy"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GitLinkDeployNowParams { FunctionID = "functionId" };

        GitLinkDeployNowParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
