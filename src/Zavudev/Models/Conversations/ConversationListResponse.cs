using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Messages;

namespace Zavudev.Models.Conversations;

/// <summary>
/// An inbox thread with one contact. A conversation groups every message exchanged
/// with that contact across channels, so a contact who writes on WhatsApp and later
/// by email stays in one thread.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConversationListResponse, ConversationListResponseFromRaw>)
)]
public sealed record class ConversationListResponse : JsonModel
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
    /// Every channel this thread has carried messages on.
    /// </summary>
    public required IReadOnlyList<string> Channels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("channels");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "channels",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// The key this thread is filed under: a phone number in E.164, a WhatsApp business-scoped
    /// user ID (BSUID), a numeric chat ID (Telegram/Instagram/Messenger), or a group
    /// JID. It is not always a phone number, so do not parse it as one.
    /// </summary>
    public required string ContactIdentifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("contactIdentifier");
        }
        init { this._rawData.Set("contactIdentifier", value); }
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
    /// Denormalized preview of the most recent message, so a thread list needs no
    /// extra fetch.
    /// </summary>
    public required ConversationListResponseLastMessage LastMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ConversationListResponseLastMessage>(
                "lastMessage"
            );
        }
        init { this._rawData.Set("lastMessage", value); }
    }

    public required long MessageCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("messageCount");
        }
        init { this._rawData.Set("messageCount", value); }
    }

    /// <summary>
    /// Inbound messages not yet marked read. Reset with POST /v1/conversations/{conversationId}/read.
    /// </summary>
    public required long UnreadCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("unreadCount");
        }
        init { this._rawData.Set("unreadCount", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// ID of the contact this thread belongs to. Absent on group threads and on
    /// threads whose contact has not been resolved yet.
    /// </summary>
    public string? ContactID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("contactId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("contactId", value);
        }
    }

    /// <summary>
    /// Email address of the thread, when the contact was reached by email.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// Present when the thread is a group chat rather than a one-to-one conversation.
    /// </summary>
    public ConversationListResponseGroup? Group
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationListResponseGroup>("group");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("group", value);
        }
    }

    /// <summary>
    /// Sender that last handled this thread. Use it as the `Zavu-Sender` header
    /// when replying so the answer leaves from the same number the contact knows.
    /// </summary>
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
    /// WhatsApp identity, present when the contact adopted a username.
    /// </summary>
    public ConversationListResponseWhatsapp? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ConversationListResponseWhatsapp>("whatsapp");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("whatsapp", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Channels;
        _ = this.ContactIdentifier;
        _ = this.CreatedAt;
        this.LastMessage.Validate();
        _ = this.MessageCount;
        _ = this.UnreadCount;
        _ = this.UpdatedAt;
        _ = this.ContactID;
        _ = this.Email;
        this.Group?.Validate();
        _ = this.SenderID;
        this.Whatsapp?.Validate();
    }

    public ConversationListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListResponse(ConversationListResponse conversationListResponse)
        : base(conversationListResponse) { }
#pragma warning restore CS8618

    public ConversationListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListResponseFromRaw.FromRawUnchecked"/>
    public static ConversationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListResponseFromRaw : IFromRawJson<ConversationListResponse>
{
    /// <inheritdoc/>
    public ConversationListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// Denormalized preview of the most recent message, so a thread list needs no extra fetch.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListResponseLastMessage,
        ConversationListResponseLastMessageFromRaw
    >)
)]
public sealed record class ConversationListResponseLastMessage : JsonModel
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

    public required DateTimeOffset At
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("at");
        }
        init { this._rawData.Set("at", value); }
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

    public required ApiEnum<string, ConversationListResponseLastMessageDirection> Direction
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, ConversationListResponseLastMessageDirection>
            >("direction");
        }
        init { this._rawData.Set("direction", value); }
    }

    /// <summary>
    /// Text or caption. Empty when the last message carried no text (e.g. media).
    /// </summary>
    public required string Text
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("text");
        }
        init { this._rawData.Set("text", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.At;
        this.Channel.Validate();
        this.Direction.Validate();
        _ = this.Text;
    }

    public ConversationListResponseLastMessage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListResponseLastMessage(
        ConversationListResponseLastMessage conversationListResponseLastMessage
    )
        : base(conversationListResponseLastMessage) { }
#pragma warning restore CS8618

    public ConversationListResponseLastMessage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListResponseLastMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListResponseLastMessageFromRaw.FromRawUnchecked"/>
    public static ConversationListResponseLastMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListResponseLastMessageFromRaw : IFromRawJson<ConversationListResponseLastMessage>
{
    /// <inheritdoc/>
    public ConversationListResponseLastMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListResponseLastMessage.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(ConversationListResponseLastMessageDirectionConverter))]
