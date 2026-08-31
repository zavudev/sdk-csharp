using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Functions.GitLink;

[JsonConverter(
    typeof(JsonModelConverter<GitLinkDeployNowResponse, GitLinkDeployNowResponseFromRaw>)
)]
public sealed record class GitLinkDeployNowResponse : JsonModel
{
    public required bool Scheduled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("scheduled");
        }
        init { this._rawData.Set("scheduled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Scheduled;
    }

    public GitLinkDeployNowResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public GitLinkDeployNowResponse(GitLinkDeployNowResponse gitLinkDeployNowResponse)
        : base(gitLinkDeployNowResponse) { }
#pragma warning restore CS8618

    public GitLinkDeployNowResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    GitLinkDeployNowResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GitLinkDeployNowResponseFromRaw.FromRawUnchecked"/>
    public static GitLinkDeployNowResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public GitLinkDeployNowResponse(bool scheduled)
        : this()
    {
        this.Scheduled = scheduled;
    }
}

class GitLinkDeployNowResponseFromRaw : IFromRawJson<GitLinkDeployNowResponse>
{
    /// <inheritdoc/>
    public GitLinkDeployNowResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => GitLinkDeployNowResponse.FromRawUnchecked(rawData);
}
