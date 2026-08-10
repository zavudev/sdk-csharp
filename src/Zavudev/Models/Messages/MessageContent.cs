using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Messages;

/// <summary>
/// Content for non-text message types (WhatsApp and Telegram).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<MessageContent, MessageContentFromRaw>))]
public sealed record class MessageContent : JsonModel
{
    /// <summary>
    /// Interactive buttons (max 3).
    /// </summary>
    public IReadOnlyList<Button>? Buttons
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Button>>("buttons");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Button>?>(
                "buttons",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Contact cards for contact messages.
    /// </summary>
    public IReadOnlyList<Contact>? Contacts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Contact>>("contacts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Contact>?>(
                "contacts",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Button label for cta_url messages.
    /// </summary>
    public string? CtaDisplayText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ctaDisplayText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ctaDisplayText", value);
        }
    }

    /// <summary>
    /// Public HTTPS URL of the header media when ctaHeaderType is 'image', 'video',
    /// or 'document'. WhatsApp fetches this URL — it must be publicly reachable
    /// and return the declared content type.
    /// </summary>
    public string? CtaHeaderMediaUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ctaHeaderMediaUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ctaHeaderMediaUrl", value);
        }
    }

    /// <summary>
    /// Header text when ctaHeaderType is 'text'.
    /// </summary>
    public string? CtaHeaderText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ctaHeaderText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ctaHeaderText", value);
        }
    }

    /// <summary>
    /// Optional header type for cta_url messages.
    /// </summary>
    public ApiEnum<string, CtaHeaderType>? CtaHeaderType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, CtaHeaderType>>("ctaHeaderType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ctaHeaderType", value);
        }
    }

    /// <summary>
    /// Destination URL opened in the device's default browser when the button is
    /// tapped. Used with messageType=cta_url. WhatsApp requires HTTPS in production.
    /// </summary>
    public string? CtaUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ctaUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("ctaUrl", value);
        }
    }

    /// <summary>
    /// Emoji for reaction messages.
    /// </summary>
    public string? Emoji
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("emoji");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("emoji", value);
        }
    }

    /// <summary>
    /// Filename for documents.
    /// </summary>
    public string? Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("filename");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("filename", value);
        }
    }

    /// <summary>
    /// Optional footer text for cta_url messages.
    /// </summary>
    public string? FooterText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("footerText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("footerText", value);
        }
    }

    /// <summary>
    /// Latitude for location messages.
    /// </summary>
    public double? Latitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("latitude");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("latitude", value);
        }
    }

    /// <summary>
    /// Button text for list messages.
    /// </summary>
    public string? ListButton
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("listButton");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("listButton", value);
        }
    }

    /// <summary>
    /// Address of the location.
    /// </summary>
    public string? LocationAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locationAddress");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locationAddress", value);
        }
    }

    /// <summary>
    /// Name of the location.
    /// </summary>
    public string? LocationName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locationName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locationName", value);
        }
    }

    /// <summary>
    /// Longitude for location messages.
    /// </summary>
    public double? Longitude
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("longitude");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("longitude", value);
        }
    }

    /// <summary>
    /// WhatsApp media ID if already uploaded.
    /// </summary>
    public string? MediaID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaId", value);
        }
    }

    /// <summary>
    /// URL of the media file (for image, video, audio, document, sticker).
    /// </summary>
    public string? MediaUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mediaUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mediaUrl", value);
        }
    }

    /// <summary>
    /// MIME type of the media.
    /// </summary>
    public string? MimeType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("mimeType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("mimeType", value);
        }
    }

    /// <summary>
    /// Message ID to react to.
    /// </summary>
    public string? ReactToMessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reactToMessageId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("reactToMessageId", value);
        }
    }

    /// <summary>
    /// Sender of the quoted message (phone number in E.164 format).
    /// </summary>
    public string? ReplyToFrom
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("replyToFrom");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("replyToFrom", value);
        }
    }

    /// <summary>
    /// Zavu message ID of the quoted message this message replies to. Present on
    /// inbound messages that quote an earlier message. Omitted when the quoted message
    /// is not found in Zavu (e.g. an old or unknown message) — use replyToProviderMessageId
    /// in that case.
    /// </summary>
    public string? ReplyToMessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("replyToMessageId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("replyToMessageId", value);
        }
    }

    /// <summary>
    /// Type of the quoted message (text, image, video, etc.).
    /// </summary>
    public string? ReplyToMessageType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("replyToMessageType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("replyToMessageType", value);
        }
    }

    /// <summary>
    /// Provider message ID (WhatsApp WAMID) of the quoted message. Present whenever
    /// an inbound message is a reply, even if the quoted message is not stored in Zavu.
    /// </summary>
    public string? ReplyToProviderMessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("replyToProviderMessageId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("replyToProviderMessageId", value);
        }
    }

    /// <summary>
    /// Truncated snippet of the quoted message's text, for display. Empty when the
    /// quoted message has no text (e.g. media).
    /// </summary>
    public string? ReplyToText
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("replyToText");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("replyToText", value);
        }
    }

    /// <summary>
    /// Sections for list messages.
    /// </summary>
    public IReadOnlyList<Section>? Sections
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<Section>>("sections");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<Section>?>(
                "sections",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Variables for dynamic button placeholders (URL buttons and OTP buttons).
    /// Keys are the button index (0, 1, 2) in the template's `buttons` array — not
    /// the placeholder name. Values substitute the `{{1}}` placeholder inside that
    /// button's URL.
    ///
    /// <para>**WhatsApp constraints:** - URL buttons only accept `{{1}}` — positional,
    /// numeric, no whitespace, no name. Named placeholders like `{{token}}` are
    /// stored as literal URL text by Meta and cannot be substituted. - At most one
    /// placeholder per URL button. - A template may have at most three buttons.
    /// - Static URL buttons (no placeholder) and `quick_reply` buttons are not included here.</para>
    /// </summary>
    public IReadOnlyDictionary<string, string>? TemplateButtonVariables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "templateButtonVariables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "templateButtonVariables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Value for a text-header variable, keyed by `1` (WhatsApp text headers allow
    /// at most one variable). Optional override. If omitted, Zavu resolves the header
    /// from `templateVariables` using the header placeholder's name (e.g. `novios`).
    /// Static text headers need no value.
    /// </summary>
    public IReadOnlyDictionary<string, string>? TemplateHeaderVariables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "templateHeaderVariables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "templateHeaderVariables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Template ID for template messages.
    /// </summary>
    public string? TemplateID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("templateId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("templateId", value);
        }
    }

    /// <summary>
    /// Variables for body placeholders. Key them to match the template body: by
    /// position (`1`, `2`, ...) for positional templates, or by name (e.g. `customer_name`)
    /// for named templates. Zavu detects the template's format and sends the correct
    /// payload to Meta. Named keys also resolve a named text-header variable. Do
    /// not mix positional and named keys in the same request.
    /// </summary>
    public IReadOnlyDictionary<string, string>? TemplateVariables
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>(
                "templateVariables"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "templateVariables",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Buttons ?? [])
        {
            item.Validate();
        }
        foreach (var item in this.Contacts ?? [])
        {
            item.Validate();
        }
        _ = this.CtaDisplayText;
        _ = this.CtaHeaderMediaUrl;
        _ = this.CtaHeaderText;
        this.CtaHeaderType?.Validate();
        _ = this.CtaUrl;
        _ = this.Emoji;
        _ = this.Filename;
        _ = this.FooterText;
        _ = this.Latitude;
        _ = this.ListButton;
        _ = this.LocationAddress;
        _ = this.LocationName;
        _ = this.Longitude;
        _ = this.MediaID;
        _ = this.MediaUrl;
        _ = this.MimeType;
        _ = this.ReactToMessageID;
        _ = this.ReplyToFrom;
        _ = this.ReplyToMessageID;
        _ = this.ReplyToMessageType;
        _ = this.ReplyToProviderMessageID;
        _ = this.ReplyToText;
        foreach (var item in this.Sections ?? [])
        {
            item.Validate();
        }
        _ = this.TemplateButtonVariables;
        _ = this.TemplateHeaderVariables;
        _ = this.TemplateID;
        _ = this.TemplateVariables;
    }

    public MessageContent() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageContent(MessageContent messageContent)
        : base(messageContent) { }