public enum ConversationListResponseLastMessageDirection
{
    Inbound,
    Outbound,
}

sealed class ConversationListResponseLastMessageDirectionConverter
    : JsonConverter<ConversationListResponseLastMessageDirection>
{
    public override ConversationListResponseLastMessageDirection Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "inbound" => ConversationListResponseLastMessageDirection.Inbound,
            "outbound" => ConversationListResponseLastMessageDirection.Outbound,
            _ => (ConversationListResponseLastMessageDirection)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConversationListResponseLastMessageDirection value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConversationListResponseLastMessageDirection.Inbound => "inbound",
                ConversationListResponseLastMessageDirection.Outbound => "outbound",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Present when the thread is a group chat rather than a one-to-one conversation.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<ConversationListResponseGroup, ConversationListResponseGroupFromRaw>)
)]
public sealed record class ConversationListResponseGroup : JsonModel
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

    public long? ParticipantCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("participantCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("participantCount", value);
        }
    }

    public string? Subject
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("subject");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("subject", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.ParticipantCount;
        _ = this.Subject;
    }

    public ConversationListResponseGroup() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListResponseGroup(
        ConversationListResponseGroup conversationListResponseGroup
    )
        : base(conversationListResponseGroup) { }
#pragma warning restore CS8618

    public ConversationListResponseGroup(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListResponseGroup(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListResponseGroupFromRaw.FromRawUnchecked"/>
    public static ConversationListResponseGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConversationListResponseGroup(string id)
        : this()
    {
        this.ID = id;
    }
}

class ConversationListResponseGroupFromRaw : IFromRawJson<ConversationListResponseGroup>
{
    /// <inheritdoc/>
    public ConversationListResponseGroup FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListResponseGroup.FromRawUnchecked(rawData);
}

/// <summary>
/// WhatsApp identity, present when the contact adopted a username.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ConversationListResponseWhatsapp,
        ConversationListResponseWhatsappFromRaw
    >)
)]
public sealed record class ConversationListResponseWhatsapp : JsonModel
{
    /// <summary>
    /// Business-scoped user ID. Can be used as `to` when sending.
    /// </summary>
    public string? Bsuid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("bsuid");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("bsuid", value);
        }
    }

    public string? Username
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("username");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("username", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Bsuid;
        _ = this.Username;
    }

    public ConversationListResponseWhatsapp() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListResponseWhatsapp(
        ConversationListResponseWhatsapp conversationListResponseWhatsapp
    )
        : base(conversationListResponseWhatsapp) { }
#pragma warning restore CS8618

    public ConversationListResponseWhatsapp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListResponseWhatsapp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationListResponseWhatsappFromRaw.FromRawUnchecked"/>
    public static ConversationListResponseWhatsapp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationListResponseWhatsappFromRaw : IFromRawJson<ConversationListResponseWhatsapp>
{
    /// <inheritdoc/>
    public ConversationListResponseWhatsapp FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationListResponseWhatsapp.FromRawUnchecked(rawData);
}
