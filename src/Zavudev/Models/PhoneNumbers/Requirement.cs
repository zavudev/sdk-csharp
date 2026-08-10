using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

/// <summary>
/// A group of requirements for a specific country/phone type combination.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Requirement, RequirementFromRaw>))]
public sealed record class Requirement : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required string Action
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("action");
        }
        init { this._rawData.Set("action", value); }
    }

    public required string CountryCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("countryCode");
        }
        init { this._rawData.Set("countryCode", value); }
    }

    public required string PhoneNumberType
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("phoneNumberType");
        }
        init { this._rawData.Set("phoneNumberType", value); }
    }

    public required IReadOnlyList<RequirementType> RequirementTypes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RequirementType>>(
                "requirementTypes"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<RequirementType>>(
                "requirementTypes",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Action;
        _ = this.CountryCode;
        _ = this.PhoneNumberType;
        foreach (var item in this.RequirementTypes)
        {
            item.Validate();
        }
    }

    public Requirement() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Requirement(Requirement requirement)
        : base(requirement) { }
#pragma warning restore CS8618

    public Requirement(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Requirement(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequirementFromRaw.FromRawUnchecked"/>
    public static Requirement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequirementFromRaw : IFromRawJson<Requirement>
{
    /// <inheritdoc/>
    public Requirement FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Requirement.FromRawUnchecked(rawData);
}
