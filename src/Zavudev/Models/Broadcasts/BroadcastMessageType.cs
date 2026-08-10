using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Broadcasts;

/// <summary>
/// Type of message for broadcast.
/// </summary>
[JsonConverter(typeof(BroadcastMessageTypeConverter))]
public enum BroadcastMessageType
{
    Text,
    Image,
    Video,
    Audio,
    Document,
    Template,
}

sealed class BroadcastMessageTypeConverter : JsonConverter<BroadcastMessageType>
{
    public override BroadcastMessageType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => BroadcastMessageType.Text,
            "image" => BroadcastMessageType.Image,
            "video" => BroadcastMessageType.Video,
            "audio" => BroadcastMessageType.Audio,
            "document" => BroadcastMessageType.Document,
            "template" => BroadcastMessageType.Template,
            _ => (BroadcastMessageType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BroadcastMessageType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BroadcastMessageType.Text => "text",
                BroadcastMessageType.Image => "image",
                BroadcastMessageType.Video => "video",
                BroadcastMessageType.Audio => "audio",
                BroadcastMessageType.Document => "document",
                BroadcastMessageType.Template => "template",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
