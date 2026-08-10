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

namespace Zavudev.Models.Senders;

/// <summary>
/// Create sender
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SenderCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("name");
        }
        init { this._rawBodyData.Set("name", value); }
    }

    /// <summary>
    /// From-address for the email channel (e.g. noreply@yourdomain.com). The address's
    /// domain must be a verified email domain in your project. Setting this attaches
    /// the email channel to the sender.
    /// </summary>
    public string? EmailAddress
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("emailAddress");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("emailAddress", value);
        }
    }

    /// <summary>
    /// ID of the verified email domain to attach. Optional — resolved from `emailAddress`'s
    /// domain when omitted.
    /// </summary>
    public string? EmailDomainID
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("emailDomainId");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("emailDomainId", value);
        }
    }

    /// <summary>
    /// Display name shown in the recipient's inbox for the email channel.
    /// </summary>
    public string? EmailFromName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("emailFromName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("emailFromName", value);
        }
    }

    /// <summary>
    /// Enable inbound email receiving on this sender. Requires a verified MX record
    /// on the domain; ignored otherwise.
    /// </summary>
    public bool? EmailReceivingEnabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("emailReceivingEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("emailReceivingEnabled", value);
        }
    }

    /// <summary>
    /// Enable the one-way SMS channel (`sms_oneway`). Needs nothing else — no phone
    /// number, no credential — so it is the fastest way to get a sender that can
    /// send. Recipients cannot reply. Confirm with `sms_oneway` in the `channels`
    /// array on the response.
    /// </summary>
    public bool? EnableSmsOneway
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("enableSmsOneway");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("enableSmsOneway", value);
        }
    }

    /// <summary>
    /// Let this sender place and answer phone calls. Requires `phoneNumber`; enabling
    /// it without one returns 400. Check the `channels` array on the response to
    /// confirm `voice` is on.
    /// </summary>
    public bool? EnableVoice
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("enableVoice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("enableVoice", value);
        }
    }

    /// <summary>
    /// Phone number in E.164 format, and it must be a number your project already
    /// owns (see `GET /v1/phone-numbers`). The number is routed to the sender as
    /// part of this call, which is what turns the SMS channel on. Passing a number
    /// the project does not own, or one already attached to another sender, returns
    /// 400 rather than creating a sender that cannot send. Omit for an email-only sender.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("phoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("phoneNumber", value);
        }
    }

    public bool? SetAsDefault
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("setAsDefault");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("setAsDefault", value);
        }
    }

    /// <summary>
    /// Events to subscribe to.
    /// </summary>
    public IReadOnlyList<ApiEnum<string, WebhookEvent>>? WebhookEvents
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<
                ImmutableArray<ApiEnum<string, WebhookEvent>>
            >("webhookEvents");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set<ImmutableArray<ApiEnum<string, WebhookEvent>>?>(
                "webhookEvents",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Which `X-Zavu-Signature` scheme this receiver is sent.
    ///
    /// <para>- `v1`: `v1=HMAC_SHA256(secret, body)`. The scheme used before this
    /// was configurable. Existing webhooks stay on it until you move them. - `v2`:
    /// `v2=HMAC_SHA256(secret, "{t}.{body}")`. The current scheme, and the default
    /// for new senders. It signs the timestamp together with the body. - `v1+v2`:
    /// both signatures, sharing one `t`. The migration setting: a receiver reading
    /// either one works, so you can deploy and confirm your new verifier before switching over.</para>
    ///
    /// <para>Moving from `v1` straight to `v2` returns `400`. Set `v1+v2` first.
    /// See https://docs.zavu.dev/guides/receiving-messages/signature-migration</para>
    /// </summary>
    public ApiEnum<string, WebhookSignatureVersion>? WebhookSignatureVersion
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, WebhookSignatureVersion>>(
                "webhookSignatureVersion"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("webhookSignatureVersion", value);
        }
    }

    /// <summary>
    /// HTTPS URL for webhook events.
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("webhookUrl");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("webhookUrl", value);
        }
    }

    public SenderCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderCreateParams(SenderCreateParams senderCreateParams)
        : base(senderCreateParams)
    {
        this._rawBodyData = new(senderCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SenderCreateParams(
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
    SenderCreateParams(
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
    public static SenderCreateParams FromRawUnchecked(
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

    public virtual bool Equals(SenderCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/senders")
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
/// Which `X-Zavu-Signature` scheme this receiver is sent.
///
/// <para>- `v1`: `v1=HMAC_SHA256(secret, body)`. The scheme used before this was
/// configurable. Existing webhooks stay on it until you move them. - `v2`: `v2=HMAC_SHA256(secret,
/// "{t}.{body}")`. The current scheme, and the default for new senders. It signs
/// the timestamp together with the body. - `v1+v2`: both signatures, sharing one
/// `t`. The migration setting: a receiver reading either one works, so you can deploy
/// and confirm your new verifier before switching over.</para>
///
/// <para>Moving from `v1` straight to `v2` returns `400`. Set `v1+v2` first. See https://docs.zavu.dev/guides/receiving-messages/signature-migration</para>
/// </summary>
[JsonConverter(typeof(WebhookSignatureVersionConverter))]
public enum WebhookSignatureVersion
{
    V1,
    V1V2,
    V2,
}

sealed class WebhookSignatureVersionConverter : JsonConverter<WebhookSignatureVersion>
{
    public override WebhookSignatureVersion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "v1" => WebhookSignatureVersion.V1,
            "v1+v2" => WebhookSignatureVersion.V1V2,
            "v2" => WebhookSignatureVersion.V2,
            _ => (WebhookSignatureVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookSignatureVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookSignatureVersion.V1 => "v1",
                WebhookSignatureVersion.V1V2 => "v1+v2",
                WebhookSignatureVersion.V2 => "v2",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
