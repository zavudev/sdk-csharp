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

[JsonConverter(typeof(JsonModelConverter<EmailDomainListResponse, EmailDomainListResponseFromRaw>))]
public sealed record class EmailDomainListResponse : JsonModel
{
    public required IReadOnlyList<Item> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Item>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Item>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public EmailDomainListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public EmailDomainListResponse(EmailDomainListResponse emailDomainListResponse)
        : base(emailDomainListResponse) { }
#pragma warning restore CS8618

    public EmailDomainListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    EmailDomainListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="EmailDomainListResponseFromRaw.FromRawUnchecked"/>
    public static EmailDomainListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public EmailDomainListResponse(IReadOnlyList<Item> items)
        : this()
    {
        this.Items = items;
    }
}

class EmailDomainListResponseFromRaw : IFromRawJson<EmailDomainListResponse>
{
    /// <inheritdoc/>
    public EmailDomainListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => EmailDomainListResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<Item, ItemFromRaw>))]
public sealed record class Item : JsonModel
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
    public IReadOnlyList<ItemDnsRecord>? DnsRecords
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<ItemDnsRecord>>("dnsRecords");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<ImmutableArray<ItemDnsRecord>?>(
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

    public Item() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Item(Item item)
        : base(item) { }
#pragma warning restore CS8618

    public Item(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Item(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemFromRaw.FromRawUnchecked"/>
    public static Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemFromRaw : IFromRawJson<Item>
{
    /// <inheritdoc/>
    public Item FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Item.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<ItemDnsRecord, ItemDnsRecordFromRaw>))]
public sealed record class ItemDnsRecord : JsonModel
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
    public required ApiEnum<string, ItemDnsRecordPurpose> Purpose
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, ItemDnsRecordPurpose>>("purpose");
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

    public ItemDnsRecord() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ItemDnsRecord(ItemDnsRecord itemDnsRecord)
        : base(itemDnsRecord) { }
#pragma warning restore CS8618

    public ItemDnsRecord(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ItemDnsRecord(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ItemDnsRecordFromRaw.FromRawUnchecked"/>
    public static ItemDnsRecord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ItemDnsRecordFromRaw : IFromRawJson<ItemDnsRecord>
{
    /// <inheritdoc/>
    public ItemDnsRecord FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ItemDnsRecord.FromRawUnchecked(rawData);
}

/// <summary>
/// What the record is for.
/// </summary>
[JsonConverter(typeof(ItemDnsRecordPurposeConverter))]
public enum ItemDnsRecordPurpose
{
    Dkim,
    Spf,
    Dmarc,
    MailFrom,
}

sealed class ItemDnsRecordPurposeConverter : JsonConverter<ItemDnsRecordPurpose>
{
    public override ItemDnsRecordPurpose Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "dkim" => ItemDnsRecordPurpose.Dkim,
            "spf" => ItemDnsRecordPurpose.Spf,
            "dmarc" => ItemDnsRecordPurpose.Dmarc,
            "mail_from" => ItemDnsRecordPurpose.MailFrom,
            _ => (ItemDnsRecordPurpose)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        ItemDnsRecordPurpose value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                ItemDnsRecordPurpose.Dkim => "dkim",
                ItemDnsRecordPurpose.Spf => "spf",
                ItemDnsRecordPurpose.Dmarc => "dmarc",
                ItemDnsRecordPurpose.MailFrom => "mail_from",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
