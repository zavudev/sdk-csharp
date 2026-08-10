using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<AvailablePhoneNumber, AvailablePhoneNumberFromRaw>))]
public sealed record class AvailablePhoneNumber : JsonModel
{
    public required PhoneNumberCapabilities Capabilities
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PhoneNumberCapabilities>("capabilities");
        }
        init { this._rawData.Set("capabilities", value); }
    }

    public required string PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phoneNumber");
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    public required PhoneNumberPricing Pricing
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<PhoneNumberPricing>("pricing");
        }
        init { this._rawData.Set("pricing", value); }
    }

    public string? FriendlyName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("friendlyName");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("friendlyName", value);
        }
    }

    public string? Locality
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("locality");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("locality", value);
        }
    }

    public string? Region
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("region");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("region", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Capabilities.Validate();
        _ = this.PhoneNumber;
        this.Pricing.Validate();
        _ = this.FriendlyName;
        _ = this.Locality;
        _ = this.Region;
    }

    public AvailablePhoneNumber() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AvailablePhoneNumber(AvailablePhoneNumber availablePhoneNumber)
        : base(availablePhoneNumber) { }
#pragma warning restore CS8618

    public AvailablePhoneNumber(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AvailablePhoneNumber(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AvailablePhoneNumberFromRaw.FromRawUnchecked"/>
    public static AvailablePhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class AvailablePhoneNumberFromRaw : IFromRawJson<AvailablePhoneNumber>
{
    /// <inheritdoc/>
    public AvailablePhoneNumber FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AvailablePhoneNumber.FromRawUnchecked(rawData);
}
