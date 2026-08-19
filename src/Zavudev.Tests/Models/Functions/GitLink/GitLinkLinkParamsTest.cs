using System;
using Zavudev.Models.Functions.GitLink;

namespace Zavudev.Tests.Models.Functions.GitLink;

public class GitLinkLinkParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GitLinkLinkParams
        {
            FunctionID = "functionId",
            Owner = "acme",
            Repo = "order-bot",
            AutoDeploy = true,
            Branch = "main",
            RootDir = "apps/bot",
        };

        string expectedFunctionID = "functionId";
        string expectedOwner = "acme";
        string expectedRepo = "order-bot";
        bool expectedAutoDeploy = true;
        string expectedBranch = "main";
        string expectedRootDir = "apps/bot";

        Assert.Equal(expectedFunctionID, parameters.FunctionID);
        Assert.Equal(expectedOwner, parameters.Owner);
        Assert.Equal(expectedRepo, parameters.Repo);
        Assert.Equal(expectedAutoDeploy, parameters.AutoDeploy);
        Assert.Equal(expectedBranch, parameters.Branch);
        Assert.Equal(expectedRootDir, parameters.RootDir);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GitLinkLinkParams
        {
            FunctionID = "functionId",
            Owner = "acme",
            Repo = "order-bot",
        };

        Assert.Null(parameters.AutoDeploy);
        Assert.False(parameters.RawBodyData.ContainsKey("autoDeploy"));
        Assert.Null(parameters.Branch);
        Assert.False(parameters.RawBodyData.ContainsKey("branch"));
        Assert.Null(parameters.RootDir);
        Assert.False(parameters.RawBodyData.ContainsKey("rootDir"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new GitLinkLinkParams
        {
            FunctionID = "functionId",
            Owner = "acme",
            Repo = "order-bot",

            // Null should be interpreted as omitted for these properties
            AutoDeploy = null,
            Branch = null,
            RootDir = null,
        };

        Assert.Null(parameters.AutoDeploy);
        Assert.False(parameters.RawBodyData.ContainsKey("autoDeploy"));
        Assert.Null(parameters.Branch);
        Assert.False(parameters.RawBodyData.ContainsKey("branch"));
        Assert.Null(parameters.RootDir);
        Assert.False(parameters.RawBodyData.ContainsKey("rootDir"));
    }

    [Fact]
    public void Url_Works()
    {
        GitLinkLinkParams parameters = new()
        {
            FunctionID = "functionId",
            Owner = "acme",
            Repo = "order-bot",
        };

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
        var parameters = new GitLinkLinkParams
        {
            FunctionID = "functionId",
            Owner = "acme",
            Repo = "order-bot",
            AutoDeploy = true,
            Branch = "main",
            RootDir = "apps/bot",
        };

        GitLinkLinkParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
