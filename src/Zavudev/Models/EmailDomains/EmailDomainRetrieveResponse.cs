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
    typeof(JsonModelConverter<EmailDomainRetrieveResponse, EmailDomainRetrieveResponseFromRaw>)
)]
public sealed record class EmailDomainRetrieveResponse : JsonModel
{
    public required EmailDomainRetrieveResponseDomain Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<EmailDomainRetrieveResponseDomain>("domain");
        }
        init { this._rawData.Set("domain", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Domain.Validate();
    }

    public EmailDomainRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainRetrieveResponse(EmailDomainRetrieveResponse emailDomainRetrieveResponse)
        : base(emailDomainRetrieveResponse) { }
#pragma warning restore CS8618

    public EmailDomainRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static EmailDomainRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EmailDomainRetrieveResponse(EmailDomainRetrieveResponseDomain domain)
        : this()
    {
        this.Domain = domain;
    }
}

class EmailDomainRetrieveResponseFromRaw : IFromRawJson<EmailDomainRetrieveResponse>
{
    /// <inheritdoc/>
    public EmailDomainRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmailDomainRetrieveResponse.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmailDomainRetrieveResponseDomain,
        EmailDomainRetrieveResponseDomainFromRaw
    >)
)]
public sealed record class EmailDomainRetrieveResponseDomain : JsonModel
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
    public IReadOnlyList<EmailDomainRetrieveResponseDomainDnsRecord>? DnsRecords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<
                ImmutableArray<EmailDomainRetrieveResponseDomainDnsRecord>
            >("dnsRecords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<EmailDomainRetrieveResponseDomainDnsRecord>?>(
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

    public EmailDomainRetrieveResponseDomain() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainRetrieveResponseDomain(
        EmailDomainRetrieveResponseDomain emailDomainRetrieveResponseDomain
    )
        : base(emailDomainRetrieveResponseDomain) { }
#pragma warning restore CS8618

    public EmailDomainRetrieveResponseDomain(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainRetrieveResponseDomain(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainRetrieveResponseDomainFromRaw.FromRawUnchecked"/>
    public static EmailDomainRetrieveResponseDomain FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailDomainRetrieveResponseDomainFromRaw : IFromRawJson<EmailDomainRetrieveResponseDomain>
{
    /// <inheritdoc/>
    public EmailDomainRetrieveResponseDomain FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmailDomainRetrieveResponseDomain.FromRawUnchecked(rawData);
}

[JsonConverter(
    typeof(JsonModelConverter<
        EmailDomainRetrieveResponseDomainDnsRecord,
        EmailDomainRetrieveResponseDomainDnsRecordFromRaw
    >)
)]
public sealed record class EmailDomainRetrieveResponseDomainDnsRecord : JsonModel
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
    public required ApiEnum<string, EmailDomainRetrieveResponseDomainDnsRecordPurpose> Purpose
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, EmailDomainRetrieveResponseDomainDnsRecordPurpose>
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

    public EmailDomainRetrieveResponseDomainDnsRecord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainRetrieveResponseDomainDnsRecord(
        EmailDomainRetrieveResponseDomainDnsRecord emailDomainRetrieveResponseDomainDnsRecord
    )
        : base(emailDomainRetrieveResponseDomainDnsRecord) { }
#pragma warning restore CS8618

    public EmailDomainRetrieveResponseDomainDnsRecord(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainRetrieveResponseDomainDnsRecord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainRetrieveResponseDomainDnsRecordFromRaw.FromRawUnchecked"/>
    public static EmailDomainRetrieveResponseDomainDnsRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class EmailDomainRetrieveResponseDomainDnsRecordFromRaw
    : IFromRawJson<EmailDomainRetrieveResponseDomainDnsRecord>
{
    /// <inheritdoc/>
    public EmailDomainRetrieveResponseDomainDnsRecord FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmailDomainRetrieveResponseDomainDnsRecord.FromRawUnchecked(rawData);
}

/// <summary>
/// What the record is for.
/// </summary>
[JsonConverter(typeof(EmailDomainRetrieveResponseDomainDnsRecordPurposeConverter))]
public enum EmailDomainRetrieveResponseDomainDnsRecordPurpose
{
    Dkim,
    Spf,
    Dmarc,
    MailFrom,
}

sealed class EmailDomainRetrieveResponseDomainDnsRecordPurposeConverter
    : JsonConverter<EmailDomainRetrieveResponseDomainDnsRecordPurpose>
{
    public override EmailDomainRetrieveResponseDomainDnsRecordPurpose Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dkim" => EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
            "spf" => EmailDomainRetrieveResponseDomainDnsRecordPurpose.Spf,
            "dmarc" => EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dmarc,
            "mail_from" => EmailDomainRetrieveResponseDomainDnsRecordPurpose.MailFrom,
            _ => (EmailDomainRetrieveResponseDomainDnsRecordPurpose)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EmailDomainRetrieveResponseDomainDnsRecordPurpose value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim => "dkim",
                EmailDomainRetrieveResponseDomainDnsRecordPurpose.Spf => "spf",
                EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dmarc => "dmarc",
                EmailDomainRetrieveResponseDomainDnsRecordPurpose.MailFrom => "mail_from",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
