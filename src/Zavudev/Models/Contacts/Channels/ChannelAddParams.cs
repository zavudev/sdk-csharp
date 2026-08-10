using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Contacts.Channels;

/// <summary>
/// Add a new communication channel to an existing contact.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ChannelAddParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? ContactID { get; init; }

    /// <summary>
    /// Channel type.
    /// </summary>
    public required ApiEnum<string, Channel> Channel
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, Channel>>("channel");
        }
        init { this._rawBodyData.Set("channel", value); }
    }

    /// <summary>
    /// Channel identifier (phone number in E.164 format or email address).
    /// </summary>
    public required string Identifier
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("identifier");
        }
        init { this._rawBodyData.Set("identifier", value); }
    }

    /// <summary>
    /// ISO country code for phone numbers.
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("countryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("countryCode", value);
        }
    }

    /// <summary>
    /// Whether this should be the primary channel for its type.
    /// </summary>
    public bool? IsPrimary
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("isPrimary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("isPrimary", value);
        }
    }

    /// <summary>
    /// Optional label for the channel.
    /// </summary>
    public string? Label
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("label");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("label", value);
        }
    }

    public ChannelAddParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ChannelAddParams(ChannelAddParams channelAddParams)
        : base(channelAddParams)
    {
        this.ContactID = channelAddParams.ContactID;

        this._rawBodyData = new(channelAddParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ChannelAddParams(
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
    ChannelAddParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string contactID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.ContactID = contactID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static ChannelAddParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string contactID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            contactID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["ContactID"] = JsonSerializer.SerializeToElement(this.ContactID),
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

    public virtual bool Equals(ChannelAddParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.ContactID?.Equals(other.ContactID) ?? other.ContactID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/contacts/{0}/channels", this.ContactID)
        )
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
/// Channel type.
/// </summary>
[JsonConverter(typeof(ChannelConverter))]
public enum Channel
{
    Sms,
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
