using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

[JsonConverter(
    typeof(JsonModelConverter<PhoneNumberAssignResponse, PhoneNumberAssignResponseFromRaw>)
)]
public sealed record class PhoneNumberAssignResponse : JsonModel
{
    public required TenDlcPhoneNumberAssignment Assignment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TenDlcPhoneNumberAssignment>("assignment");
        }
        init { this._rawData.Set("assignment", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Assignment.Validate();
    }

    public PhoneNumberAssignResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberAssignResponse(PhoneNumberAssignResponse phoneNumberAssignResponse)
        : base(phoneNumberAssignResponse) { }
#pragma warning restore CS8618

    public PhoneNumberAssignResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberAssignResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberAssignResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberAssignResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PhoneNumberAssignResponse(TenDlcPhoneNumberAssignment assignment)
        : this()
    {
        this.Assignment = assignment;
    }
}

class PhoneNumberAssignResponseFromRaw : IFromRawJson<PhoneNumberAssignResponse>
{
    /// <inheritdoc/>
    public PhoneNumberAssignResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneNumberAssignResponse.FromRawUnchecked(rawData);
}
