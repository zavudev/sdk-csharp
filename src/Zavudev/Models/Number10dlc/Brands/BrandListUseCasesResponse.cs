using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Brands;

[JsonConverter(
    typeof(JsonModelConverter<BrandListUseCasesResponse, BrandListUseCasesResponseFromRaw>)
)]
public sealed record class BrandListUseCasesResponse : JsonModel
{
    public required IReadOnlyList<UseCase> UseCases
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<UseCase>>("useCases");
        }
        init
        {
            this._rawData.Set<ImmutableArray<UseCase>>(
                "useCases",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.UseCases)
        {
            item.Validate();
        }
    }

    public BrandListUseCasesResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandListUseCasesResponse(BrandListUseCasesResponse brandListUseCasesResponse)
        : base(brandListUseCasesResponse) { }
#pragma warning restore CS8618

    public BrandListUseCasesResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandListUseCasesResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandListUseCasesResponseFromRaw.FromRawUnchecked"/>
    public static BrandListUseCasesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandListUseCasesResponse(IReadOnlyList<UseCase> useCases)
        : this()
    {
        this.UseCases = useCases;
    }
}

class BrandListUseCasesResponseFromRaw : IFromRawJson<BrandListUseCasesResponse>
{
    /// <inheritdoc/>
    public BrandListUseCasesResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrandListUseCasesResponse.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<UseCase, UseCaseFromRaw>))]
public sealed record class UseCase : JsonModel
{
    public string? Description
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("description");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("description", value);
        }
    }

    public string? Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("name", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Description;
        _ = this.Name;
    }

    public UseCase() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UseCase(UseCase useCase)
        : base(useCase) { }
#pragma warning restore CS8618

    public UseCase(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UseCase(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UseCaseFromRaw.FromRawUnchecked"/>
    public static UseCase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UseCaseFromRaw : IFromRawJson<UseCase>
{
    /// <inheritdoc/>
    public UseCase FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        UseCase.FromRawUnchecked(rawData);
}
