using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.EmailDomains;

[JsonConverter(
    typeof(JsonModelConverter<EmailDomainVerifyResponse, EmailDomainVerifyResponseFromRaw>)
)]
public sealed record class EmailDomainVerifyResponse : JsonModel
{
    public required EmailDomainVerifyResponseDomain Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailDomainVerifyResponseDomain>("domain");
        }
        init { this._rawData.Set("domain", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Domain.Validate();
    }

    public EmailDomainVerifyResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainVerifyResponse(EmailDomainVerifyResponse emailDomainVerifyResponse)
        : base(emailDomainVerifyResponse) { }
#pragma warning restore CS8618

    public EmailDomainVerifyResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainVerifyResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainVerifyResponseFromRaw.FromRawUnchecked"/>
    public static EmailDomainVerifyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EmailDomainVerifyResponse(EmailDomainVerifyResponseDomain domain)
        : this()
    {
        this.Domain = domain;
    }
}

class EmailDomainVerifyResponseFromRaw : IFromRawJson<EmailDomainVerifyResponse>
{
    /// <inheritdoc/>
    public EmailDomainVerifyResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmailDomainVerifyResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmailDomainVerifyResponseDomain,
        EmailDomainVerifyResponseDomainFromRaw
    >)
)]
public sealed record class EmailDomainVerifyResponseDomain : JsonModel
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

    public required string DkimStatus
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("dkimStatus");
        }
        init { this._rawData.Set("dkimStatus", value); }
    }

    public required string Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("domain");
        }
        init { this._rawData.Set("domain", value); }
    }

    /// <summary>
    /// Overall verification status.
    /// </summary>
    public required string Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// DNS records to publish. Present when fetching a single domain or after adding one.
    /// </summary>
    public IReadOnlyList<EmailDomainVerifyResponseDomainDnsRecord>? DnsRecords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<EmailDomainVerifyResponseDomainDnsRecord>
            >("dnsRecords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<EmailDomainVerifyResponseDomainDnsRecord>?>(
                "dnsRecords",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.DkimStatus;
        _ = this.Domain;
        _ = this.Status;
        foreach (var item in this.DnsRecords ?? [])
        {
            item.Validate();
        }
    }

    public EmailDomainVerifyResponseDomain() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainVerifyResponseDomain(
        EmailDomainVerifyResponseDomain emailDomainVerifyResponseDomain
    )
        : base(emailDomainVerifyResponseDomain) { }
#pragma warning restore CS8618

    public EmailDomainVerifyResponseDomain(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainVerifyResponseDomain(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainVerifyResponseDomainFromRaw.FromRawUnchecked"/>
    public static EmailDomainVerifyResponseDomain FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailDomainVerifyResponseDomainFromRaw : IFromRawJson<EmailDomainVerifyResponseDomain>
{
    /// <inheritdoc/>
    public EmailDomainVerifyResponseDomain FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmailDomainVerifyResponseDomain.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmailDomainVerifyResponseDomainDnsRecord,
        EmailDomainVerifyResponseDomainDnsRecordFromRaw
    >)
)]
public sealed record class EmailDomainVerifyResponseDomainDnsRecord : JsonModel
{
    /// <summary>
    /// Record host/name to create.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// What the record is for.
    /// </summary>
    public required ApiEnum<string, EmailDomainVerifyResponseDomainDnsRecordPurpose> Purpose
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EmailDomainVerifyResponseDomainDnsRecordPurpose>
            >("purpose");
        }
        init { this._rawData.Set("purpose", value); }
    }

    /// <summary>
    /// Whether the record is required to verify + send (DKIM) or recommended for deliverability.
    /// </summary>
    public required bool Required
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("required");
        }
        init { this._rawData.Set("required", value); }
    }

    /// <summary>
    /// DNS record type.
    /// </summary>
    public required string Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Record value.
    /// </summary>
    public required string Value
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("value");
        }
        init { this._rawData.Set("value", value); }
    }

    /// <summary>
    /// Priority (MX records only).
    /// </summary>
    public long? Priority
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("priority");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("priority", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Name;
        this.Purpose.Validate();
        _ = this.Required;
        _ = this.Type;
        _ = this.Value;
        _ = this.Priority;
    }

    public EmailDomainVerifyResponseDomainDnsRecord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainVerifyResponseDomainDnsRecord(
        EmailDomainVerifyResponseDomainDnsRecord emailDomainVerifyResponseDomainDnsRecord
    )
        : base(emailDomainVerifyResponseDomainDnsRecord) { }
#pragma warning restore CS8618

    public EmailDomainVerifyResponseDomainDnsRecord(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainVerifyResponseDomainDnsRecord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainVerifyResponseDomainDnsRecordFromRaw.FromRawUnchecked"/>
    public static EmailDomainVerifyResponseDomainDnsRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailDomainVerifyResponseDomainDnsRecordFromRaw
    : IFromRawJson<EmailDomainVerifyResponseDomainDnsRecord>
{
    /// <inheritdoc/>
    public EmailDomainVerifyResponseDomainDnsRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmailDomainVerifyResponseDomainDnsRecord.FromRawUnchecked(rawData);
}

/// <summary>
/// What the record is for.
/// </summary>
[JsonConverter(typeof(EmailDomainVerifyResponseDomainDnsRecordPurposeConverter))]
public enum EmailDomainVerifyResponseDomainDnsRecordPurpose
{
    Dkim,
    Spf,
    Dmarc,
    MailFrom,
}

sealed class EmailDomainVerifyResponseDomainDnsRecordPurposeConverter
    : JsonConverter<EmailDomainVerifyResponseDomainDnsRecordPurpose>
{
    public override EmailDomainVerifyResponseDomainDnsRecordPurpose Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dkim" => EmailDomainVerifyResponseDomainDnsRecordPurpose.Dkim,
            "spf" => EmailDomainVerifyResponseDomainDnsRecordPurpose.Spf,
            "dmarc" => EmailDomainVerifyResponseDomainDnsRecordPurpose.Dmarc,
            "mail_from" => EmailDomainVerifyResponseDomainDnsRecordPurpose.MailFrom,
            _ => (EmailDomainVerifyResponseDomainDnsRecordPurpose)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailDomainVerifyResponseDomainDnsRecordPurpose value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EmailDomainVerifyResponseDomainDnsRecordPurpose.Dkim => "dkim",
                EmailDomainVerifyResponseDomainDnsRecordPurpose.Spf => "spf",
                EmailDomainVerifyResponseDomainDnsRecordPurpose.Dmarc => "dmarc",
                EmailDomainVerifyResponseDomainDnsRecordPurpose.MailFrom => "mail_from",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
