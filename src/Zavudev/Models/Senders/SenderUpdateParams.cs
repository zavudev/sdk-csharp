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
/// Update sender
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class SenderUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? SenderID { get; init; }

    /// <summary>
    /// Attach or change the sender's email from-address (e.g. noreply@yourdomain.com).
    /// The domain must be a verified email domain in your project.
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
    /// Enable or disable domain catch-all. When enabled (with emailReceivingEnabled
    /// true), this sender receives email for any address at its domain. Ignored (treated
    /// as false) if receiving is not enabled.
    /// </summary>
    public bool? EmailCatchAllEnabled
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("emailCatchAllEnabled");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("emailCatchAllEnabled", value);
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
    /// Enable or disable inbound email receiving for this sender.
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
    /// Turn the one-way SMS channel on or off. Enabling needs nothing else and takes
    /// effect immediately; disabling removes the channel from the sender. Confirm
    /// with the `channels` array on the response.
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
    /// Turn the voice channel on or off. The sender must already have a phone number
    /// provisioned for calls; enabling it otherwise returns 400 instead of storing
    /// a flag that changes nothing. Confirm with the `channels` array on the response.
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

    public string? Name
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("name", value);
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
    /// Whether the webhook is active.
    /// </summary>
    public bool? WebhookActive
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableStruct<bool>("webhookActive");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("webhookActive", value);
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
    public ApiEnum<string, SenderUpdateParamsWebhookSignatureVersion>? WebhookSignatureVersion
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<
                ApiEnum<string, SenderUpdateParamsWebhookSignatureVersion>
            >("webhookSignatureVersion");
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
    /// HTTPS URL for webhook events. Set to null to remove webhook.
    /// </summary>
    public string? WebhookUrl
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("webhookUrl");
        }
        init { this._rawBodyData.Set("webhookUrl", value); }
    }

    public SenderUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderUpdateParams(SenderUpdateParams senderUpdateParams)
        : base(senderUpdateParams)
    {
        this.SenderID = senderUpdateParams.SenderID;

        this._rawBodyData = new(senderUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public SenderUpdateParams(
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
    SenderUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string senderID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.SenderID = senderID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static SenderUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string senderID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            senderID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["SenderID"] = JsonSerializer.SerializeToElement(this.SenderID),
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

    public virtual bool Equals(SenderUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.SenderID?.Equals(other.SenderID) ?? other.SenderID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/senders/{0}", this.SenderID)
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
[JsonConverter(typeof(SenderUpdateParamsWebhookSignatureVersionConverter))]
public enum SenderUpdateParamsWebhookSignatureVersion
{
    V1,
    V1V2,
    V2,
}

sealed class SenderUpdateParamsWebhookSignatureVersionConverter
    : JsonConverter<SenderUpdateParamsWebhookSignatureVersion>
{
    public override SenderUpdateParamsWebhookSignatureVersion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "v1" => SenderUpdateParamsWebhookSignatureVersion.V1,
            "v1+v2" => SenderUpdateParamsWebhookSignatureVersion.V1V2,
            "v2" => SenderUpdateParamsWebhookSignatureVersion.V2,
            _ => (SenderUpdateParamsWebhookSignatureVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SenderUpdateParamsWebhookSignatureVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SenderUpdateParamsWebhookSignatureVersion.V1 => "v1",
                SenderUpdateParamsWebhookSignatureVersion.V1V2 => "v1+v2",
                SenderUpdateParamsWebhookSignatureVersion.V2 => "v2",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
