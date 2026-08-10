using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.PhoneNumbers;

/// <summary>
/// A specific requirement type within a requirement group.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<RequirementType, RequirementTypeFromRaw>))]
public sealed record class RequirementType : JsonModel
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

    public required string Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("description");
        }
        init { this._rawData.Set("description", value); }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// Type of requirement field.
    /// </summary>
    public required ApiEnum<string, RequirementFieldType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, RequirementFieldType>>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Acceptance criteria for a requirement.
    /// </summary>
    public RequirementAcceptanceCriteria? AcceptanceCriteria
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<RequirementAcceptanceCriteria>(
                "acceptanceCriteria"
            );
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("acceptanceCriteria", value);
        }
    }

    public string? Example
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("example");
        }
        init { this._rawData.Set("example", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.Description;
        _ = this.Name;
        this.Type.Validate();
        this.AcceptanceCriteria?.Validate();
        _ = this.Example;
    }

    public RequirementType() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequirementType(RequirementType requirementType)
        : base(requirementType) { }
#pragma warning restore CS8618

    public RequirementType(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequirementType(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequirementTypeFromRaw.FromRawUnchecked"/>
    public static RequirementType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequirementTypeFromRaw : IFromRawJson<RequirementType>
{
    /// <inheritdoc/>
    public RequirementType FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RequirementType.FromRawUnchecked(rawData);
}
