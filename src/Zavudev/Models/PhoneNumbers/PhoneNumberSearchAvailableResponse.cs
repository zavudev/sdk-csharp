using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

[JsonConverter(
    typeof(JsonModelConverter<
        PhoneNumberSearchAvailableResponse,
        PhoneNumberSearchAvailableResponseFromRaw
    >)
)]
public sealed record class PhoneNumberSearchAvailableResponse : JsonModel
{
    public required IReadOnlyList<AvailablePhoneNumber> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<AvailablePhoneNumber>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<AvailablePhoneNumber>>(
                "items",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Items)
        {
            item.Validate();
        }
    }

    public PhoneNumberSearchAvailableResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberSearchAvailableResponse(
        PhoneNumberSearchAvailableResponse phoneNumberSearchAvailableResponse
    )
        : base(phoneNumberSearchAvailableResponse) { }
#pragma warning restore CS8618

    public PhoneNumberSearchAvailableResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberSearchAvailableResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberSearchAvailableResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberSearchAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PhoneNumberSearchAvailableResponse(IReadOnlyList<AvailablePhoneNumber> items)
        : this()
    {
        this.Items = items;
    }
}

class PhoneNumberSearchAvailableResponseFromRaw : IFromRawJson<PhoneNumberSearchAvailableResponse>
{
    /// <inheritdoc/>
    public PhoneNumberSearchAvailableResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneNumberSearchAvailableResponse.FromRawUnchecked(rawData);
}
