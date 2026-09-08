using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Functions.GitLink;

[JsonConverter(typeof(JsonModelConverter<GitLinkLinkResponse, GitLinkLinkResponseFromRaw>))]
public sealed record class GitLinkLinkResponse : JsonModel
{
    /// <summary>
    /// A GitHub repository bound to a function. A push to `branch` deploys the function.
    /// A function holds at most one link.
    /// </summary>
    public required GitLinkLinkResponseLink Link
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<GitLinkLinkResponseLink>("link");
        }
        init { this._rawData.Set("link", value); }
    }

    /// <summary>
    /// Endpoint that receives GitHub's push deliveries. Only needed on a `manual`
    /// link, where you add it to the repository yourself.
    /// </summary>
    public required string WebhookUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("webhookUrl");
        }
        init { this._rawData.Set("webhookUrl", value); }
    }

    /// <summary>
    /// Shared secret for the repository's webhook. **Returned only when creating
    /// a `manual` link, and only there** — every later read strips it, and re-linking
    /// mints a new one. Absent entirely on an `app` link, which needs no secret
    /// of its own.
    /// </summary>
    public string? WebhookSecret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("webhookSecret");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("webhookSecret", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Link.Validate();
        _ = this.WebhookUrl;
        _ = this.WebhookSecret;
    }

    public GitLinkLinkResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GitLinkLinkResponse(GitLinkLinkResponse gitLinkLinkResponse)
        : base(gitLinkLinkResponse) { }
