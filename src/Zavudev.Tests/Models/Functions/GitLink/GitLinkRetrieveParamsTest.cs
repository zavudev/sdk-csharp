using System;
using Zavudev.Models.Functions.GitLink;

namespace Zavudev.Tests.Models.Functions.GitLink;

public class GitLinkRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GitLinkRetrieveParams { FunctionID = "functionId" };

        string expectedFunctionID = "functionId";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
    }

    [Fact]
    public void Url_Works()
    {
        GitLinkRetrieveParams parameters = new() { FunctionID = "functionId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.zavu.dev/v1/functions/functionId/git-link"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GitLinkRetrieveParams { FunctionID = "functionId" };

        GitLinkRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
