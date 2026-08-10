using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Flows;

[JsonConverter(typeof(JsonModelConverter<FlowListPageResponse, FlowListPageResponseFromRaw>))]
public sealed record class FlowListPageResponse : JsonModel
{
    public required IReadOnlyList<AgentFlow> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AgentFlow>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AgentFlow>>(
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

    public FlowListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FlowListPageResponse(FlowListPageResponse flowListPageResponse)
        : base(flowListPageResponse) { }
#pragma warning restore CS8618

    public FlowListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FlowListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FlowListPageResponseFromRaw.FromRawUnchecked"/>
    public static FlowListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public FlowListPageResponse(IReadOnlyList<AgentFlow> items)
        : this()
    {
        this.Items = items;
    }
}

class FlowListPageResponseFromRaw : IFromRawJson<FlowListPageResponse>
{
    /// <inheritdoc/>
    public FlowListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FlowListPageResponse.FromRawUnchecked(rawData);
}
