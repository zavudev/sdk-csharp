using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Exceptions;

namespace Zavudev.Models.Messages;

/// <summary>
/// Type of message. Non-text types are supported by WhatsApp and Telegram (varies
/// by type).
///
/// <para>`location_request` asks the recipient to share their location and is WhatsApp-only.
/// It takes no `content` object — the prompt goes in `text` (max 1024 characters)
/// and the button label is fixed by WhatsApp. The recipient's answer arrives as
/// an inbound `location` message whose `content.replyToMessageId` is the ID of the request.</para>
///
/// <para>`request_contact_info` asks the recipient to share their phone number and
/// is WhatsApp-only. Like `location_request` it takes no `content` object — the prompt
/// goes in `text` (max 1024 characters) and WhatsApp renders a fixed **Share Contact
/// Info** button. The answer arrives as an inbound `contact` message. Use it to
/// recover the phone number of a contact who adopted a WhatsApp username and is
/// only known by their business-scoped user ID (BSUID); when they share it, Zavu
/// automatically links the phone number to that contact.</para>
/// </summary>
[JsonConverter(typeof(MessageTypeConverter))]
public enum MessageType
{
    Text,
    Image,
    Video,
    Audio,
    Document,
    Sticker,
    Location,
    Contact,
    Buttons,
    List,
    CtaUrl,
    RequestContactInfo,
    LocationRequest,
    Reaction,
    Template,
}

sealed class MessageTypeConverter : JsonConverter<MessageType>
{
    public override MessageType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => MessageType.Text,
            "image" => MessageType.Image,
            "video" => MessageType.Video,
            "audio" => MessageType.Audio,
            "document" => MessageType.Document,
            "sticker" => MessageType.Sticker,
            "location" => MessageType.Location,
            "contact" => MessageType.Contact,
            "buttons" => MessageType.Buttons,
            "list" => MessageType.List,
            "cta_url" => MessageType.CtaUrl,
            "request_contact_info" => MessageType.RequestContactInfo,
            "location_request" => MessageType.LocationRequest,
            "reaction" => MessageType.Reaction,
            "template" => MessageType.Template,
            _ => (MessageType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MessageType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MessageType.Text => "text",
                MessageType.Image => "image",
                MessageType.Video => "video",
                MessageType.Audio => "audio",
                MessageType.Document => "document",
                MessageType.Sticker => "sticker",
                MessageType.Location => "location",
                MessageType.Contact => "contact",
                MessageType.Buttons => "buttons",
                MessageType.List => "list",
                MessageType.CtaUrl => "cta_url",
                MessageType.RequestContactInfo => "request_contact_info",
                MessageType.LocationRequest => "location_request",
                MessageType.Reaction => "reaction",
                MessageType.Template => "template",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
