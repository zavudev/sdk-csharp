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

[JsonConverter(
    typeof(JsonModelConverter<ConversationRetrieveResponse, ConversationRetrieveResponseFromRaw>)
)]
public sealed record class ConversationRetrieveResponse : JsonModel
{
    /// <summary>
    /// An inbox thread with one contact. A conversation groups every message exchanged
    /// with that contact across channels, so a contact who writes on WhatsApp and
    /// later by email stays in one thread.
    /// </summary>
    public required Conversation Conversation
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Conversation>("conversation");
        }
        init { this._rawData.Set("conversation", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Conversation.Validate();
    }

    public ConversationRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationRetrieveResponse(ConversationRetrieveResponse conversationRetrieveResponse)
        : base(conversationRetrieveResponse) { }
#pragma warning restore CS8618

    public ConversationRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static ConversationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ConversationRetrieveResponse(Conversation conversation)
        : this()
    {
        this.Conversation = conversation;
    }
}

class ConversationRetrieveResponseFromRaw : IFromRawJson<ConversationRetrieveResponse>
{
    /// <inheritdoc/>
    public ConversationRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ConversationRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// An inbox thread with one contact. A conversation groups every message exchanged
/// with that contact across channels, so a contact who writes on WhatsApp and later
/// by email stays in one thread.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Conversation, ConversationFromRaw>))]
public sealed record class Conversation : JsonModel
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
    public required LastMessage LastMessage
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<LastMessage>("lastMessage");
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
    public Group? Group
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Group>("group");
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
    public Whatsapp? Whatsapp
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Whatsapp>("whatsapp");
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

    public Conversation() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Conversation(Conversation conversation)
        : base(conversation) { }
#pragma warning restore CS8618

    public Conversation(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Conversation(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ConversationFromRaw.FromRawUnchecked"/>
    public static Conversation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ConversationFromRaw : IFromRawJson<Conversation>
{
    /// <inheritdoc/>
    public Conversation FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Conversation.FromRawUnchecked(rawData);
}

/// <summary>
/// Denormalized preview of the most recent message, so a thread list needs no extra fetch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<LastMessage, LastMessageFromRaw>))]
public sealed record class LastMessage : JsonModel
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

    public LastMessage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public LastMessage(LastMessage lastMessage)
        : base(lastMessage) { }
#pragma warning restore CS8618

    public LastMessage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    LastMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="LastMessageFromRaw.FromRawUnchecked"/>
    public static LastMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class LastMessageFromRaw : IFromRawJson<LastMessage>
{
    /// <inheritdoc/>
    public LastMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        LastMessage.FromRawUnchecked(rawData);
}

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

/// <summary>
/// Present when the thread is a group chat rather than a one-to-one conversation.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Group, GroupFromRaw>))]
public sealed record class Group : JsonModel
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

    public Group() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Group(Group group)
        : base(group) { }
#pragma warning restore CS8618

    public Group(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Group(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="GroupFromRaw.FromRawUnchecked"/>
    public static Group FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public Group(string id)
        : this()
    {
        this.ID = id;
    }
}

class GroupFromRaw : IFromRawJson<Group>
{
    /// <inheritdoc/>
    public Group FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Group.FromRawUnchecked(rawData);
}

/// <summary>
/// WhatsApp identity, present when the contact adopted a username.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Whatsapp, WhatsappFromRaw>))]
public sealed record class Whatsapp : JsonModel
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

    public Whatsapp() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Whatsapp(Whatsapp whatsapp)
        : base(whatsapp) { }
#pragma warning restore CS8618

    public Whatsapp(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Whatsapp(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WhatsappFromRaw.FromRawUnchecked"/>
    public static Whatsapp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class WhatsappFromRaw : IFromRawJson<Whatsapp>
{
    /// <inheritdoc/>
    public Whatsapp FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Whatsapp.FromRawUnchecked(rawData);
}
