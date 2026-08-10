using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(
    typeof(JsonModelConverter<
        BroadcastEscalateReviewResponse,
        BroadcastEscalateReviewResponseFromRaw
    >)
)]
public sealed record class BroadcastEscalateReviewResponse : JsonModel
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

    public BroadcastEscalateReviewResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastEscalateReviewResponse(
        BroadcastEscalateReviewResponse broadcastEscalateReviewResponse
    )
        : base(broadcastEscalateReviewResponse) { }
#pragma warning restore CS8618

    public BroadcastEscalateReviewResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastEscalateReviewResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastEscalateReviewResponseFromRaw.FromRawUnchecked"/>
    public static BroadcastEscalateReviewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BroadcastEscalateReviewResponse(Broadcast broadcast)
        : this()
    {
        this.Broadcast = broadcast;
    }
}

class BroadcastEscalateReviewResponseFromRaw : IFromRawJson<BroadcastEscalateReviewResponse>
{
    /// <inheritdoc/>
    public BroadcastEscalateReviewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BroadcastEscalateReviewResponse.FromRawUnchecked(rawData);
}
