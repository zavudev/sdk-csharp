using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Contacts;

/// <summary>
/// A communication channel for a contact.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ContactChannel, ContactChannelFromRaw>))]
public sealed record class ContactChannel : JsonModel
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
    /// Channel type.
    /// </summary>
    public required ApiEnum<string, ContactChannelChannel> Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ContactChannelChannel>>("channel");
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
    /// Channel identifier (phone number or email address).
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
    /// Whether this is the primary channel for its type.
    /// </summary>
    public required bool IsPrimary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("isPrimary");
        }
        init { this._rawData.Set("isPrimary", value); }
    }

    /// <summary>
    /// Whether this channel has been verified.
    /// </summary>
    public required bool Verified
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("verified");
        }
        init { this._rawData.Set("verified", value); }
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

    /// <summary>
    /// Last time a message was received on this channel.
    /// </summary>
    public DateTimeOffset? LastInboundAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastInboundAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastInboundAt", value);
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
    /// Delivery metrics for this channel.
    /// </summary>
    public Metrics? Metrics
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<Metrics>("metrics");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("metrics", value);
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
        _ = this.Identifier;
        _ = this.IsPrimary;
        _ = this.Verified;
        _ = this.CountryCode;
        _ = this.Label;
        _ = this.LastInboundAt;
        _ = this.Metadata;
        this.Metrics?.Validate();
        _ = this.UpdatedAt;
    }

    public ContactChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ContactChannel(ContactChannel contactChannel)
        : base(contactChannel) { }
#pragma warning restore CS8618

    public ContactChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ContactChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ContactChannelFromRaw.FromRawUnchecked"/>
    public static ContactChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ContactChannelFromRaw : IFromRawJson<ContactChannel>
{
    /// <inheritdoc/>
    public ContactChannel FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ContactChannel.FromRawUnchecked(rawData);
}

/// <summary>
/// Channel type.
/// </summary>
[JsonConverter(typeof(ContactChannelChannelConverter))]
public enum ContactChannelChannel
{
    Sms,
    Whatsapp,
    Email,
    Telegram,
    Instagram,
    Messenger,
    Voice,
}

sealed class ContactChannelChannelConverter : JsonConverter<ContactChannelChannel>
{
    public override ContactChannelChannel Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sms" => ContactChannelChannel.Sms,
            "whatsapp" => ContactChannelChannel.Whatsapp,
            "email" => ContactChannelChannel.Email,
            "telegram" => ContactChannelChannel.Telegram,
            "instagram" => ContactChannelChannel.Instagram,
            "messenger" => ContactChannelChannel.Messenger,
            "voice" => ContactChannelChannel.Voice,
            _ => (ContactChannelChannel)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ContactChannelChannel value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ContactChannelChannel.Sms => "sms",
                ContactChannelChannel.Whatsapp => "whatsapp",
                ContactChannelChannel.Email => "email",
                ContactChannelChannel.Telegram => "telegram",
                ContactChannelChannel.Instagram => "instagram",
                ContactChannelChannel.Messenger => "messenger",
                ContactChannelChannel.Voice => "voice",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Delivery metrics for this channel.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Metrics, MetricsFromRaw>))]
public sealed record class Metrics : JsonModel
{
    public double? AvgDeliveryTimeMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("avgDeliveryTimeMs");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("avgDeliveryTimeMs", value);
        }
    }

    public long? FailureCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("failureCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("failureCount", value);
        }
    }

    public DateTimeOffset? LastSuccessAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("lastSuccessAt");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("lastSuccessAt", value);
        }
    }

    public long? SuccessCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("successCount");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("successCount", value);
        }
    }

    public long? TotalAttempts
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("totalAttempts");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("totalAttempts", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AvgDeliveryTimeMs;
        _ = this.FailureCount;
        _ = this.LastSuccessAt;
        _ = this.SuccessCount;
        _ = this.TotalAttempts;
    }

    public Metrics() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Metrics(Metrics metrics)
        : base(metrics) { }
#pragma warning restore CS8618

    public Metrics(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metrics(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="MetricsFromRaw.FromRawUnchecked"/>
    public static Metrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class MetricsFromRaw : IFromRawJson<Metrics>
{
    /// <inheritdoc/>
    public Metrics FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Metrics.FromRawUnchecked(rawData);
}
