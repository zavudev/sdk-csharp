using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.Number10dlc.Brands;

/// <summary>
/// Create a 10DLC brand registration. The brand starts in draft status. Submit it
/// for review using the submit endpoint.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BrandCreateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public required string City
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("city");
        }
        init { this._rawBodyData.Set("city", value); }
    }

    /// <summary>
    /// Two-letter ISO country code.
    /// </summary>
    public required string Country
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("country");
        }
        init { this._rawBodyData.Set("country", value); }
    }

    /// <summary>
    /// Display name of the brand.
    /// </summary>
    public required string DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("displayName");
        }
        init { this._rawBodyData.Set("displayName", value); }
    }

    public required string Email
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("email");
        }
        init { this._rawBodyData.Set("email", value); }
    }

    /// <summary>
    /// Business entity type for 10DLC brand registration.
    /// </summary>
    public required ApiEnum<string, EntityType> EntityType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<ApiEnum<string, EntityType>>("entityType");
        }
        init { this._rawBodyData.Set("entityType", value); }
    }

    /// <summary>
    /// Contact phone in E.164 format.
    /// </summary>
    public required string Phone
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("phone");
        }
        init { this._rawBodyData.Set("phone", value); }
    }

    public required string PostalCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("postalCode");
        }
        init { this._rawBodyData.Set("postalCode", value); }
    }

    public required string State
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("state");
        }
        init { this._rawBodyData.Set("state", value); }
    }

    public required string Street
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("street");
        }
        init { this._rawBodyData.Set("street", value); }
    }

    /// <summary>
    /// Industry vertical.
    /// </summary>
    public required string Vertical
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNotNullClass<string>("vertical");
        }
        init { this._rawBodyData.Set("vertical", value); }
    }

    /// <summary>
    /// Legal company name.
    /// </summary>
    public string? CompanyName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("companyName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("companyName", value);
        }
    }

    /// <summary>
    /// Employer Identification Number (format: XX-XXXXXXX).
    /// </summary>
    public string? Ein
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("ein");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("ein", value);
        }
    }

    public string? FirstName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("firstName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("firstName", value);
        }
    }

    public string? LastName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("lastName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("lastName", value);
        }
    }

    public string? StockExchange
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("stockExchange");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("stockExchange", value);
        }
    }

    public string? StockSymbol
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("stockSymbol");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("stockSymbol", value);
        }
    }

    public string? Website
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("website");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("website", value);
        }
    }

    public BrandCreateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandCreateParams(BrandCreateParams brandCreateParams)
        : base(brandCreateParams)
    {
        this._rawBodyData = new(brandCreateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BrandCreateParams(
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
    BrandCreateParams(
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
    public static BrandCreateParams FromRawUnchecked(
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

    public virtual bool Equals(BrandCreateParams? other)
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
        return new UriBuilder(options.BaseUrl.ToString().TrimEnd('/') + "/v1/10dlc/brands")
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
/// Business entity type for 10DLC brand registration.
/// </summary>
[JsonConverter(typeof(EntityTypeConverter))]
public enum EntityType
{
    PrivateProfit,
    PublicProfit,
    NonProfit,
    Government,
    SoleProprietor,
}

sealed class EntityTypeConverter : JsonConverter<EntityType>
{
    public override EntityType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PRIVATE_PROFIT" => EntityType.PrivateProfit,
            "PUBLIC_PROFIT" => EntityType.PublicProfit,
            "NON_PROFIT" => EntityType.NonProfit,
            "GOVERNMENT" => EntityType.Government,
            "SOLE_PROPRIETOR" => EntityType.SoleProprietor,
            _ => (EntityType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        EntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                EntityType.PrivateProfit => "PRIVATE_PROFIT",
                EntityType.PublicProfit => "PUBLIC_PROFIT",
                EntityType.NonProfit => "NON_PROFIT",
                EntityType.Government => "GOVERNMENT",
                EntityType.SoleProprietor => "SOLE_PROPRIETOR",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
