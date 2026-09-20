using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

/// <summary>
/// Get the regulatory information needed to buy a phone number, for one specific
/// number or for a country and number type. Prefer `phoneNumber`: the response is
/// then exactly the list the purchase of that number validates against. Pass each
/// `requirementTypes[].id` back as `requirementType` in `regulatoryRequirements`
/// on `POST /v1/phone-numbers`.
///
/// <para>For `phoneNumber`, the requirements of that exact number are returned.
/// When they cannot be resolved for the number itself, the list for its country
/// and `type` is returned instead, and the purchase uses the same list. An empty
/// `items` array means the number needs no regulatory information. If the requirements
/// cannot be retrieved at all, the response is `502 requirements_unavailable`, never
/// an empty list.</para>
///
/// <para>URL-encode the `+` of `phoneNumber` as `%2B`. An unencoded `+` is also accepted.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberRequirementsParams : ParamsBase
{
    /// <summary>
    /// Two-letter ISO country code. Required unless `phoneNumber` is given.
    /// </summary>
    public string? CountryCode
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("countryCode");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("countryCode", value);
        }
    }

    /// <summary>
    /// E.164 number from `GET /v1/phone-numbers/available`, with `+` encoded as `%2B`.
    /// Returns the requirements the purchase of that number checks. Takes precedence
    /// over `countryCode`.
    /// </summary>
    public string? PhoneNumber
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<string>("phoneNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("phoneNumber", value);
        }
    }

    /// <summary>
    /// Type of phone number (local, national, mobile, tollFree). Defaults to `local`.
    /// With `phoneNumber`, used only when the number's own requirements cannot be
    /// resolved and the country list is returned.
    /// </summary>
    public ApiEnum<string, PhoneNumberType>? Type
    {
        get
        {
            this._rawQueryData.Freeze();
            return this._rawQueryData.GetNullableClass<ApiEnum<string, PhoneNumberType>>("type");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawQueryData.Set("type", value);
        }
    }

    public PhoneNumberRequirementsParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberRequirementsParams(
        PhoneNumberRequirementsParams phoneNumberRequirementsParams
    )
        : base(phoneNumberRequirementsParams) { }
#pragma warning restore CS8618

    public PhoneNumberRequirementsParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberRequirementsParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhoneNumberRequirementsParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData)
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
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PhoneNumberRequirementsParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/') + "/v1/phone-numbers/requirements"
        )
        {
            Query = this.QueryString(options),
        }.Uri;
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
