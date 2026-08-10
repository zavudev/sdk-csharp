using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Senders;

/// <summary>
/// Webhook configuration for the sender.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SenderWebhook, SenderWebhookFromRaw>))]
public sealed record class SenderWebhook : JsonModel
{
    /// <summary>
    /// Whether the webhook is active.
    /// </summary>
    public required bool Active
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("active");
        }
        init { this._rawData.Set("active", value); }
    }

    /// <summary>
    /// List of events the webhook is subscribed to.
    /// </summary>
    public required IReadOnlyList<ApiEnum<string, WebhookEvent>> Events
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<ApiEnum<string, WebhookEvent>>>(
                "events"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<ApiEnum<string, WebhookEvent>>>(
                "events",
                ImmutableArray.ToImmutableArray(value)
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
    public required ApiEnum<string, SignatureVersion> SignatureVersion
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SignatureVersion>>(
                "signatureVersion"
            );
        }
        init { this._rawData.Set("signatureVersion", value); }
    }

    /// <summary>
    /// HTTPS URL that will receive webhook events.
    /// </summary>
    public required string Url
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("url");
        }
        init { this._rawData.Set("url", value); }
    }

    /// <summary>
    /// Webhook secret for signature verification. Only returned on create or regenerate.
    /// </summary>
    public string? Secret
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("secret");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("secret", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Active;
        foreach (var item in this.Events)
        {
            item.Validate();
        }
        this.SignatureVersion.Validate();
        _ = this.Url;
        _ = this.Secret;
    }

    public SenderWebhook() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SenderWebhook(SenderWebhook senderWebhook)
        : base(senderWebhook) { }
#pragma warning restore CS8618

    public SenderWebhook(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SenderWebhook(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SenderWebhookFromRaw.FromRawUnchecked"/>
    public static SenderWebhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SenderWebhookFromRaw : IFromRawJson<SenderWebhook>
{
    /// <inheritdoc/>
    public SenderWebhook FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SenderWebhook.FromRawUnchecked(rawData);
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
[JsonConverter(typeof(SignatureVersionConverter))]
public enum SignatureVersion
{
    V1,
    V1V2,
    V2,
}

sealed class SignatureVersionConverter : JsonConverter<SignatureVersion>
{
    public override SignatureVersion Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "v1" => SignatureVersion.V1,
            "v1+v2" => SignatureVersion.V1V2,
            "v2" => SignatureVersion.V2,
            _ => (SignatureVersion)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SignatureVersion value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SignatureVersion.V1 => "v1",
                SignatureVersion.V1V2 => "v1+v2",
                SignatureVersion.V2 => "v2",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
