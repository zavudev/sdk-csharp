using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(typeof(JsonModelConverter<BroadcastCancelResponse, BroadcastCancelResponseFromRaw>))]
public sealed record class BroadcastCancelResponse : JsonModel
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

    public BroadcastCancelResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastCancelResponse(BroadcastCancelResponse broadcastCancelResponse)
        : base(broadcastCancelResponse) { }
#pragma warning restore CS8618

    public BroadcastCancelResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastCancelResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastCancelResponseFromRaw.FromRawUnchecked"/>
    public static BroadcastCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BroadcastCancelResponse(Broadcast broadcast)
        : this()
    {
        this.Broadcast = broadcast;
    }
}

class BroadcastCancelResponseFromRaw : IFromRawJson<BroadcastCancelResponse>
{
    /// <inheritdoc/>
    public BroadcastCancelResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BroadcastCancelResponse.FromRawUnchecked(rawData);
}
