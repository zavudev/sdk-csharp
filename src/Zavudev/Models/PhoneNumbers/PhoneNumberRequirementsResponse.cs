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
        PhoneNumberRequirementsResponse,
        PhoneNumberRequirementsResponseFromRaw
    >)
)]
public sealed record class PhoneNumberRequirementsResponse : JsonModel
{
    public required IReadOnlyList<Requirement> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<Requirement>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<Requirement>>(
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

    public PhoneNumberRequirementsResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberRequirementsResponse(
        PhoneNumberRequirementsResponse phoneNumberRequirementsResponse
    )
        : base(phoneNumberRequirementsResponse) { }
#pragma warning restore CS8618

    public PhoneNumberRequirementsResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberRequirementsResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="PhoneNumberRequirementsResponseFromRaw.FromRawUnchecked"/>
    public static PhoneNumberRequirementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public PhoneNumberRequirementsResponse(IReadOnlyList<Requirement> items)
        : this()
    {
        this.Items = items;
    }
}

class PhoneNumberRequirementsResponseFromRaw : IFromRawJson<PhoneNumberRequirementsResponse>
{
    /// <inheritdoc/>
    public PhoneNumberRequirementsResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => PhoneNumberRequirementsResponse.FromRawUnchecked(rawData);
}
