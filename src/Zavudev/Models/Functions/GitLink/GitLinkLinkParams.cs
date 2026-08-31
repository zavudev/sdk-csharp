using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Functions.GitLink;

/// <summary>
/// Bind a repository to this function so every push to `branch` deploys it. A function
/// holds at most one link; linking again returns 400.
///
/// <para>**The server decides how the link authenticates.** If the project has the
/// Zavu GitHub App installed, the link uses that installation: private repositories
/// work and there is nothing to configure in the repository. Otherwise it falls
/// back to a manual link and the response carries a `webhookSecret` you add to the
/// repository yourself. `connection` says which one you got.</para>
///
/// <para>The repository is not checked against GitHub here, because it cannot be:
/// an owner/repo that does not exist, or that the installation cannot see, is accepted
/// and fails on the first deploy with a fetch error.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class GitLinkLinkParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? FunctionID { get; init; }

    public required string Owner
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("owner");
        }
        init { this._rawBodyData.Set("owner", value); }
    }

    public required string Repo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("repo");
        }
        init { this._rawBodyData.Set("repo", value); }
    }

    public bool? AutoDeploy
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("autoDeploy");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("autoDeploy", value);
        }
    }

    public string? Branch
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("branch");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("branch", value);
        }
    }

    /// <summary>
    /// Subdirectory holding the project, for monorepos.
    /// </summary>
    public string? RootDir
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("rootDir");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("rootDir", value);
        }
    }

    public GitLinkLinkParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GitLinkLinkParams(GitLinkLinkParams gitLinkLinkParams)
        : base(gitLinkLinkParams)
    {
        this.FunctionID = gitLinkLinkParams.FunctionID;

        this._rawBodyData = new(gitLinkLinkParams._rawBodyData);
    }
#pragma warning restore CS8618

    public GitLinkLinkParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GitLinkLinkParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string functionID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.FunctionID = functionID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static GitLinkLinkParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string functionID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            functionID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["FunctionID"] = JsonSerializer.SerializeToElement(this.FunctionID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(GitLinkLinkParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.FunctionID?.Equals(other.FunctionID) ?? other.FunctionID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/functions/{0}/git-link", this.FunctionID)
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
