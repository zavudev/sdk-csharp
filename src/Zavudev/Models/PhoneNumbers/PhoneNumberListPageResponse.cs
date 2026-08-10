using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(
    typeof(JsonModelConverter<PhoneNumberListPageResponse, PhoneNumberListPageResponseFromRaw>)
)]
public sealed record class PhoneNumberListPageResponse : JsonModel
{
    public required IReadOnlyList<OwnedPhoneNumber> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<OwnedPhoneNumber>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<OwnedPhoneNumber>>(
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

    public PhoneNumberListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberListPageResponse(PhoneNumberListPageResponse phoneNumberListPageResponse)
        : base(phoneNumberListPageResponse) { }
#pragma warning restore CS8618

    public PhoneNumberListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberListPageResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PhoneNumberListPageResponse(IReadOnlyList<OwnedPhoneNumber> items)
        : this()
    {
        this.Items = items;
    }
}

class PhoneNumberListPageResponseFromRaw : IFromRawJson<PhoneNumberListPageResponse>
{
    /// <inheritdoc/>
    public PhoneNumberListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneNumberListPageResponse.FromRawUnchecked(rawData);
}
