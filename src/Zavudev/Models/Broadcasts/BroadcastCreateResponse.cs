using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(typeof(JsonModelConverter<BroadcastCreateResponse, BroadcastCreateResponseFromRaw>))]
public sealed record class BroadcastCreateResponse : JsonModel
{
    public required Broadcast Broadcast
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Broadcast>("broadcast");
        }
        init { this._rawData.Set("broadcast", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Broadcast.Validate();
    }

    public BroadcastCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastCreateResponse(BroadcastCreateResponse broadcastCreateResponse)
        : base(broadcastCreateResponse) { }
#pragma warning restore CS8618

    public BroadcastCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastCreateResponseFromRaw.FromRawUnchecked"/>
    public static BroadcastCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BroadcastCreateResponse(Broadcast broadcast)
        : this()
    {
        this.Broadcast = broadcast;
    }
}

class BroadcastCreateResponseFromRaw : IFromRawJson<BroadcastCreateResponse>
{
    /// <inheritdoc/>
    public BroadcastCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BroadcastCreateResponse.FromRawUnchecked(rawData);
}
