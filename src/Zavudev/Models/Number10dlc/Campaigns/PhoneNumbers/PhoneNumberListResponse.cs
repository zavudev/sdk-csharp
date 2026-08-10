using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

[JsonConverter(typeof(JsonModelConverter<PhoneNumberListResponse, PhoneNumberListResponseFromRaw>))]
public sealed record class PhoneNumberListResponse : JsonModel
{
    public required IReadOnlyList<TenDlcPhoneNumberAssignment> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TenDlcPhoneNumberAssignment>>(
                "items"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<TenDlcPhoneNumberAssignment>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public string? NextCursor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("nextCursor");
        }
        init { this._rawData.Set("nextCursor", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
        _ = this.NextCursor;
    }

    public PhoneNumberListResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberListResponse(PhoneNumberListResponse phoneNumberListResponse)
        : base(phoneNumberListResponse) { }
#pragma warning restore CS8618

    public PhoneNumberListResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberListResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberListResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PhoneNumberListResponse(IReadOnlyList<TenDlcPhoneNumberAssignment> items)
        : this()
    {
        this.Items = items;
    }
}

class PhoneNumberListResponseFromRaw : IFromRawJson<PhoneNumberListResponse>
{
    /// <inheritdoc/>
    public PhoneNumberListResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneNumberListResponse.FromRawUnchecked(rawData);
}
