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
    typeof(JsonModelConverter<EmailDomainCreateResponse, EmailDomainCreateResponseFromRaw>)
)]
public sealed record class EmailDomainCreateResponse : JsonModel
{
    public required Domain Domain
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Domain>("domain");
        }
        init { this._rawData.Set("domain", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Domain.Validate();
    }

    public EmailDomainCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainCreateResponse(EmailDomainCreateResponse emailDomainCreateResponse)
        : base(emailDomainCreateResponse) { }
#pragma warning restore CS8618

    public EmailDomainCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainCreateResponseFromRaw.FromRawUnchecked"/>
    public static EmailDomainCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EmailDomainCreateResponse(Domain domain)
        : this()
    {
        this.Domain = domain;
    }
}

class EmailDomainCreateResponseFromRaw : IFromRawJson<EmailDomainCreateResponse>
{
    /// <inheritdoc/>
    public EmailDomainCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmailDomainCreateResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Domain, DomainFromRaw>))]
public sealed record class Domain : JsonModel
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

    public required string DomainValue
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
    public IReadOnlyList<DnsRecord>? DnsRecords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<DnsRecord>>("dnsRecords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<DnsRecord>?>(
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
        _ = this.DomainValue;
        _ = this.Status;
        foreach (var item in this.DnsRecords ?? [])
        {
            item.Validate();
        }
    }

    public Domain() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Domain(Domain domain)
        : base(domain) { }
#pragma warning restore CS8618

    public Domain(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Domain(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DomainFromRaw.FromRawUnchecked"/>
    public static Domain FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DomainFromRaw : IFromRawJson<Domain>
{
    /// <inheritdoc/>
    public Domain FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Domain.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<DnsRecord, DnsRecordFromRaw>))]
public sealed record class DnsRecord : JsonModel
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
    public required ApiEnum<string, Purpose> Purpose
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Purpose>>("purpose");
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

    public DnsRecord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public DnsRecord(DnsRecord dnsRecord)
        : base(dnsRecord) { }
#pragma warning restore CS8618

    public DnsRecord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DnsRecord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="DnsRecordFromRaw.FromRawUnchecked"/>
    public static DnsRecord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class DnsRecordFromRaw : IFromRawJson<DnsRecord>
{
    /// <inheritdoc/>
    public DnsRecord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        DnsRecord.FromRawUnchecked(rawData);
}

/// <summary>
/// What the record is for.
/// </summary>
[JsonConverter(typeof(PurposeConverter))]
public enum Purpose
{
    Dkim,
    Spf,
    Dmarc,
    MailFrom,
}

sealed class PurposeConverter : JsonConverter<Purpose>
{
    public override Purpose Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dkim" => Purpose.Dkim,
            "spf" => Purpose.Spf,
            "dmarc" => Purpose.Dmarc,
            "mail_from" => Purpose.MailFrom,
            _ => (Purpose)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Purpose value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Purpose.Dkim => "dkim",
                Purpose.Spf => "spf",
                Purpose.Dmarc => "dmarc",
                Purpose.MailFrom => "mail_from",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
