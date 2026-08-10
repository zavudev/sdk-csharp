using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Tools;

[JsonConverter(typeof(JsonModelConverter<ToolListPageResponse, ToolListPageResponseFromRaw>))]
public sealed record class ToolListPageResponse : JsonModel
{
    public required IReadOnlyList<AgentTool> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AgentTool>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AgentTool>>(
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

    public ToolListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolListPageResponse(ToolListPageResponse toolListPageResponse)
        : base(toolListPageResponse) { }
#pragma warning restore CS8618

    public ToolListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolListPageResponseFromRaw.FromRawUnchecked"/>
    public static ToolListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolListPageResponse(IReadOnlyList<AgentTool> items)
        : this()
    {
        this.Items = items;
    }
}

class ToolListPageResponseFromRaw : IFromRawJson<ToolListPageResponse>
{
    /// <inheritdoc/>
    public ToolListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ToolListPageResponse.FromRawUnchecked(rawData);
}
