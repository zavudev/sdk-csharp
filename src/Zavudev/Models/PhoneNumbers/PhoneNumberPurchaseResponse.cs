using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(
    typeof(JsonModelConverter<PhoneNumberPurchaseResponse, PhoneNumberPurchaseResponseFromRaw>)
)]
public sealed record class PhoneNumberPurchaseResponse : JsonModel
{
    public required OwnedPhoneNumber PhoneNumber
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<OwnedPhoneNumber>("phoneNumber");
        }
        init { this._rawData.Set("phoneNumber", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.PhoneNumber.Validate();
    }

    public PhoneNumberPurchaseResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberPurchaseResponse(PhoneNumberPurchaseResponse phoneNumberPurchaseResponse)
        : base(phoneNumberPurchaseResponse) { }
#pragma warning restore CS8618

    public PhoneNumberPurchaseResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberPurchaseResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberPurchaseResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberPurchaseResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PhoneNumberPurchaseResponse(OwnedPhoneNumber phoneNumber)
        : this()
    {
        this.PhoneNumber = phoneNumber;
    }
}

class PhoneNumberPurchaseResponseFromRaw : IFromRawJson<PhoneNumberPurchaseResponse>
{
    /// <inheritdoc/>
    public PhoneNumberPurchaseResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneNumberPurchaseResponse.FromRawUnchecked(rawData);
}
