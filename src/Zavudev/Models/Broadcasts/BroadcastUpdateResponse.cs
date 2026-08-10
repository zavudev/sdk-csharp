using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(typeof(JsonModelConverter<BroadcastUpdateResponse, BroadcastUpdateResponseFromRaw>))]
public sealed record class BroadcastUpdateResponse : JsonModel
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

    public BroadcastUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastUpdateResponse(BroadcastUpdateResponse broadcastUpdateResponse)
        : base(broadcastUpdateResponse) { }
#pragma warning restore CS8618

    public BroadcastUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastUpdateResponseFromRaw.FromRawUnchecked"/>
    public static BroadcastUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BroadcastUpdateResponse(Broadcast broadcast)
        : this()
    {
        this.Broadcast = broadcast;
    }
}

class BroadcastUpdateResponseFromRaw : IFromRawJson<BroadcastUpdateResponse>
{
    /// <inheritdoc/>
    public BroadcastUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BroadcastUpdateResponse.FromRawUnchecked(rawData);
}
