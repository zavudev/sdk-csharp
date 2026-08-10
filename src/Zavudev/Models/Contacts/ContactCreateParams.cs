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
using Zavudev.Exceptions;

namespace Zavudev.Models.Contacts;

/// <summary>
/// Create a new contact with one or more communication channels.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class ContactCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// Communication channels for the contact.
    /// </summary>
    public required IReadOnlyList<Channel> Channels
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullStruct<ImmutableArray<Channel>>("channels");
        }
        init
        {
            this._rawBodyData.Set<ImmutableArray<Channel>>(
                "channels",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Display name for the contact.
    /// </summary>
    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("displayName", value);
        }
    }

    /// <summary>
    /// Arbitrary metadata to associate with the contact.
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

    public ContactCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactCreateParams(ContactCreateParams contactCreateParams)
        : base(contactCreateParams)
    {
        this._rawBodyData = new(contactCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public ContactCreateParams(
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
    ContactCreateParams(
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
    public static ContactCreateParams FromRawUnchecked(
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

    public virtual bool Equals(ContactCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/contacts")
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
/// Input for creating a contact channel.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Channel, ChannelFromRaw>))]
public sealed record class Channel : JsonModel
{
    /// <summary>
    /// Channel type.
    /// </summary>
    public required ApiEnum<string, ChannelChannel> ChannelValue
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ChannelChannel>>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// Channel identifier (phone number in E.164 format or email address).
    /// </summary>
    public required string Identifier
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("identifier");
        }
        init { this._rawData.Set("identifier", value); }
    }

    /// <summary>
    /// ISO country code for phone numbers.
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("countryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("countryCode", value);
        }
    }

    /// <summary>
    /// Whether this should be the primary channel for its type.
    /// </summary>
    public bool? IsPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isPrimary");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isPrimary", value);
        }
    }

    /// <summary>
    /// Optional label for the channel.
    /// </summary>
    public string? Label
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("label");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("label", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ChannelValue.Validate();
        _ = this.Identifier;
        _ = this.CountryCode;
        _ = this.IsPrimary;
        _ = this.Label;
    }

    public Channel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Channel(Channel channel)
        : base(channel) { }
#pragma warning restore CS8618

    public Channel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Channel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ChannelFromRaw.FromRawUnchecked"/>
    public static Channel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ChannelFromRaw : IFromRawJson<Channel>
{
    /// <inheritdoc/>
    public Channel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Channel.FromRawUnchecked(rawData);
}

/// <summary>
/// Channel type.
/// </summary>
[JsonConverter(typeof(ChannelChannelConverter))]
public enum ChannelChannel
{
    Sms,
    Whatsapp,
    Email,
    Telegram,
    Instagram,
    Messenger,
    Voice,
}

sealed class ChannelChannelConverter : JsonConverter<ChannelChannel>
{
    public override ChannelChannel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => ChannelChannel.Sms,
            "whatsapp" => ChannelChannel.Whatsapp,
            "email" => ChannelChannel.Email,
            "telegram" => ChannelChannel.Telegram,
            "instagram" => ChannelChannel.Instagram,
            "messenger" => ChannelChannel.Messenger,
            "voice" => ChannelChannel.Voice,
            _ => (ChannelChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ChannelChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ChannelChannel.Sms => "sms",
                ChannelChannel.Whatsapp => "whatsapp",
                ChannelChannel.Email => "email",
                ChannelChannel.Telegram => "telegram",
                ChannelChannel.Instagram => "instagram",
                ChannelChannel.Messenger => "messenger",
                ChannelChannel.Voice => "voice",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
