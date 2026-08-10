using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberPricing, PhoneNumberPricingFromRaw>))]
public sealed record class PhoneNumberPricing : JsonModel
{
    /// <summary>
    /// Whether this number qualifies as the plan-included US number on paid plans.
    /// The benefit is one per account: it is never offered again once claimed, not
    /// even after the number is released.
    /// </summary>
    public bool? IsFreeEligible
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("isFreeEligible");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("isFreeEligible", value);
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
    /// One-time purchase price in USD.
    /// </summary>
    public double? UpfrontPrice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<double>("upfrontPrice");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("upfrontPrice", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.IsFreeEligible;
        _ = this.MonthlyPrice;
        _ = this.UpfrontPrice;
    }

    public PhoneNumberPricing() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberPricing(PhoneNumberPricing phoneNumberPricing)
        : base(phoneNumberPricing) { }
#pragma warning restore CS8618

    public PhoneNumberPricing(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberPricing(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberPricingFromRaw.FromRawUnchecked"/>
    public static PhoneNumberPricing FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class PhoneNumberPricingFromRaw : IFromRawJson<PhoneNumberPricing>
{
    /// <inheritdoc/>
    public PhoneNumberPricing FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        PhoneNumberPricing.FromRawUnchecked(rawData);
}
