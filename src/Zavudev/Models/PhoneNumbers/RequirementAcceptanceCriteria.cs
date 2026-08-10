using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

/// <summary>
/// Acceptance criteria for a requirement.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<RequirementAcceptanceCriteria, RequirementAcceptanceCriteriaFromRaw>)
)]
public sealed record class RequirementAcceptanceCriteria : JsonModel
{
    public IReadOnlyList<string>? AllowedValues
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("allowedValues");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "allowedValues",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public long? MaxLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("maxLength");
        }
        init { this._rawData.Set("maxLength", value); }
    }

    public long? MinLength
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("minLength");
        }
        init { this._rawData.Set("minLength", value); }
    }

    public string? RegexPattern
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("regexPattern");
        }
        init { this._rawData.Set("regexPattern", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedValues;
        _ = this.MaxLength;
        _ = this.MinLength;
        _ = this.RegexPattern;
    }

    public RequirementAcceptanceCriteria() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequirementAcceptanceCriteria(
        RequirementAcceptanceCriteria requirementAcceptanceCriteria
    )
        : base(requirementAcceptanceCriteria) { }
#pragma warning restore CS8618

    public RequirementAcceptanceCriteria(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequirementAcceptanceCriteria(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequirementAcceptanceCriteriaFromRaw.FromRawUnchecked"/>
    public static RequirementAcceptanceCriteria FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequirementAcceptanceCriteriaFromRaw : IFromRawJson<RequirementAcceptanceCriteria>
{
    /// <inheritdoc/>
    public RequirementAcceptanceCriteria FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => RequirementAcceptanceCriteria.FromRawUnchecked(rawData);
}
