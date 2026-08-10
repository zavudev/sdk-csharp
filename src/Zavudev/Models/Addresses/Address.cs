using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Addresses;

/// <summary>
/// A regulatory address for phone number requirements.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Address, AddressFromRaw>))]
public sealed record class Address : JsonModel
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

    public required string CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("countryCode");
        }
        init { this._rawData.Set("countryCode", value); }
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

    public required string Locality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("locality");
        }
        init { this._rawData.Set("locality", value); }
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

    public required ApiEnum<string, AddressStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, AddressStatus>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    public required string StreetAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("streetAddress");
        }
        init { this._rawData.Set("streetAddress", value); }
    }

    public string? AdministrativeArea
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("administrativeArea");
        }
        init { this._rawData.Set("administrativeArea", value); }
    }

    public string? BusinessName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("businessName");
        }
        init { this._rawData.Set("businessName", value); }
    }

    public string? ExtendedAddress
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("extendedAddress");
        }
        init { this._rawData.Set("extendedAddress", value); }
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
        _ = this.CountryCode;
        _ = this.CreatedAt;
        _ = this.Locality;
        _ = this.PostalCode;
        this.Status.Validate();
        _ = this.StreetAddress;
        _ = this.AdministrativeArea;
        _ = this.BusinessName;
        _ = this.ExtendedAddress;
        _ = this.FirstName;
        _ = this.LastName;
        _ = this.UpdatedAt;
    }

    public Address() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Address(Address address)
        : base(address) { }
#pragma warning restore CS8618

    public Address(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Address(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AddressFromRaw.FromRawUnchecked"/>
    public static Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AddressFromRaw : IFromRawJson<Address>
{
    /// <inheritdoc/>
    public Address FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Address.FromRawUnchecked(rawData);
}
