using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Broadcasts;

[JsonConverter(typeof(JsonModelConverter<Broadcast, BroadcastFromRaw>))]
public sealed record class Broadcast : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    /// <summary>
    /// Broadcast delivery channel. Use 'smart' for per-contact intelligent routing.
    /// </summary>
    public required ApiEnum<string, BroadcastChannel> Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BroadcastChannel>>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Type of message for broadcast.
    /// </summary>
    public required ApiEnum<string, BroadcastMessageType> MessageType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, BroadcastMessageType>>(
                "messageType"
            );
        }
        init { this._rawData.Set("messageType", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
    /// Total number of contacts in the broadcast.
    /// </summary>
    public required long TotalContacts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalContacts");
        }
        init { this._rawData.Set("totalContacts", value); }
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

    public DateTimeOffset? CompletedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("completedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("completedAt", value);
        }
    }

    /// <summary>
    /// Content for non-text broadcast message types.
    /// </summary>
    public BroadcastContent? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<BroadcastContent>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content", value);
        }
    }

    public long? DeliveredCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("deliveredCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("deliveredCount", value);
        }
    }

    public string? EmailSubject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("emailSubject");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("emailSubject", value);
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

    public long? FailedCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("failedCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("failedCount", value);
        }
    }

    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public long? PendingCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("pendingCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("pendingCount", value);
        }
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

    /// <summary>
    /// Number of review attempts (max 3).
    /// </summary>
    public long? ReviewAttempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("reviewAttempts");
        }
        init { this._rawData.Set("reviewAttempts", value); }
    }

    /// <summary>
    /// AI content review result.
    /// </summary>
    public ReviewResult? ReviewResult
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ReviewResult>("reviewResult");
        }
        init { this._rawData.Set("reviewResult", value); }
    }

    public DateTimeOffset? ScheduledAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("scheduledAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("scheduledAt", value);
        }
    }

    public string? SenderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("senderId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("senderId", value);
        }
    }

    public long? SendingCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("sendingCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("sendingCount", value);
        }
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

    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Channel.Validate();
        _ = this.CreatedAt;
        this.MessageType.Validate();
        _ = this.Name;
        this.Status.Validate();
        _ = this.TotalContacts;
        _ = this.ActualCost;
        _ = this.CompletedAt;
        this.Content?.Validate();
        _ = this.DeliveredCount;
        _ = this.EmailSubject;
        _ = this.EstimatedCost;
        _ = this.FailedCount;
        _ = this.Metadata;
        _ = this.PendingCount;
        _ = this.ReservedAmount;
        _ = this.ReviewAttempts;
        this.ReviewResult?.Validate();
        _ = this.ScheduledAt;
        _ = this.SenderID;
        _ = this.SendingCount;
        _ = this.StartedAt;
        _ = this.Text;
        _ = this.UpdatedAt;
    }

    public Broadcast() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Broadcast(Broadcast broadcast)
        : base(broadcast) { }
#pragma warning restore CS8618

    public Broadcast(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Broadcast(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BroadcastFromRaw.FromRawUnchecked"/>
    public static Broadcast FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BroadcastFromRaw : IFromRawJson<Broadcast>
{
    /// <inheritdoc/>
    public Broadcast FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Broadcast.FromRawUnchecked(rawData);
}

/// <summary>
/// AI content review result.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ReviewResult, ReviewResultFromRaw>))]
public sealed record class ReviewResult : JsonModel
{
    /// <summary>
    /// Policy categories violated, if any.
    /// </summary>
    public IReadOnlyList<string>? Categories
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("categories");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "categories",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Problematic text fragments, if any.
    /// </summary>
    public IReadOnlyList<string>? FlaggedContent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("flaggedContent");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "flaggedContent",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Explanation of the review decision.
    /// </summary>
    public string? Reasoning
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reasoning");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reasoning", value);
        }
    }

    public DateTimeOffset? ReviewedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("reviewedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reviewedAt", value);
        }
    }

    /// <summary>
    /// Content safety score from 0.0 to 1.0, where 1.0 is completely safe.
    /// </summary>
    public double? Score
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("score");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("score", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Categories;
        _ = this.FlaggedContent;
        _ = this.Reasoning;
        _ = this.ReviewedAt;
        _ = this.Score;
    }

    public ReviewResult() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ReviewResult(ReviewResult reviewResult)
        : base(reviewResult) { }
#pragma warning restore CS8618

    public ReviewResult(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ReviewResult(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ReviewResultFromRaw.FromRawUnchecked"/>
    public static ReviewResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ReviewResultFromRaw : IFromRawJson<ReviewResult>
{
    /// <inheritdoc/>
    public ReviewResult FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ReviewResult.FromRawUnchecked(rawData);
}
