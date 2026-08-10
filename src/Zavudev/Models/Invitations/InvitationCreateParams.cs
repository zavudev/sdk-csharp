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

namespace Zavudev.Models.Invitations;

/// <summary>
/// Create a partner invitation link for a client to connect a Meta channel. The
/// client opens the returned `url` and authorizes with Meta; the resulting sender
/// is created in your project when they finish, and the invitation transitions to `completed`.
///
/// <para>`connectionType` picks the channel: - `whatsapp_waba` (default): Meta's
/// embedded signup links an official WhatsApp Business Account. - `messenger`: the
/// client picks a Facebook Page they administer; its Messenger inbox (including
/// Marketplace chats) is routed to Zavu.</para>
///
/// <para>One invitation connects one channel — create one per channel to onboard
/// a client on several. `phoneNumberId` and `allowedPhoneCountries` apply to `whatsapp_waba` only.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class InvitationCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    /// <summary>
    /// ISO country codes for allowed phone numbers. Only valid when `connectionType`
    /// is `whatsapp_waba` — sending it with `messenger` returns 400.
    /// </summary>
    public IReadOnlyList<string>? AllowedPhoneCountries
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<ImmutableArray<string>>(
                "allowedPhoneCountries"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<string>?>(
                "allowedPhoneCountries",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Email of the client being invited.
    /// </summary>
    public string? ClientEmail
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("clientEmail");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("clientEmail", value);
        }
    }

    /// <summary>
    /// Name of the client being invited.
    /// </summary>
    public string? ClientName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("clientName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("clientName", value);
        }
    }

    /// <summary>
    /// Phone number of the client in E.164 format.
    /// </summary>
    public string? ClientPhone
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("clientPhone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("clientPhone", value);
        }
    }

    /// <summary>
    /// Which Meta channel the client connects, and how. - `whatsapp_waba` (default):
    /// Meta's embedded signup links an official WhatsApp Business Account. Accepts
    /// `phoneNumberId` and `allowedPhoneCountries`. - `messenger`: the client authorizes
    /// with Facebook and picks a Facebook Page they administer. The Page's Messenger
    /// inbox — including Marketplace chats — is routed to Zavu. They must be an admin
    /// of at least one Page. A Page can only be connected to one Zavu project at
    /// a time: if the client picks a Page that another project already connected,
    /// the newer connection wins and the older one is disconnected.
    ///
    /// <para>One invitation connects one channel. To onboard a client on several
    /// channels, create one invitation per channel; each completes into its own sender.</para>
    /// </summary>
    public ApiEnum<string, ConnectionType>? ConnectionType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, ConnectionType>>(
                "connectionType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("connectionType", value);
        }
    }

    /// <summary>
    /// Number of days until the invitation expires.
    /// </summary>
    public long? ExpiresInDays
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<long>("expiresInDays");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("expiresInDays", value);
        }
    }

    /// <summary>
    /// ID of a Zavu phone number to pre-assign for WhatsApp registration. If provided,
    /// the client will use this number instead of their own. Only valid when `connectionType`
    /// is `whatsapp_waba` — sending it with `messenger` returns 400, since a Facebook
    /// Page has no phone number.
    /// </summary>
    public string? PhoneNumberID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("phoneNumberId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("phoneNumberId", value);
        }
    }

    public InvitationCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public InvitationCreateParams(InvitationCreateParams invitationCreateParams)
        : base(invitationCreateParams)
    {
        this._rawBodyData = new(invitationCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public InvitationCreateParams(
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
    InvitationCreateParams(
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
    public static InvitationCreateParams FromRawUnchecked(
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

    public virtual bool Equals(InvitationCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/invitations")
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
/// Which Meta channel the client connects, and how. - `whatsapp_waba` (default):
/// Meta's embedded signup links an official WhatsApp Business Account. Accepts `phoneNumberId`
/// and `allowedPhoneCountries`. - `messenger`: the client authorizes with Facebook
/// and picks a Facebook Page they administer. The Page's Messenger inbox — including
/// Marketplace chats — is routed to Zavu. They must be an admin of at least one
/// Page. A Page can only be connected to one Zavu project at a time: if the client
/// picks a Page that another project already connected, the newer connection wins
/// and the older one is disconnected.
///
/// <para>One invitation connects one channel. To onboard a client on several channels,
/// create one invitation per channel; each completes into its own sender.</para>
/// </summary>
[JsonConverter(typeof(ConnectionTypeConverter))]
public enum ConnectionType
{
    WhatsappWaba,
    Messenger,
}

sealed class ConnectionTypeConverter : JsonConverter<ConnectionType>
{
    public override ConnectionType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "whatsapp_waba" => ConnectionType.WhatsappWaba,
            "messenger" => ConnectionType.Messenger,
            _ => (ConnectionType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ConnectionType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ConnectionType.WhatsappWaba => "whatsapp_waba",
                ConnectionType.Messenger => "messenger",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
