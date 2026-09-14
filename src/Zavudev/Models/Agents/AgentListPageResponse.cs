using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;

namespace Zavudev.Models.Agents;

[JsonConverter(typeof(JsonModelConverter<AgentListPageResponse, AgentListPageResponseFromRaw>))]
public sealed record class AgentListPageResponse : JsonModel
{
    public required IReadOnlyList<AgentAgent> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AgentAgent>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AgentAgent>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init { this._rawData.Set("nextCursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public AgentListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentListPageResponse(AgentListPageResponse agentListPageResponse)
        : base(agentListPageResponse) { }
#pragma warning restore CS8618

    public AgentListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentListPageResponseFromRaw.FromRawUnchecked"/>
    public static AgentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentListPageResponse(IReadOnlyList<AgentAgent> items)
        : this()
    {
        this.Items = items;
    }
}

class AgentListPageResponseFromRaw : IFromRawJson<AgentListPageResponse>
{
    /// <inheritdoc/>
    public AgentListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentListPageResponse.FromRawUnchecked(rawData);
}
