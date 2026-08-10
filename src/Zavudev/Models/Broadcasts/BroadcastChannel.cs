using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Broadcasts;

/// <summary>
/// Broadcast delivery channel. Use 'smart' for per-contact intelligent routing.
/// </summary>
[JsonConverter(typeof(BroadcastChannelConverter))]
public enum BroadcastChannel
{
    Smart,
    Sms,
    SmsOneway,
    Whatsapp,
    Telegram,
    Email,
}

sealed class BroadcastChannelConverter : JsonConverter<BroadcastChannel>
{
    public override BroadcastChannel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "smart" => BroadcastChannel.Smart,
            "sms" => BroadcastChannel.Sms,
            "sms_oneway" => BroadcastChannel.SmsOneway,
            "whatsapp" => BroadcastChannel.Whatsapp,
            "telegram" => BroadcastChannel.Telegram,
            "email" => BroadcastChannel.Email,
            _ => (BroadcastChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BroadcastChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BroadcastChannel.Smart => "smart",
                BroadcastChannel.Sms => "sms",
                BroadcastChannel.SmsOneway => "sms_oneway",
                BroadcastChannel.Whatsapp => "whatsapp",
                BroadcastChannel.Telegram => "telegram",
                BroadcastChannel.Email => "email",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
