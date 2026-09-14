using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Conversations;

/// <summary>
/// List inbox threads, most recently active first. A conversation groups every message
/// with one contact across channels, which is what you need to build an inbox: `GET
/// /v1/messages` returns a flat log with no thread to hang it on.
///
/// <para>Use `senderId` to scope the list to a single number, and `channel` to keep
/// only threads that have carried that channel.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ConversationListParams : ParamsBase
{
    /// <summary>
    /// Keep only threads that have carried this channel.
    /// </summary>
    public ApiEnum<string, Channel>? Channel
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, Channel>>("channel");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("channel", value);
        }
    }

    /// <summary>
    /// Opaque cursor from a previous response's `nextCursor`. Do not construct it.
    /// </summary>
    public string? Cursor
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("cursor");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("cursor", value);
        }
    }

    public long? Limit
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableStruct<long>("limit");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("limit", value);
        }
    }

    /// <summary>
    /// Search threads by identity: phone number (any format — `+1 (555) 123-4567`
    /// and `15551234567` both match), email address (full or local part), WhatsApp
    /// group subject, WhatsApp username, or BSUID. Matching is by whole word, with
    /// prefix matching on the last term, so `mar` finds `maria@example.com` and
    /// `+1555` finds `+15551234567`; a fragment from the middle or end of a number
    /// (`4567`) does not match.
    ///
    /// <para>It does **not** search message bodies — only who the thread is with.</para>
    ///
    /// <para>Results come back ranked by relevance rather than by recency, so the
    /// usual "most recently active first" ordering does not apply while `q` is set.
    /// `senderId` and `channel` still narrow the results, and `cursor` paginates
    /// them as usual. An empty or whitespace-only `q` returns no items rather than
    /// the full list.</para>
    /// </summary>
    public string? Search
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("search");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("search", value);
        }
    }

    /// <summary>
    /// Keep only threads last handled by this sender.
    /// </summary>
    public string? SenderID
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("senderId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("senderId", value);
        }
    }

    public ConversationListParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ConversationListParams(ConversationListParams conversationListParams)
        : base(conversationListParams) { }
#pragma warning restore CS8618

    public ConversationListParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ConversationListParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ConversationListParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(ConversationListParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/conversations")
        {
            Query = this.QueryString(options),
        }.Uri;
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
/// Keep only threads that have carried this channel.
/// </summary>
[JsonConverter(typeof(ChannelConverter))]
public enum Channel
{
    Sms,
    SmsOneway,
    Whatsapp,
    Email,
    Telegram,
    Instagram,
    Messenger,
    Voice,
}

sealed class ChannelConverter : JsonConverter<Channel>
{
    public override Channel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => Channel.Sms,
            "sms_oneway" => Channel.SmsOneway,
            "whatsapp" => Channel.Whatsapp,
            "email" => Channel.Email,
            "telegram" => Channel.Telegram,
            "instagram" => Channel.Instagram,
            "messenger" => Channel.Messenger,
            "voice" => Channel.Voice,
            _ => (Channel)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Channel value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Channel.Sms => "sms",
                Channel.SmsOneway => "sms_oneway",
                Channel.Whatsapp => "whatsapp",
                Channel.Email => "email",
                Channel.Telegram => "telegram",
                Channel.Instagram => "instagram",
                Channel.Messenger => "messenger",
                Channel.Voice => "voice",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
