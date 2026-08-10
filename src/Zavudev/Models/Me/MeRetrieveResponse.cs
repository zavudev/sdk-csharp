using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Me;

[JsonConverter(typeof(JsonModelConverter<MeRetrieveResponse, MeRetrieveResponseFromRaw>))]
public sealed record class MeRetrieveResponse : JsonModel
{
    public required ApiKey ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiKey>("apiKey");
        }
        init { this._rawData.Set("apiKey", value); }
    }

    public required bool IsTestMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isTestMode");
        }
        init { this._rawData.Set("isTestMode", value); }
    }

    public required Project Project
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Project>("project");
        }
        init { this._rawData.Set("project", value); }
    }

    public required Team Team
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Team>("team");
        }
        init { this._rawData.Set("team", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ApiKey.Validate();
        _ = this.IsTestMode;
        this.Project.Validate();
        this.Team.Validate();
    }

    public MeRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MeRetrieveResponse(MeRetrieveResponse meRetrieveResponse)
        : base(meRetrieveResponse) { }
#pragma warning restore CS8618

    public MeRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MeRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MeRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static MeRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MeRetrieveResponseFromRaw : IFromRawJson<MeRetrieveResponse>
{
    /// <inheritdoc/>
    public MeRetrieveResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MeRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ApiKey, ApiKeyFromRaw>))]
public sealed record class ApiKey : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
    }

    public ApiKey() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKey(ApiKey apiKey)
        : base(apiKey) { }
#pragma warning restore CS8618

    public ApiKey(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKey(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyFromRaw.FromRawUnchecked"/>
    public static ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiKey(string id)
        : this()
    {
        this.ID = id;
    }
}

class ApiKeyFromRaw : IFromRawJson<ApiKey>
{
    /// <inheritdoc/>
    public ApiKey FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ApiKey.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Project, ProjectFromRaw>))]
public sealed record class Project : JsonModel
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

    public required bool IsSubAccount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isSubAccount");
        }
        init { this._rawData.Set("isSubAccount", value); }
    }

    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.IsSubAccount;
        _ = this.Name;
    }

    public Project() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Project(Project project)
        : base(project) { }
#pragma warning restore CS8618

    public Project(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Project(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ProjectFromRaw.FromRawUnchecked"/>
    public static Project FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ProjectFromRaw : IFromRawJson<Project>
{
    /// <inheritdoc/>
    public Project FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Project.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Team, TeamFromRaw>))]
public sealed record class Team : JsonModel
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

    public required string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Name;
    }

    public Team() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Team(Team team)
        : base(team) { }
#pragma warning restore CS8618

    public Team(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Team(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TeamFromRaw.FromRawUnchecked"/>
    public static Team FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TeamFromRaw : IFromRawJson<Team>
{
    /// <inheritdoc/>
    public Team FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Team.FromRawUnchecked(rawData);
}
