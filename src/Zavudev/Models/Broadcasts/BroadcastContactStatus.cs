using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Broadcasts;

/// <summary>
/// Status of a contact within a broadcast.
///
/// <para>- `pending`, `queued`, `sending`: not handed to the provider yet. - `sent`:
/// accepted by the provider; delivery is not confirmed yet. Channels that never
/// report delivery leave the recipient here. - `delivered`: the channel confirmed
/// delivery to the device. A WhatsApp read receipt also counts as delivered. - `failed`:
/// not delivered. A recipient can move from `sent` or `delivered` to `failed` when
/// the provider reports a failure late. - `skipped`: not sent, because the recipient
/// opted out of the channel or the broadcast was cancelled before reaching it.</para>
/// </summary>
[JsonConverter(typeof(BroadcastContactStatusConverter))]
public enum BroadcastContactStatus
{
    Pending,
    Queued,
    Sending,
    Sent,
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
            "sent" => BroadcastContactStatus.Sent,
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
                BroadcastContactStatus.Sent => "sent",
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
