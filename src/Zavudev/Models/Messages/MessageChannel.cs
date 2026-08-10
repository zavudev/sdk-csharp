using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Messages;

/// <summary>
/// Delivery channel. Use 'auto' for intelligent routing.
/// </summary>
[JsonConverter(typeof(MessageChannelConverter))]
public enum MessageChannel
{
    Auto,
    Sms,
    SmsOneway,
    Whatsapp,
    Telegram,
    Email,
    Instagram,
    Messenger,
    Voice,
}

sealed class MessageChannelConverter : JsonConverter<MessageChannel>
{
    public override MessageChannel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "auto" => MessageChannel.Auto,
            "sms" => MessageChannel.Sms,
            "sms_oneway" => MessageChannel.SmsOneway,
            "whatsapp" => MessageChannel.Whatsapp,
            "telegram" => MessageChannel.Telegram,
            "email" => MessageChannel.Email,
            "instagram" => MessageChannel.Instagram,
            "messenger" => MessageChannel.Messenger,
            "voice" => MessageChannel.Voice,
            _ => (MessageChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessageChannel.Auto => "auto",
                MessageChannel.Sms => "sms",
                MessageChannel.SmsOneway => "sms_oneway",
                MessageChannel.Whatsapp => "whatsapp",
                MessageChannel.Telegram => "telegram",
                MessageChannel.Email => "email",
                MessageChannel.Instagram => "instagram",
                MessageChannel.Messenger => "messenger",
                MessageChannel.Voice => "voice",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
