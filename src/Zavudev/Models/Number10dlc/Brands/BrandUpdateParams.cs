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
/// Update a 10DLC brand in draft status. Cannot update after submission.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class BrandUpdateParams : ParamsBase
{
    readonly JsonDictionary _rawBodyData = new();
    public IReadOnlyDictionary<string, JsonElement> RawBodyData
    {
        get { return this._rawBodyData.Freeze(); }
    }

    public string? BrandID { get; init; }

    public string? City
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("city");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("city", value);
        }
    }

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

    public string? Country
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("country");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("country", value);
        }
    }

    public string? DisplayName
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("displayName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("displayName", value);
        }
    }

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

    public string? Email
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("email", value);
        }
    }

    /// <summary>
    /// Business entity type for 10DLC brand registration.
    /// </summary>
    public ApiEnum<string, BrandUpdateParamsEntityType>? EntityType
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<ApiEnum<string, BrandUpdateParamsEntityType>>(
                "entityType"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("entityType", value);
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

    public string? Phone
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("phone");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("phone", value);
        }
    }

    public string? PostalCode
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("postalCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("postalCode", value);
        }
    }

    public string? State
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("state");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("state", value);
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

    public string? Street
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("street");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("street", value);
        }
    }

    public string? Vertical
    {
        get
        {
            this._rawBodyData.Freeze();
            return this._rawBodyData.GetNullableClass<string>("vertical");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawBodyData.Set("vertical", value);
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

    public BrandUpdateParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandUpdateParams(BrandUpdateParams brandUpdateParams)
        : base(brandUpdateParams)
    {
        this.BrandID = brandUpdateParams.BrandID;

        this._rawBodyData = new(brandUpdateParams._rawBodyData);
    }
#pragma warning restore CS8618

    public BrandUpdateParams(
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
    BrandUpdateParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        FrozenDictionary<string, JsonElement> rawBodyData,
        string brandID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this._rawBodyData = new(rawBodyData);
        this.BrandID = brandID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static BrandUpdateParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        IReadOnlyDictionary<string, JsonElement> rawBodyData,
        string brandID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            FrozenDictionary.ToFrozenDictionary(rawBodyData),
            brandID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["BrandID"] = JsonSerializer.SerializeToElement(this.BrandID),
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

    public virtual bool Equals(BrandUpdateParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return (this.BrandID?.Equals(other.BrandID) ?? other.BrandID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData)
            && this._rawBodyData.Equals(other._rawBodyData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format("/v1/10dlc/brands/{0}", this.BrandID)
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
/// Business entity type for 10DLC brand registration.
/// </summary>
[JsonConverter(typeof(BrandUpdateParamsEntityTypeConverter))]
public enum BrandUpdateParamsEntityType
{
    PrivateProfit,
    PublicProfit,
    NonProfit,
    Government,
    SoleProprietor,
}

sealed class BrandUpdateParamsEntityTypeConverter : JsonConverter<BrandUpdateParamsEntityType>
{
    public override BrandUpdateParamsEntityType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PRIVATE_PROFIT" => BrandUpdateParamsEntityType.PrivateProfit,
            "PUBLIC_PROFIT" => BrandUpdateParamsEntityType.PublicProfit,
            "NON_PROFIT" => BrandUpdateParamsEntityType.NonProfit,
            "GOVERNMENT" => BrandUpdateParamsEntityType.Government,
            "SOLE_PROPRIETOR" => BrandUpdateParamsEntityType.SoleProprietor,
            _ => (BrandUpdateParamsEntityType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BrandUpdateParamsEntityType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BrandUpdateParamsEntityType.PrivateProfit => "PRIVATE_PROFIT",
                BrandUpdateParamsEntityType.PublicProfit => "PUBLIC_PROFIT",
                BrandUpdateParamsEntityType.NonProfit => "NON_PROFIT",
                BrandUpdateParamsEntityType.Government => "GOVERNMENT",
                BrandUpdateParamsEntityType.SoleProprietor => "SOLE_PROPRIETOR",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
