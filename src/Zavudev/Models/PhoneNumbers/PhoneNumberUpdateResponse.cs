using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(
    typeof(JsonModelConverter<PhoneNumberUpdateResponse, PhoneNumberUpdateResponseFromRaw>)
)]
public sealed record class PhoneNumberUpdateResponse : JsonModel
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

    public PhoneNumberUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberUpdateResponse(PhoneNumberUpdateResponse phoneNumberUpdateResponse)
        : base(phoneNumberUpdateResponse) { }
#pragma warning restore CS8618

    public PhoneNumberUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberUpdateResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PhoneNumberUpdateResponse(OwnedPhoneNumber phoneNumber)
        : this()
    {
        this.PhoneNumber = phoneNumber;
    }
}

class PhoneNumberUpdateResponseFromRaw : IFromRawJson<PhoneNumberUpdateResponse>
{
    /// <inheritdoc/>
    public PhoneNumberUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneNumberUpdateResponse.FromRawUnchecked(rawData);
}
