using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Messages;

[JsonConverter(typeof(MessageStatusConverter))]
public enum MessageStatus
{
    Queued,
    Sending,
    Sent,
    Delivered,
    Read,
    Failed,
    Received,
    PendingUrlVerification,
}

sealed class MessageStatusConverter : JsonConverter<MessageStatus>
{
    public override MessageStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "queued" => MessageStatus.Queued,
            "sending" => MessageStatus.Sending,
            "sent" => MessageStatus.Sent,
            "delivered" => MessageStatus.Delivered,
            "read" => MessageStatus.Read,
            "failed" => MessageStatus.Failed,
            "received" => MessageStatus.Received,
            "pending_url_verification" => MessageStatus.PendingUrlVerification,
            _ => (MessageStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessageStatus.Queued => "queued",
                MessageStatus.Sending => "sending",
                MessageStatus.Sent => "sent",
                MessageStatus.Delivered => "delivered",
                MessageStatus.Read => "read",
                MessageStatus.Failed => "failed",
                MessageStatus.Received => "received",
                MessageStatus.PendingUrlVerification => "pending_url_verification",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
