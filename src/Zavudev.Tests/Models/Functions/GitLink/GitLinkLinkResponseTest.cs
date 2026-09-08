using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Functions.GitLink;

namespace Zavudev.Tests.Models.Functions.GitLink;

public class GitLinkLinkResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GitLinkLinkResponse
        {
            Link = new()
            {
                ID = "id",
                AutoDeploy = true,
                Branch = "main",
                Connection = GitLinkLinkResponseLinkConnection.App,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Owner = "acme",
                Provider = GitLinkLinkResponseLinkProvider.GitHub,
                Repo = "order-bot",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastCommitMessage = "lastCommitMessage",
                LastCommitSha = "lastCommitSha",
                LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
                RootDir = "rootDir",
            },
            WebhookUrl = "https://example.com",
            WebhookSecret = "ghs_a1b2c3...",
        };

        GitLinkLinkResponseLink expectedLink = new()
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastCommitMessage = "lastCommitMessage",
            LastCommitSha = "lastCommitSha",
            LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
            RootDir = "rootDir",
        };
        string expectedWebhookUrl = "https://example.com";
        string expectedWebhookSecret = "ghs_a1b2c3...";

        Assert.Equal(expectedLink, model.Link);
        Assert.Equal(expectedWebhookUrl, model.WebhookUrl);
        Assert.Equal(expectedWebhookSecret, model.WebhookSecret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GitLinkLinkResponse
        {
            Link = new()
            {
                ID = "id",
                AutoDeploy = true,
                Branch = "main",
                Connection = GitLinkLinkResponseLinkConnection.App,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Owner = "acme",
                Provider = GitLinkLinkResponseLinkProvider.GitHub,
                Repo = "order-bot",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastCommitMessage = "lastCommitMessage",
                LastCommitSha = "lastCommitSha",
                LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
                RootDir = "rootDir",
            },
            WebhookUrl = "https://example.com",
            WebhookSecret = "ghs_a1b2c3...",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GitLinkLinkResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GitLinkLinkResponse
        {
            Link = new()
            {
                ID = "id",
                AutoDeploy = true,
                Branch = "main",
                Connection = GitLinkLinkResponseLinkConnection.App,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Owner = "acme",
                Provider = GitLinkLinkResponseLinkProvider.GitHub,
                Repo = "order-bot",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastCommitMessage = "lastCommitMessage",
                LastCommitSha = "lastCommitSha",
                LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
                RootDir = "rootDir",
            },
            WebhookUrl = "https://example.com",
            WebhookSecret = "ghs_a1b2c3...",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GitLinkLinkResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        GitLinkLinkResponseLink expectedLink = new()
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastCommitMessage = "lastCommitMessage",
            LastCommitSha = "lastCommitSha",
            LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
            RootDir = "rootDir",
        };
        string expectedWebhookUrl = "https://example.com";
        string expectedWebhookSecret = "ghs_a1b2c3...";

        Assert.Equal(expectedLink, deserialized.Link);
        Assert.Equal(expectedWebhookUrl, deserialized.WebhookUrl);
        Assert.Equal(expectedWebhookSecret, deserialized.WebhookSecret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GitLinkLinkResponse
        {
            Link = new()
            {
                ID = "id",
                AutoDeploy = true,
                Branch = "main",
                Connection = GitLinkLinkResponseLinkConnection.App,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Owner = "acme",
                Provider = GitLinkLinkResponseLinkProvider.GitHub,
                Repo = "order-bot",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastCommitMessage = "lastCommitMessage",
                LastCommitSha = "lastCommitSha",
                LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
                RootDir = "rootDir",
            },
            WebhookUrl = "https://example.com",
            WebhookSecret = "ghs_a1b2c3...",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GitLinkLinkResponse
        {
            Link = new()
            {
                ID = "id",
                AutoDeploy = true,
                Branch = "main",
                Connection = GitLinkLinkResponseLinkConnection.App,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Owner = "acme",
                Provider = GitLinkLinkResponseLinkProvider.GitHub,
                Repo = "order-bot",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastCommitMessage = "lastCommitMessage",
                LastCommitSha = "lastCommitSha",
                LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
                RootDir = "rootDir",
            },
            WebhookUrl = "https://example.com",
        };

        Assert.Null(model.WebhookSecret);
        Assert.False(model.RawData.ContainsKey("webhookSecret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new GitLinkLinkResponse
        {
            Link = new()
            {
                ID = "id",
                AutoDeploy = true,
                Branch = "main",
                Connection = GitLinkLinkResponseLinkConnection.App,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Owner = "acme",
                Provider = GitLinkLinkResponseLinkProvider.GitHub,
                Repo = "order-bot",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastCommitMessage = "lastCommitMessage",
                LastCommitSha = "lastCommitSha",
                LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
                RootDir = "rootDir",
            },
            WebhookUrl = "https://example.com",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new GitLinkLinkResponse
        {
            Link = new()
            {
                ID = "id",
                AutoDeploy = true,
                Branch = "main",
                Connection = GitLinkLinkResponseLinkConnection.App,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Owner = "acme",
                Provider = GitLinkLinkResponseLinkProvider.GitHub,
                Repo = "order-bot",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastCommitMessage = "lastCommitMessage",
                LastCommitSha = "lastCommitSha",
                LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
                RootDir = "rootDir",
            },
            WebhookUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            WebhookSecret = null,
        };

        Assert.Null(model.WebhookSecret);
        Assert.False(model.RawData.ContainsKey("webhookSecret"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GitLinkLinkResponse
        {
            Link = new()
            {
                ID = "id",
                AutoDeploy = true,
                Branch = "main",
                Connection = GitLinkLinkResponseLinkConnection.App,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Owner = "acme",
                Provider = GitLinkLinkResponseLinkProvider.GitHub,
                Repo = "order-bot",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastCommitMessage = "lastCommitMessage",
                LastCommitSha = "lastCommitSha",
                LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
                RootDir = "rootDir",
            },
            WebhookUrl = "https://example.com",

            // Null should be interpreted as omitted for these properties
            WebhookSecret = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GitLinkLinkResponse
        {
            Link = new()
            {
                ID = "id",
                AutoDeploy = true,
                Branch = "main",
                Connection = GitLinkLinkResponseLinkConnection.App,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FunctionID = "functionId",
                Owner = "acme",
                Provider = GitLinkLinkResponseLinkProvider.GitHub,
                Repo = "order-bot",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastCommitMessage = "lastCommitMessage",
                LastCommitSha = "lastCommitSha",
                LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                LastError = "lastError",
                LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
                RootDir = "rootDir",
            },
            WebhookUrl = "https://example.com",
            WebhookSecret = "ghs_a1b2c3...",
        };

        GitLinkLinkResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GitLinkLinkResponseLinkTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GitLinkLinkResponseLink
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastCommitMessage = "lastCommitMessage",
            LastCommitSha = "lastCommitSha",
            LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
            RootDir = "rootDir",
        };

        string expectedID = "id";
        bool expectedAutoDeploy = true;
        string expectedBranch = "main";
        ApiEnum<string, GitLinkLinkResponseLinkConnection> expectedConnection =
            GitLinkLinkResponseLinkConnection.App;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFunctionID = "functionId";
        string expectedOwner = "acme";
        ApiEnum<string, GitLinkLinkResponseLinkProvider> expectedProvider =
            GitLinkLinkResponseLinkProvider.GitHub;
        string expectedRepo = "order-bot";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedLastCommitMessage = "lastCommitMessage";
        string expectedLastCommitSha = "lastCommitSha";
        DateTimeOffset expectedLastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedLastError = "lastError";
        ApiEnum<string, GitLinkLinkResponseLinkLastStatus> expectedLastStatus =
            GitLinkLinkResponseLinkLastStatus.Deploying;
        string expectedRootDir = "rootDir";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAutoDeploy, model.AutoDeploy);
        Assert.Equal(expectedBranch, model.Branch);
        Assert.Equal(expectedConnection, model.Connection);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedFunctionID, model.FunctionID);
        Assert.Equal(expectedOwner, model.Owner);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedRepo, model.Repo);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedLastCommitMessage, model.LastCommitMessage);
        Assert.Equal(expectedLastCommitSha, model.LastCommitSha);
        Assert.Equal(expectedLastDeployAt, model.LastDeployAt);
        Assert.Equal(expectedLastError, model.LastError);
        Assert.Equal(expectedLastStatus, model.LastStatus);
        Assert.Equal(expectedRootDir, model.RootDir);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GitLinkLinkResponseLink
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastCommitMessage = "lastCommitMessage",
            LastCommitSha = "lastCommitSha",
            LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
            RootDir = "rootDir",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GitLinkLinkResponseLink>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GitLinkLinkResponseLink
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastCommitMessage = "lastCommitMessage",
            LastCommitSha = "lastCommitSha",
            LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
            RootDir = "rootDir",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GitLinkLinkResponseLink>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedAutoDeploy = true;
        string expectedBranch = "main";
        ApiEnum<string, GitLinkLinkResponseLinkConnection> expectedConnection =
            GitLinkLinkResponseLinkConnection.App;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFunctionID = "functionId";
        string expectedOwner = "acme";
        ApiEnum<string, GitLinkLinkResponseLinkProvider> expectedProvider =
            GitLinkLinkResponseLinkProvider.GitHub;
        string expectedRepo = "order-bot";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedLastCommitMessage = "lastCommitMessage";
        string expectedLastCommitSha = "lastCommitSha";
        DateTimeOffset expectedLastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedLastError = "lastError";
        ApiEnum<string, GitLinkLinkResponseLinkLastStatus> expectedLastStatus =
            GitLinkLinkResponseLinkLastStatus.Deploying;
        string expectedRootDir = "rootDir";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAutoDeploy, deserialized.AutoDeploy);
        Assert.Equal(expectedBranch, deserialized.Branch);
        Assert.Equal(expectedConnection, deserialized.Connection);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedFunctionID, deserialized.FunctionID);
        Assert.Equal(expectedOwner, deserialized.Owner);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedRepo, deserialized.Repo);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedLastCommitMessage, deserialized.LastCommitMessage);
        Assert.Equal(expectedLastCommitSha, deserialized.LastCommitSha);
        Assert.Equal(expectedLastDeployAt, deserialized.LastDeployAt);
        Assert.Equal(expectedLastError, deserialized.LastError);
        Assert.Equal(expectedLastStatus, deserialized.LastStatus);
        Assert.Equal(expectedRootDir, deserialized.RootDir);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GitLinkLinkResponseLink
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastCommitMessage = "lastCommitMessage",
            LastCommitSha = "lastCommitSha",
            LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
            RootDir = "rootDir",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new GitLinkLinkResponseLink
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.LastCommitMessage);
        Assert.False(model.RawData.ContainsKey("lastCommitMessage"));
        Assert.Null(model.LastCommitSha);
        Assert.False(model.RawData.ContainsKey("lastCommitSha"));
        Assert.Null(model.LastDeployAt);
        Assert.False(model.RawData.ContainsKey("lastDeployAt"));
        Assert.Null(model.LastError);
        Assert.False(model.RawData.ContainsKey("lastError"));
        Assert.Null(model.LastStatus);
        Assert.False(model.RawData.ContainsKey("lastStatus"));
        Assert.Null(model.RootDir);
        Assert.False(model.RawData.ContainsKey("rootDir"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new GitLinkLinkResponseLink
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new GitLinkLinkResponseLink
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            LastCommitMessage = null,
            LastCommitSha = null,
            LastDeployAt = null,
            LastError = null,
            LastStatus = null,
            RootDir = null,
        };

        Assert.Null(model.LastCommitMessage);
        Assert.True(model.RawData.ContainsKey("lastCommitMessage"));
        Assert.Null(model.LastCommitSha);
        Assert.True(model.RawData.ContainsKey("lastCommitSha"));
        Assert.Null(model.LastDeployAt);
        Assert.True(model.RawData.ContainsKey("lastDeployAt"));
        Assert.Null(model.LastError);
        Assert.True(model.RawData.ContainsKey("lastError"));
        Assert.Null(model.LastStatus);
        Assert.True(model.RawData.ContainsKey("lastStatus"));
        Assert.Null(model.RootDir);
        Assert.True(model.RawData.ContainsKey("rootDir"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new GitLinkLinkResponseLink
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            LastCommitMessage = null,
            LastCommitSha = null,
            LastDeployAt = null,
            LastError = null,
            LastStatus = null,
            RootDir = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GitLinkLinkResponseLink
        {
            ID = "id",
            AutoDeploy = true,
            Branch = "main",
            Connection = GitLinkLinkResponseLinkConnection.App,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FunctionID = "functionId",
            Owner = "acme",
            Provider = GitLinkLinkResponseLinkProvider.GitHub,
            Repo = "order-bot",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastCommitMessage = "lastCommitMessage",
            LastCommitSha = "lastCommitSha",
            LastDeployAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LastError = "lastError",
            LastStatus = GitLinkLinkResponseLinkLastStatus.Deploying,
            RootDir = "rootDir",
        };

        GitLinkLinkResponseLink copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GitLinkLinkResponseLinkConnectionTest : TestBase
{
    [Theory]
    [InlineData(GitLinkLinkResponseLinkConnection.App)]
    [InlineData(GitLinkLinkResponseLinkConnection.Manual)]
    public void Validation_Works(GitLinkLinkResponseLinkConnection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GitLinkLinkResponseLinkConnection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GitLinkLinkResponseLinkConnection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GitLinkLinkResponseLinkConnection.App)]
    [InlineData(GitLinkLinkResponseLinkConnection.Manual)]
    public void SerializationRoundtrip_Works(GitLinkLinkResponseLinkConnection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GitLinkLinkResponseLinkConnection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GitLinkLinkResponseLinkConnection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GitLinkLinkResponseLinkConnection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GitLinkLinkResponseLinkConnection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GitLinkLinkResponseLinkProviderTest : TestBase
{
    [Theory]
    [InlineData(GitLinkLinkResponseLinkProvider.GitHub)]
    public void Validation_Works(GitLinkLinkResponseLinkProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GitLinkLinkResponseLinkProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GitLinkLinkResponseLinkProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GitLinkLinkResponseLinkProvider.GitHub)]
    public void SerializationRoundtrip_Works(GitLinkLinkResponseLinkProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GitLinkLinkResponseLinkProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GitLinkLinkResponseLinkProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GitLinkLinkResponseLinkProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GitLinkLinkResponseLinkProvider>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GitLinkLinkResponseLinkLastStatusTest : TestBase
{
    [Theory]
    [InlineData(GitLinkLinkResponseLinkLastStatus.Deploying)]
    [InlineData(GitLinkLinkResponseLinkLastStatus.Deployed)]
    [InlineData(GitLinkLinkResponseLinkLastStatus.Failed)]
    public void Validation_Works(GitLinkLinkResponseLinkLastStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GitLinkLinkResponseLinkLastStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GitLinkLinkResponseLinkLastStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GitLinkLinkResponseLinkLastStatus.Deploying)]
    [InlineData(GitLinkLinkResponseLinkLastStatus.Deployed)]
    [InlineData(GitLinkLinkResponseLinkLastStatus.Failed)]
    public void SerializationRoundtrip_Works(GitLinkLinkResponseLinkLastStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GitLinkLinkResponseLinkLastStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GitLinkLinkResponseLinkLastStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GitLinkLinkResponseLinkLastStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GitLinkLinkResponseLinkLastStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
