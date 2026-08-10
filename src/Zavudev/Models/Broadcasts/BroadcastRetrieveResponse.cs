using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(
    typeof(JsonModelConverter<BroadcastRetrieveResponse, BroadcastRetrieveResponseFromRaw>)
)]
public sealed record class BroadcastRetrieveResponse : JsonModel
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

    public BroadcastRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastRetrieveResponse(BroadcastRetrieveResponse broadcastRetrieveResponse)
        : base(broadcastRetrieveResponse) { }
#pragma warning restore CS8618

    public BroadcastRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BroadcastRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BroadcastRetrieveResponse(Broadcast broadcast)
        : this()
    {
        this.Broadcast = broadcast;
    }
}

class BroadcastRetrieveResponseFromRaw : IFromRawJson<BroadcastRetrieveResponse>
{
    /// <inheritdoc/>
    public BroadcastRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BroadcastRetrieveResponse.FromRawUnchecked(rawData);
}
