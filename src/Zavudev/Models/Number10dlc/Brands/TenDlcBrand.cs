using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Number10dlc.Brands;

[JsonConverter(typeof(JsonModelConverter<TenDlcBrand, TenDlcBrandFromRaw>))]
public sealed record class TenDlcBrand : JsonModel
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

    public required string City
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("city");
        }
        init { this._rawData.Set("city", value); }
    }

    /// <summary>
    /// Two-letter ISO country code.
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("country");
        }
        init { this._rawData.Set("country", value); }
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
    /// Display name of the brand.
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("displayName");
        }
        init { this._rawData.Set("displayName", value); }
    }

    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
    }

    /// <summary>
    /// Business entity type for 10DLC brand registration.
    /// </summary>
    public required ApiEnum<string, TenDlcBrandEntityType> EntityType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, TenDlcBrandEntityType>>(
                "entityType"
            );
        }
        init { this._rawData.Set("entityType", value); }
    }

    /// <summary>
    /// Contact phone number in E.164 format.
    /// </summary>
    public required string Phone
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phone");
        }
        init { this._rawData.Set("phone", value); }
    }

    public required string PostalCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("postalCode");
        }
        init { this._rawData.Set("postalCode", value); }
    }

    public required string State
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("state");
        }
        init { this._rawData.Set("state", value); }
    }

    /// <summary>
    /// Status of a 10DLC brand registration.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string Street
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("street");
        }
        init { this._rawData.Set("street", value); }
    }

    public required DateTimeOffset UpdatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("updatedAt");
        }
        init { this._rawData.Set("updatedAt", value); }
    }

    /// <summary>
    /// Industry vertical.
    /// </summary>
    public required string Vertical
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("vertical");
        }
        init { this._rawData.Set("vertical", value); }
    }

    public string? BrandRelationship
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("brandRelationship");
        }
        init { this._rawData.Set("brandRelationship", value); }
    }

    /// <summary>
    /// Trust score assigned by TCR after vetting.
    /// </summary>
    public long? BrandScore
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("brandScore");
        }
        init { this._rawData.Set("brandScore", value); }
    }

    /// <summary>
    /// Legal company name.
    /// </summary>
    public string? CompanyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("companyName");
        }
        init { this._rawData.Set("companyName", value); }
    }

    /// <summary>
    /// Employer Identification Number (EIN).
    /// </summary>
    public string? Ein
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ein");
        }
        init { this._rawData.Set("ein", value); }
    }

    /// <summary>
    /// Reason for rejection, if applicable.
    /// </summary>
    public string? FailureReason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("failureReason");
        }
        init { this._rawData.Set("failureReason", value); }
    }

    public string? FirstName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("firstName");
        }
        init { this._rawData.Set("firstName", value); }
    }

    public string? LastName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("lastName");
        }
        init { this._rawData.Set("lastName", value); }
    }

    public string? StockExchange
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stockExchange");
        }
        init { this._rawData.Set("stockExchange", value); }
    }

    public string? StockSymbol
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("stockSymbol");
        }
        init { this._rawData.Set("stockSymbol", value); }
    }

    public DateTimeOffset? SubmittedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("submittedAt");
        }
        init { this._rawData.Set("submittedAt", value); }
    }

    public DateTimeOffset? VerifiedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("verifiedAt");
        }
        init { this._rawData.Set("verifiedAt", value); }
    }

    public string? Website
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("website");
        }
        init { this._rawData.Set("website", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.City;
        _ = this.Country;
        _ = this.CreatedAt;
        _ = this.DisplayName;
        _ = this.Email;
        this.EntityType.Validate();
        _ = this.Phone;
        _ = this.PostalCode;
        _ = this.State;
        this.Status.Validate();
        _ = this.Street;
        _ = this.UpdatedAt;
        _ = this.Vertical;
        _ = this.BrandRelationship;
        _ = this.BrandScore;
        _ = this.CompanyName;
        _ = this.Ein;
        _ = this.FailureReason;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.StockExchange;
        _ = this.StockSymbol;
        _ = this.SubmittedAt;
        _ = this.VerifiedAt;
        _ = this.Website;
    }

    public TenDlcBrand() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TenDlcBrand(TenDlcBrand tenDlcBrand)
        : base(tenDlcBrand) { }
#pragma warning restore CS8618

    public TenDlcBrand(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TenDlcBrand(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TenDlcBrandFromRaw.FromRawUnchecked"/>
    public static TenDlcBrand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TenDlcBrandFromRaw : IFromRawJson<TenDlcBrand>
{
    /// <inheritdoc/>
    public TenDlcBrand FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        TenDlcBrand.FromRawUnchecked(rawData);
}

/// <summary>
/// Business entity type for 10DLC brand registration.
/// </summary>
[JsonConverter(typeof(TenDlcBrandEntityTypeConverter))]
public enum TenDlcBrandEntityType
{
    PrivateProfit,
    PublicProfit,
    NonProfit,
    Government,
    SoleProprietor,
}

sealed class TenDlcBrandEntityTypeConverter : JsonConverter<TenDlcBrandEntityType>
{
    public override TenDlcBrandEntityType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PRIVATE_PROFIT" => TenDlcBrandEntityType.PrivateProfit,
            "PUBLIC_PROFIT" => TenDlcBrandEntityType.PublicProfit,
            "NON_PROFIT" => TenDlcBrandEntityType.NonProfit,
            "GOVERNMENT" => TenDlcBrandEntityType.Government,
            "SOLE_PROPRIETOR" => TenDlcBrandEntityType.SoleProprietor,
            _ => (TenDlcBrandEntityType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        TenDlcBrandEntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                TenDlcBrandEntityType.PrivateProfit => "PRIVATE_PROFIT",
                TenDlcBrandEntityType.PublicProfit => "PUBLIC_PROFIT",
                TenDlcBrandEntityType.NonProfit => "NON_PROFIT",
                TenDlcBrandEntityType.Government => "GOVERNMENT",
                TenDlcBrandEntityType.SoleProprietor => "SOLE_PROPRIETOR",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// Status of a 10DLC brand registration.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Draft,
    Pending,
    Verified,
    Rejected,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "draft" => Status.Draft,
            "pending" => Status.Pending,
            "verified" => Status.Verified,
            "rejected" => Status.Rejected,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Draft => "draft",
                Status.Pending => "pending",
                Status.Verified => "verified",
                Status.Rejected => "rejected",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
