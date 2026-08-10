using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.KnowledgeBases;

[JsonConverter(typeof(JsonModelConverter<AgentKnowledgeBase, AgentKnowledgeBaseFromRaw>))]
public sealed record class AgentKnowledgeBase : JsonModel
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

    public required string AgentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("agentId");
        }
        init { this._rawData.Set("agentId", value); }
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

    public required long DocumentCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("documentCount");
        }
        init { this._rawData.Set("documentCount", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required long TotalChunks
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalChunks");
        }
        init { this._rawData.Set("totalChunks", value); }
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

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.AgentID;
        _ = this.CreatedAt;
        _ = this.DocumentCount;
        _ = this.Name;
        _ = this.TotalChunks;
        _ = this.UpdatedAt;
        _ = this.Description;
    }

    public AgentKnowledgeBase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentKnowledgeBase(AgentKnowledgeBase agentKnowledgeBase)
        : base(agentKnowledgeBase) { }
#pragma warning restore CS8618

    public AgentKnowledgeBase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentKnowledgeBase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentKnowledgeBaseFromRaw.FromRawUnchecked"/>
    public static AgentKnowledgeBase FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AgentKnowledgeBaseFromRaw : IFromRawJson<AgentKnowledgeBase>
{
    /// <inheritdoc/>
    public AgentKnowledgeBase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        AgentKnowledgeBase.FromRawUnchecked(rawData);
}
