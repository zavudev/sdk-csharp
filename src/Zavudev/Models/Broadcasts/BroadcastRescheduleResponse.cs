using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(
    typeof(JsonModelConverter<BroadcastRescheduleResponse, BroadcastRescheduleResponseFromRaw>)
)]
public sealed record class BroadcastRescheduleResponse : JsonModel
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

    public BroadcastRescheduleResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastRescheduleResponse(BroadcastRescheduleResponse broadcastRescheduleResponse)
        : base(broadcastRescheduleResponse) { }
#pragma warning restore CS8618

    public BroadcastRescheduleResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastRescheduleResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastRescheduleResponseFromRaw.FromRawUnchecked"/>
    public static BroadcastRescheduleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BroadcastRescheduleResponse(Broadcast broadcast)
        : this()
    {
        this.Broadcast = broadcast;
    }
}

class BroadcastRescheduleResponseFromRaw : IFromRawJson<BroadcastRescheduleResponse>
{
    /// <inheritdoc/>
    public BroadcastRescheduleResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BroadcastRescheduleResponse.FromRawUnchecked(rawData);
}
