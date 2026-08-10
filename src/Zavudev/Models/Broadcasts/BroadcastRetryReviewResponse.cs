using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(
    typeof(JsonModelConverter<BroadcastRetryReviewResponse, BroadcastRetryReviewResponseFromRaw>)
)]
public sealed record class BroadcastRetryReviewResponse : JsonModel
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

    public BroadcastRetryReviewResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastRetryReviewResponse(BroadcastRetryReviewResponse broadcastRetryReviewResponse)
        : base(broadcastRetryReviewResponse) { }
#pragma warning restore CS8618

    public BroadcastRetryReviewResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastRetryReviewResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastRetryReviewResponseFromRaw.FromRawUnchecked"/>
    public static BroadcastRetryReviewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BroadcastRetryReviewResponse(Broadcast broadcast)
        : this()
    {
        this.Broadcast = broadcast;
    }
}

class BroadcastRetryReviewResponseFromRaw : IFromRawJson<BroadcastRetryReviewResponse>
{
    /// <inheritdoc/>
    public BroadcastRetryReviewResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BroadcastRetryReviewResponse.FromRawUnchecked(rawData);
}