#pragma warning restore CS8618

    public MessageContent(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageContent(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageContentFromRaw.FromRawUnchecked"/>
    public static MessageContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageContentFromRaw : IFromRawJson<MessageContent>
{
    /// <inheritdoc/>
    public MessageContent FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        MessageContent.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Button, ButtonFromRaw>))]
public sealed record class Button : JsonModel
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

    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Title;
    }

    public Button() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Button(Button button)
        : base(button) { }
#pragma warning restore CS8618

    public Button(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Button(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ButtonFromRaw.FromRawUnchecked"/>
    public static Button FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ButtonFromRaw : IFromRawJson<Button>
{
    /// <inheritdoc/>
    public Button FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Button.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Contact, ContactFromRaw>))]
public sealed record class Contact : JsonModel
{
    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    public IReadOnlyList<string>? Phones
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("phones");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<string>?>(
                "phones",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        _ = this.Phones;
    }

    public Contact() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Contact(Contact contact)
        : base(contact) { }
#pragma warning restore CS8618

    public Contact(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Contact(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactFromRaw.FromRawUnchecked"/>
    public static Contact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactFromRaw : IFromRawJson<Contact>
{
    /// <inheritdoc/>
    public Contact FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Contact.FromRawUnchecked(rawData);
}

/// <summary>
/// Optional header type for cta_url messages.
/// </summary>
[JsonConverter(typeof(CtaHeaderTypeConverter))]
public enum CtaHeaderType
{
    Text,
    Image,
    Video,
    Document,
}

sealed class CtaHeaderTypeConverter : JsonConverter<CtaHeaderType>
{
    public override CtaHeaderType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "text" => CtaHeaderType.Text,
            "image" => CtaHeaderType.Image,
            "video" => CtaHeaderType.Video,
            "document" => CtaHeaderType.Document,
            _ => (CtaHeaderType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        CtaHeaderType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                CtaHeaderType.Text => "text",
                CtaHeaderType.Image => "image",
                CtaHeaderType.Video => "video",
                CtaHeaderType.Document => "document",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<Section, SectionFromRaw>))]
public sealed record class Section : JsonModel
{
    public required IReadOnlyList<Row> Rows
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Row>>("rows");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Row>>("rows", ImmutableArray.ToImmutableArray(value));
        }
    }

    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Rows)
        {
            item.Validate();
        }
        _ = this.Title;
    }

    public Section() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Section(Section section)
        : base(section) { }
#pragma warning restore CS8618

    public Section(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Section(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SectionFromRaw.FromRawUnchecked"/>
    public static Section FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SectionFromRaw : IFromRawJson<Section>
{
    /// <inheritdoc/>
    public Section FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Section.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Row, RowFromRaw>))]
public sealed record class Row : JsonModel
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

    public required string Title
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("title");
        }
        init { this._rawData.Set("title", value); }
    }

    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Title;
        _ = this.Description;
    }

    public Row() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Row(Row row)
        : base(row) { }
#pragma warning restore CS8618

    public Row(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Row(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RowFromRaw.FromRawUnchecked"/>
    public static Row FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RowFromRaw : IFromRawJson<Row>
{
    /// <inheritdoc/>
    public Row FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Row.FromRawUnchecked(rawData);
}
