using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Broadcasts;

/// <summary>
/// Current status of the broadcast.
/// </summary>
[JsonConverter(typeof(BroadcastStatusConverter))]
public enum BroadcastStatus
{
    Draft,
    PendingReview,
    Approved,
    Rejected,
    Escalated,
    RejectedFinal,
    Scheduled,
    Sending,
    Paused,
    Completed,
    Cancelled,
    Failed,
}

sealed class BroadcastStatusConverter : JsonConverter<BroadcastStatus>
{
    public override BroadcastStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft" => BroadcastStatus.Draft,
            "pending_review" => BroadcastStatus.PendingReview,
            "approved" => BroadcastStatus.Approved,
            "rejected" => BroadcastStatus.Rejected,
            "escalated" => BroadcastStatus.Escalated,
            "rejected_final" => BroadcastStatus.RejectedFinal,
            "scheduled" => BroadcastStatus.Scheduled,
            "sending" => BroadcastStatus.Sending,
            "paused" => BroadcastStatus.Paused,
            "completed" => BroadcastStatus.Completed,
            "cancelled" => BroadcastStatus.Cancelled,
            "failed" => BroadcastStatus.Failed,
            _ => (BroadcastStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BroadcastStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BroadcastStatus.Draft => "draft",
                BroadcastStatus.PendingReview => "pending_review",
                BroadcastStatus.Approved => "approved",
                BroadcastStatus.Rejected => "rejected",
                BroadcastStatus.Escalated => "escalated",
                BroadcastStatus.RejectedFinal => "rejected_final",
                BroadcastStatus.Scheduled => "scheduled",
                BroadcastStatus.Sending => "sending",
                BroadcastStatus.Paused => "paused",
                BroadcastStatus.Completed => "completed",
                BroadcastStatus.Cancelled => "cancelled",
                BroadcastStatus.Failed => "failed",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
