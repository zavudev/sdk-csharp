using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Messages;

/// <summary>
/// Send a message to a recipient via SMS or WhatsApp.
///
/// <para>**Channel selection:** - If `channel` is omitted and `messageType` is `text`,
/// defaults to SMS - If `messageType` is anything other than `text`, WhatsApp is
/// used automatically</para>
///
/// <para>**WhatsApp 24-hour window:** - Free-form messages (non-template) require
/// an open 24h window - Window opens when the user messages you first - Use template
/// messages to initiate conversations outside the window</para>
///
/// <para>**Plan allowances and email billing:** - WhatsApp, Telegram, Instagram and
/// Messenger share an allowance of 2,000 messages per month on Free. Over it, sends
/// return 429 with code `a2p_limit_exceeded` and upgrade details; the counter resets
/// on the 1st of each month. Paid plans have no message caps - Email is billed from
/// your prepaid balance in 1,000-message blocks: $0.40 per 1,000 transactional emails,
/// $0.80 per 1,000 marketing (broadcast) emails. A block is charged when your monthly
/// count crosses each 1,000 boundary, and at zero balance email sends return 402
/// with code `insufficient_balance`. Free teams start with $2 of credit and additionally
/// cap at 3,000 emails/month and 100/day. Teams on earlier plans keep their original
/// email quotas instead - SMS and voice are billed per message from your balance
/// on every plan</para>
///
/// <para>**Email recipient pre-flight:** Email messages are validated automatically
/// before dispatch. Sends that would be a guaranteed hard bounce are failed instead
/// of sent, protecting your bounce rate: the message transitions to `failed` (visible
/// via `GET /v1/messages/{messageId}` and the `message.failed` webhook) with `errorCode`
/// set to `EMAIL_INVALID_RECIPIENT` (malformed address), `EMAIL_DOMAIN_NOT_FOUND`
/// (recipient domain has no MX or A records), or `EMAIL_RECIPIENT_SUPPRESSED` (address
/// is on your suppression list after a previous bounce or complaint). Advisory signals
/// (role addresses, disposable domains) do not block sends — check them beforehand
/// with `POST /v1/introspect/email`.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class MessageSendParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Recipient phone number in E.164 format, email address, WhatsApp business-scoped
    /// user ID (BSUID, e.g. `US.13491208655302741918`), or numeric chat ID (for
    /// Telegram/Instagram/Messenger). A BSUID is routed to WhatsApp and sent via
    /// the `recipient` field; use it to message a contact who adopted a username
    /// and whose phone number is hidden.
    /// </summary>
    public required string To
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("to");
        }
        init { this._rawBodyData.Set("to", value); }
    }

    /// <summary>
    /// Email attachments. Only supported when channel is 'email'. Maximum 40MB total size.
    /// </summary>
    public IReadOnlyList<Attachment>? Attachments
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<Attachment>>("attachments");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<Attachment>?>(
                "attachments",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Delivery channel. Use 'auto' for intelligent routing. If omitted, channel
    /// is auto-selected based on sender capabilities and recipient type. For email
    /// recipients, defaults to 'email'.
    /// </summary>
    public ApiEnum<string, MessageChannel>? Channel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MessageChannel>>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("channel", value);
        }
    }

    /// <summary>
    /// Additional content for non-text message types.
    /// </summary>
    public MessageContent? Content
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<MessageContent>("content");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("content", value);
        }
    }

    /// <summary>
    /// Whether to enable automatic fallback to SMS if WhatsApp fails. Defaults to true.
    /// </summary>
    public bool? FallbackEnabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("fallbackEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("fallbackEnabled", value);
        }
    }

    /// <summary>
    /// HTML body for email messages. If provided, email will be sent as multipart
    /// with both text and HTML.
    /// </summary>
    public string? HtmlBody
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("htmlBody");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("htmlBody", value);
        }
    }

    /// <summary>
    /// Optional idempotency key to avoid duplicate sends.
    /// </summary>
    public string? IdempotencyKey
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("idempotencyKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("idempotencyKey", value);
        }
    }

    /// <summary>
    /// Type of message. Defaults to 'text'.
    /// </summary>
    public ApiEnum<string, MessageType>? MessageType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, MessageType>>("messageType");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("messageType", value);
        }
    }

    /// <summary>
    /// Arbitrary metadata to associate with the message.
    /// </summary>
    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Reply-To email address for email messages.
    /// </summary>
    public string? ReplyTo
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("replyTo");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("replyTo", value);
        }
    }

    /// <summary>
    /// Email subject line. Required when channel is 'email' or recipient is an email address.
    /// </summary>
    public string? Subject
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("subject");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("subject", value);
        }
    }

    /// <summary>
    /// Text body for text messages or caption for media messages.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("text", value);
        }
    }

    /// <summary>
    /// Language code for voice text-to-speech (e.g., 'en-US', 'es-ES', 'pt-BR').
    /// If omitted, language is auto-detected from recipient's country code.
    /// </summary>
    public string? VoiceLanguage
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("voiceLanguage");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("voiceLanguage", value);
        }
    }

    public string? ZavuSender
    {
        get
        {
            this._rawHeaderData.Freeze();
            return this._rawHeaderData.GetNullableClass<string>("Zavu-Sender");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawHeaderData.Set("Zavu-Sender", value);
        }
    }

    public MessageSendParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public MessageSendParams(MessageSendParams messageSendParams)
        : base(messageSendParams)
    {
        this._rawBodyData = new(messageSendParams._rawBodyData);
    }
#pragma warning restore CS8618

    public MessageSendParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    MessageSendParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static MessageSendParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData)
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                    ["BodyData"] = FriendlyJsonPrinter.PrintValue(this._rawBodyData.Freeze()),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(MessageSendParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/messages")
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override HttpContent? BodyContent()
    {
        return new StringContent(
            JsonSerializer.Serialize(this.RawBodyData, ModelBase.SerializerOptions),
            Encoding.UTF8,
            "application/json"
        );
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}

/// <summary>
/// Email attachment. Provide either `content` (base64) or `path` (URL), not both.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Attachment, AttachmentFromRaw>))]
public sealed record class Attachment : JsonModel
{
    /// <summary>
    /// Name of the attached file.
    /// </summary>
    public required string Filename
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("filename");
        }
        init { this._rawData.Set("filename", value); }
    }

    /// <summary>
    /// Content of the attached file as a Base64-encoded string.
    /// </summary>
    public string? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content");
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

    /// <summary>
    /// Content ID for inline images. Reference in HTML as `&lt;img src="cid:your_content_id"&gt;`.
    /// </summary>
    public string? ContentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content_id", value);
        }
    }

    /// <summary>
    /// MIME type of the attachment. If not set, will be derived from the filename.
    /// </summary>
    public string? ContentType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("content_type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("content_type", value);
        }
    }

    /// <summary>
    /// URL where the attachment file is hosted. The server will fetch the file.
    /// </summary>
    public string? Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("path", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Filename;
        _ = this.Content;
        _ = this.ContentID;
        _ = this.ContentType;
        _ = this.Path;
    }

    public Attachment() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Attachment(Attachment attachment)
        : base(attachment) { }
#pragma warning restore CS8618

    public Attachment(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Attachment(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AttachmentFromRaw.FromRawUnchecked"/>
    public static Attachment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Attachment(string filename)
        : this()
    {
        this.Filename = filename;
    }
}

class AttachmentFromRaw : IFromRawJson<Attachment>
{
    /// <inheritdoc/>
    public Attachment FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Attachment.FromRawUnchecked(rawData);
}
