using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.SubAccounts;

[JsonConverter(typeof(JsonModelConverter<SubAccount, SubAccountFromRaw>))]
public sealed record class SubAccount : JsonModel
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required ApiEnum<string, SubAccountStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, SubAccountStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <summary>
    /// Total amount spent by this sub-account in cents.
    /// </summary>
    public required long TotalSpent
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("totalSpent");
        }
        init { this._rawData.Set("totalSpent", value); }
    }

    /// <summary>
    /// API key for the sub-account. Only returned on creation.
    /// </summary>
    public string? ApiKey
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("apiKey");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("apiKey", value);
        }
    }

    /// <summary>
    /// Spending cap in cents. When reached, messages from this sub-account will be blocked.
    /// </summary>
    public long? CreditLimit
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("creditLimit");
        }
        init { this._rawData.Set("creditLimit", value); }
    }

    /// <summary>
    /// External reference ID set by the parent account.
    /// </summary>
    public string? ExternalID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("externalId");
        }
        init { this._rawData.Set("externalId", value); }
    }

    public IReadOnlyDictionary<string, JsonElement>? Metadata
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>(
                "metadata"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "metadata",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.Name;
        this.Status.Validate();
        _ = this.TotalSpent;
        _ = this.ApiKey;
        _ = this.CreditLimit;
        _ = this.ExternalID;
        _ = this.Metadata;
    }

    public SubAccount() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SubAccount(SubAccount subAccount)
        : base(subAccount) { }
#pragma warning restore CS8618

    public SubAccount(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SubAccount(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SubAccountFromRaw.FromRawUnchecked"/>
    public static SubAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SubAccountFromRaw : IFromRawJson<SubAccount>
{
    /// <inheritdoc/>
    public SubAccount FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SubAccount.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(SubAccountStatusConverter))]
public enum SubAccountStatus
{
    Active,
    Inactive,
}

sealed class SubAccountStatusConverter : JsonConverter<SubAccountStatus>
{
    public override SubAccountStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "active" => SubAccountStatus.Active,
            "inactive" => SubAccountStatus.Inactive,
            _ => (SubAccountStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        SubAccountStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                SubAccountStatus.Active => "active",
                SubAccountStatus.Inactive => "inactive",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