#pragma warning restore CS8618

    public GitLinkLinkResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GitLinkLinkResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GitLinkLinkResponseFromRaw.FromRawUnchecked"/>
    public static GitLinkLinkResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GitLinkLinkResponseFromRaw : IFromRawJson<GitLinkLinkResponse>
{
    /// <inheritdoc/>
    public GitLinkLinkResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        GitLinkLinkResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A GitHub repository bound to a function. A push to `branch` deploys the function.
/// A function holds at most one link.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<GitLinkLinkResponseLink, GitLinkLinkResponseLinkFromRaw>))]
public sealed record class GitLinkLinkResponseLink : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// When false the link is kept and pushes are ignored.
    /// </summary>
    public required bool AutoDeploy
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("autoDeploy");
        }
        init { this._rawData.Set("autoDeploy", value); }
    }

    /// <summary>
    /// Only pushes to this branch deploy.
    /// </summary>
    public required string Branch
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("branch");
        }
        init { this._rawData.Set("branch", value); }
    }

    /// <summary>
    /// How this link authenticates, decided by the server rather than by the caller.
    /// - `app`: the Zavu GitHub App is installed on the account. Pushes arrive on
    /// the app's webhook and private repositories work. Nothing to configure in
    /// the repository. - `manual`: no installation. The link carries its own secret
    /// and you add the webhook to the repository yourself.
    /// </summary>
    public required ApiEnum<string, GitLinkLinkResponseLinkConnection> Connection
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, GitLinkLinkResponseLinkConnection>
            >("connection");
        }
        init { this._rawData.Set("connection", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string FunctionID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("functionId");
        }
        init { this._rawData.Set("functionId", value); }
    }

    public required string Owner
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("owner");
        }
        init { this._rawData.Set("owner", value); }
    }

    public required ApiEnum<string, GitLinkLinkResponseLinkProvider> Provider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, GitLinkLinkResponseLinkProvider>>(
                "provider"
            );
        }
        init { this._rawData.Set("provider", value); }
    }

    public required string Repo
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("repo");
        }
        init { this._rawData.Set("repo", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    public string? LastCommitMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastCommitMessage");
        }
        init { this._rawData.Set("lastCommitMessage", value); }
    }

    public string? LastCommitSha
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastCommitSha");
        }
        init { this._rawData.Set("lastCommitSha", value); }
    }

    public DateTimeOffset? LastDeployAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastDeployAt");
        }
        init { this._rawData.Set("lastDeployAt", value); }
    }

    /// <summary>
    /// Why the last deploy failed. Null otherwise.
    /// </summary>
    public string? LastError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastError");
        }
        init { this._rawData.Set("lastError", value); }
    }

    public ApiEnum<string, GitLinkLinkResponseLinkLastStatus>? LastStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, GitLinkLinkResponseLinkLastStatus>
            >("lastStatus");
        }
        init { this._rawData.Set("lastStatus", value); }
    }

    /// <summary>
    /// Subdirectory holding the project, for monorepos. Null when the project is
    /// at the repository root.
    /// </summary>
    public string? RootDir
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("rootDir");
        }
        init { this._rawData.Set("rootDir", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AutoDeploy;
        _ = this.Branch;
        this.Connection.Validate();
        _ = this.CreatedAt;
        _ = this.FunctionID;
        _ = this.Owner;
        this.Provider.Validate();
        _ = this.Repo;
        _ = this.UpdatedAt;
        _ = this.LastCommitMessage;
        _ = this.LastCommitSha;
        _ = this.LastDeployAt;
        _ = this.LastError;
        this.LastStatus?.Validate();
        _ = this.RootDir;
    }

    public GitLinkLinkResponseLink() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GitLinkLinkResponseLink(GitLinkLinkResponseLink gitLinkLinkResponseLink)
        : base(gitLinkLinkResponseLink) { }
#pragma warning restore CS8618

    public GitLinkLinkResponseLink(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GitLinkLinkResponseLink(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GitLinkLinkResponseLinkFromRaw.FromRawUnchecked"/>
    public static GitLinkLinkResponseLink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class GitLinkLinkResponseLinkFromRaw : IFromRawJson<GitLinkLinkResponseLink>
{
    /// <inheritdoc/>
    public GitLinkLinkResponseLink FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GitLinkLinkResponseLink.FromRawUnchecked(rawData);
}

/// <summary>
/// How this link authenticates, decided by the server rather than by the caller.
/// - `app`: the Zavu GitHub App is installed on the account. Pushes arrive on the
/// app's webhook and private repositories work. Nothing to configure in the repository.
/// - `manual`: no installation. The link carries its own secret and you add the
/// webhook to the repository yourself.
/// </summary>
[JsonConverter(typeof(GitLinkLinkResponseLinkConnectionConverter))]
public enum GitLinkLinkResponseLinkConnection
{
    App,
    Manual,
}

sealed class GitLinkLinkResponseLinkConnectionConverter
    : JsonConverter<GitLinkLinkResponseLinkConnection>
{
    public override GitLinkLinkResponseLinkConnection Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "app" => GitLinkLinkResponseLinkConnection.App,
            "manual" => GitLinkLinkResponseLinkConnection.Manual,
            _ => (GitLinkLinkResponseLinkConnection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GitLinkLinkResponseLinkConnection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GitLinkLinkResponseLinkConnection.App => "app",
                GitLinkLinkResponseLinkConnection.Manual => "manual",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(GitLinkLinkResponseLinkProviderConverter))]
public enum GitLinkLinkResponseLinkProvider
{
    GitHub,
}

sealed class GitLinkLinkResponseLinkProviderConverter
    : JsonConverter<GitLinkLinkResponseLinkProvider>
{
    public override GitLinkLinkResponseLinkProvider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "github" => GitLinkLinkResponseLinkProvider.GitHub,
            _ => (GitLinkLinkResponseLinkProvider)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GitLinkLinkResponseLinkProvider value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GitLinkLinkResponseLinkProvider.GitHub => "github",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(GitLinkLinkResponseLinkLastStatusConverter))]
public enum GitLinkLinkResponseLinkLastStatus
{
    Deploying,
    Deployed,
    Failed,
}

sealed class GitLinkLinkResponseLinkLastStatusConverter
    : JsonConverter<GitLinkLinkResponseLinkLastStatus>
{
    public override GitLinkLinkResponseLinkLastStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "deploying" => GitLinkLinkResponseLinkLastStatus.Deploying,
            "deployed" => GitLinkLinkResponseLinkLastStatus.Deployed,
            "failed" => GitLinkLinkResponseLinkLastStatus.Failed,
            _ => (GitLinkLinkResponseLinkLastStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        GitLinkLinkResponseLinkLastStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                GitLinkLinkResponseLinkLastStatus.Deploying => "deploying",
                GitLinkLinkResponseLinkLastStatus.Deployed => "deployed",
                GitLinkLinkResponseLinkLastStatus.Failed => "failed",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
