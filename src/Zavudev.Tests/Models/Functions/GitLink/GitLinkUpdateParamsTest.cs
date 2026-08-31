using System;
using Zavudev.Models.Functions.GitLink;

namespace Zavudev.Tests.Models.Functions.GitLink;

public class GitLinkUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GitLinkUpdateParams
        {
            FunctionID = "functionId",
            AutoDeploy = false,
            Branch = "branch",
            RootDir = "rootDir",
        };

        string expectedFunctionID = "functionId";
        bool expectedAutoDeploy = false;
        string expectedBranch = "branch";
        string expectedRootDir = "rootDir";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
        Assert.Equal(expectedAutoDeploy, parameters.AutoDeploy);
        Assert.Equal(expectedBranch, parameters.Branch);
        Assert.Equal(expectedRootDir, parameters.RootDir);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GitLinkUpdateParams { FunctionID = "functionId", RootDir = "rootDir" };

        Assert.Null(parameters.AutoDeploy);
        Assert.False(parameters.RawBodyData.ContainsKey("autoDeploy"));
        Assert.Null(parameters.Branch);
        Assert.False(parameters.RawBodyData.ContainsKey("branch"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new GitLinkUpdateParams
        {
            FunctionID = "functionId",
            RootDir = "rootDir",

            // Null should be interpreted as omitted for these properties
            AutoDeploy = null,
            Branch = null,
        };

        Assert.Null(parameters.AutoDeploy);
        Assert.False(parameters.RawBodyData.ContainsKey("autoDeploy"));
        Assert.Null(parameters.Branch);
        Assert.False(parameters.RawBodyData.ContainsKey("branch"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GitLinkUpdateParams
        {
            FunctionID = "functionId",
            AutoDeploy = false,
            Branch = "branch",
        };

        Assert.Null(parameters.RootDir);
        Assert.False(parameters.RawBodyData.ContainsKey("rootDir"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new GitLinkUpdateParams
        {
            FunctionID = "functionId",
            AutoDeploy = false,
            Branch = "branch",

            RootDir = null,
        };

        Assert.Null(parameters.RootDir);
        Assert.True(parameters.RawBodyData.ContainsKey("rootDir"));
    }

    [Fact]
    public void Url_Works()
    {
        GitLinkUpdateParams parameters = new() { FunctionID = "functionId" };

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
        var parameters = new GitLinkUpdateParams
        {
            FunctionID = "functionId",
            AutoDeploy = false,
            Branch = "branch",
            RootDir = "rootDir",
        };

        GitLinkUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
