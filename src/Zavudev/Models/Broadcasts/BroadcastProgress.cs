using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(typeof(JsonModelConverter<BroadcastProgress, BroadcastProgressFromRaw>))]
public sealed record class BroadcastProgress : JsonModel
{
    public required string BroadcastID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("broadcastId");
        }
        init { this._rawData.Set("broadcastId", value); }
    }

    /// <summary>
    /// Successfully delivered.
    /// </summary>
    public required long Delivered
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("delivered");
        }
        init { this._rawData.Set("delivered", value); }
    }

    /// <summary>
    /// Failed to deliver.
    /// </summary>
    public required long Failed
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("failed");
        }
        init { this._rawData.Set("failed", value); }
    }

    /// <summary>
    /// Not yet queued for sending.
    /// </summary>
    public required long Pending
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("pending");
        }
        init { this._rawData.Set("pending", value); }
    }

    /// <summary>
    /// Percentage complete (0-100).
    /// </summary>
    public required double PercentComplete
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<double>("percentComplete");
        }
        init { this._rawData.Set("percentComplete", value); }
    }

    /// <summary>
    /// Currently being sent.
    /// </summary>
    public required long Sending
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("sending");
        }
        init { this._rawData.Set("sending", value); }
    }

    /// <summary>
    /// Skipped (broadcast cancelled).
    /// </summary>
    public required long Skipped
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("skipped");
        }
        init { this._rawData.Set("skipped", value); }
    }

    /// <summary>
    /// Current status of the broadcast.
    /// </summary>
    public required ApiEnum<string, BroadcastStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BroadcastStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Total contacts in broadcast.
    /// </summary>
    public required long Total
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total");
        }
        init { this._rawData.Set("total", value); }
    }

    /// <summary>
    /// Actual cost so far in USD.
    /// </summary>
    public double? ActualCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("actualCost");
        }
        init { this._rawData.Set("actualCost", value); }
    }

    public DateTimeOffset? EstimatedCompletionAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("estimatedCompletionAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("estimatedCompletionAt", value);
        }
    }

    /// <summary>
    /// Estimated total cost in USD.
    /// </summary>
    public double? EstimatedCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("estimatedCost");
        }
        init { this._rawData.Set("estimatedCost", value); }
    }

    /// <summary>
    /// Amount reserved from balance in USD.
    /// </summary>
    public double? ReservedAmount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("reservedAmount");
        }
        init { this._rawData.Set("reservedAmount", value); }
    }

    public DateTimeOffset? StartedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("startedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("startedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.BroadcastID;
        _ = this.Delivered;
        _ = this.Failed;
        _ = this.Pending;
        _ = this.PercentComplete;
        _ = this.Sending;
        _ = this.Skipped;
        this.Status.Validate();
        _ = this.Total;
        _ = this.ActualCost;
        _ = this.EstimatedCompletionAt;
        _ = this.EstimatedCost;
        _ = this.ReservedAmount;
        _ = this.StartedAt;
    }

    public BroadcastProgress() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BroadcastProgress(BroadcastProgress broadcastProgress)
        : base(broadcastProgress) { }
#pragma warning restore CS8618

    public BroadcastProgress(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BroadcastProgress(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastProgressFromRaw.FromRawUnchecked"/>
    public static BroadcastProgress FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BroadcastProgressFromRaw : IFromRawJson<BroadcastProgress>
{
    /// <inheritdoc/>
    public BroadcastProgress FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BroadcastProgress.FromRawUnchecked(rawData);
}
