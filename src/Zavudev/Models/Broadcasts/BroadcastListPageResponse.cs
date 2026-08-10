using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(
    typeof(JsonModelConverter<BroadcastListPageResponse, BroadcastListPageResponseFromRaw>)
)]
public sealed record class BroadcastListPageResponse : JsonModel
{
    public required IReadOnlyList<Broadcast> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Broadcast>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Broadcast>>(
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

    public BroadcastListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastListPageResponse(BroadcastListPageResponse broadcastListPageResponse)
        : base(broadcastListPageResponse) { }
#pragma warning restore CS8618

    public BroadcastListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastListPageResponseFromRaw.FromRawUnchecked"/>
    public static BroadcastListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BroadcastListPageResponse(IReadOnlyList<Broadcast> items)
        : this()
    {
        this.Items = items;
    }
}

class BroadcastListPageResponseFromRaw : IFromRawJson<BroadcastListPageResponse>
{
    /// <inheritdoc/>
    public BroadcastListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BroadcastListPageResponse.FromRawUnchecked(rawData);
}
