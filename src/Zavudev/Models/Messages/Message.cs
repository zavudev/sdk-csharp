using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Messages;

[JsonConverter(typeof(JsonModelConverter<Message, MessageFromRaw>))]
public sealed record class Message : JsonModel
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

    /// <summary>
    /// Delivery channel. Use 'auto' for intelligent routing.
    /// </summary>
    public required ApiEnum<string, MessageChannel> Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MessageChannel>>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    /// <summary>
    /// Who sent the message. Needed to render a thread: `status` cannot tell the
    /// two apart, because an inbound message is also stored as `delivered`.
    /// </summary>
    public required ApiEnum<string, Direction> Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Direction>>("direction");
        }
        init { this._rawData.Set("direction", value); }
    }

    /// <summary>
    /// Type of message. Non-text types are supported by WhatsApp and Telegram (varies
    /// by type).
    ///
    /// <para>`location_request` asks the recipient to share their location and is
    /// WhatsApp-only. It takes no `content` object — the prompt goes in `text` (max
    /// 1024 characters) and the button label is fixed by WhatsApp. The recipient's
    /// answer arrives as an inbound `location` message whose `content.replyToMessageId`
    /// is the ID of the request.</para>
    ///
    /// <para>`request_contact_info` asks the recipient to share their phone number
    /// and is WhatsApp-only. Like `location_request` it takes no `content` object
    /// — the prompt goes in `text` (max 1024 characters) and WhatsApp renders a
    /// fixed **Share Contact Info** button. The answer arrives as an inbound `contact`
    /// message. Use it to recover the phone number of a contact who adopted a WhatsApp
    /// username and is only known by their business-scoped user ID (BSUID); when
    /// they share it, Zavu automatically links the phone number to that contact.</para>
    /// </summary>
    public required ApiEnum<string, MessageType> MessageType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MessageType>>("messageType");
        }
        init { this._rawData.Set("messageType", value); }
    }

    public required ApiEnum<string, MessageStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, MessageStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string To
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("to");
        }
        init { this._rawData.Set("to", value); }
    }

    /// <summary>
    /// Content for non-text message types (WhatsApp and Telegram).
    /// </summary>
    public MessageContent? Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<MessageContent>("content");
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
    /// ID of the conversation (inbox thread) this message belongs to. Use it to build
    /// a direct dashboard link: `https://dashboard.zavu.dev/{locale}/inbox?conv={conversationId}`.
    /// Omitted only on legacy messages created before conversation threading.
    /// </summary>
    public string? ConversationID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("conversationId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conversationId", value);
        }
    }

    /// <summary>
    /// Zavu platform charge in USD for this message. Messaging is billed against
    /// your plan's monthly limits plus usage-based overage.
    /// </summary>
    public double? Cost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("cost");
        }
        init { this._rawData.Set("cost", value); }
    }

    /// <summary>
    /// Carrier and delivery cost in USD.
    /// </summary>
    public double? CostProvider
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("costProvider");
        }
        init { this._rawData.Set("costProvider", value); }
    }

    /// <summary>
    /// Total cost in USD (platform charge + delivery cost).
    /// </summary>
    public double? CostTotal
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("costTotal");
        }
        init { this._rawData.Set("costTotal", value); }
    }

    public string? ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorCode");
        }
        init { this._rawData.Set("errorCode", value); }
    }

    public string? ErrorMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("errorMessage");
        }
        init { this._rawData.Set("errorMessage", value); }
    }

    public string? From
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("from");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("from", value);
        }
    }

    public IReadOnlyDictionary<string, string>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, string>>("metadata");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, string>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Message ID from the delivery provider.
    /// </summary>
    public string? ProviderMessageID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("providerMessageId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("providerMessageId", value);
        }
    }

    public string? SenderID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("senderId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("senderId", value);
        }
    }

    /// <summary>
    /// Text content or caption.
    /// </summary>
    public string? Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("text");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("text", value);
        }
    }

    public DateTimeOffset? UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("updatedAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("updatedAt", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Channel.Validate();
        _ = this.CreatedAt;
        this.Direction.Validate();
        this.MessageType.Validate();
        this.Status.Validate();
        _ = this.To;
        this.Content?.Validate();
        _ = this.ConversationID;
        _ = this.Cost;
        _ = this.CostProvider;
        _ = this.CostTotal;
        _ = this.ErrorCode;
        _ = this.ErrorMessage;
        _ = this.From;
        _ = this.Metadata;
        _ = this.ProviderMessageID;
        _ = this.SenderID;
        _ = this.Text;
        _ = this.UpdatedAt;
    }

    public Message() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Message(Message message)
        : base(message) { }
#pragma warning restore CS8618

    public Message(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Message(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MessageFromRaw.FromRawUnchecked"/>
    public static Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MessageFromRaw : IFromRawJson<Message>
{
    /// <inheritdoc/>
    public Message FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Message.FromRawUnchecked(rawData);
}

/// <summary>
/// Who sent the message. Needed to render a thread: `status` cannot tell the two
/// apart, because an inbound message is also stored as `delivered`.
/// </summary>
[JsonConverter(typeof(DirectionConverter))]
public enum Direction
{
    Inbound,
    Outbound,
}

sealed class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound" => Direction.Inbound,
            "outbound" => Direction.Outbound,
            _ => (Direction)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Direction value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Direction.Inbound => "inbound",
                Direction.Outbound => "outbound",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
