using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<OwnedPhoneNumberPricing, OwnedPhoneNumberPricingFromRaw>))]
public sealed record class OwnedPhoneNumberPricing : JsonModel
{
    /// <summary>
    /// Whether this is a free number.
    /// </summary>
    public bool? IsFreeNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isFreeNumber");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isFreeNumber", value);
        }
    }

    /// <summary>
    /// Monthly cost in cents.
    /// </summary>
    public double? MonthlyCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("monthlyCost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("monthlyCost", value);
        }
    }

    /// <summary>
    /// Monthly price in USD.
    /// </summary>
    public double? MonthlyPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("monthlyPrice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("monthlyPrice", value);
        }
    }

    /// <summary>
    /// One-time purchase cost in cents.
    /// </summary>
    public double? UpfrontCost
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("upfrontCost");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("upfrontCost", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsFreeNumber;
        _ = this.MonthlyCost;
        _ = this.MonthlyPrice;
        _ = this.UpfrontCost;
    }

    public OwnedPhoneNumberPricing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public OwnedPhoneNumberPricing(OwnedPhoneNumberPricing ownedPhoneNumberPricing)
        : base(ownedPhoneNumberPricing) { }
#pragma warning restore CS8618

    public OwnedPhoneNumberPricing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    OwnedPhoneNumberPricing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="OwnedPhoneNumberPricingFromRaw.FromRawUnchecked"/>
    public static OwnedPhoneNumberPricing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class OwnedPhoneNumberPricingFromRaw : IFromRawJson<OwnedPhoneNumberPricing>
{
    /// <inheritdoc/>
    public OwnedPhoneNumberPricing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => OwnedPhoneNumberPricing.FromRawUnchecked(rawData);
}
