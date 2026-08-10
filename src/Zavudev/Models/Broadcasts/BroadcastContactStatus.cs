using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Broadcasts;

/// <summary>
/// Status of a contact within a broadcast.
/// </summary>
[JsonConverter(typeof(BroadcastContactStatusConverter))]
public enum BroadcastContactStatus
{
    Pending,
    Queued,
    Sending,
    Delivered,
    Failed,
    Skipped,
}

sealed class BroadcastContactStatusConverter : JsonConverter<BroadcastContactStatus>
{
    public override BroadcastContactStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "pending" => BroadcastContactStatus.Pending,
            "queued" => BroadcastContactStatus.Queued,
            "sending" => BroadcastContactStatus.Sending,
            "delivered" => BroadcastContactStatus.Delivered,
            "failed" => BroadcastContactStatus.Failed,
            "skipped" => BroadcastContactStatus.Skipped,
            _ => (BroadcastContactStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BroadcastContactStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BroadcastContactStatus.Pending => "pending",
                BroadcastContactStatus.Queued => "queued",
                BroadcastContactStatus.Sending => "sending",
                BroadcastContactStatus.Delivered => "delivered",
                BroadcastContactStatus.Failed => "failed",
                BroadcastContactStatus.Skipped => "skipped",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
