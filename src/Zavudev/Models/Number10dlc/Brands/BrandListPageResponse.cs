using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandListPageResponse, BrandListPageResponseFromRaw>))]
public sealed record class BrandListPageResponse : JsonModel
{
    public required IReadOnlyList<TenDlcBrand> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TenDlcBrand>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TenDlcBrand>>(
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

    public BrandListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandListPageResponse(BrandListPageResponse brandListPageResponse)
        : base(brandListPageResponse) { }
#pragma warning restore CS8618

    public BrandListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandListPageResponseFromRaw.FromRawUnchecked"/>
    public static BrandListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandListPageResponse(IReadOnlyList<TenDlcBrand> items)
        : this()
    {
        this.Items = items;
    }
}

class BrandListPageResponseFromRaw : IFromRawJson<BrandListPageResponse>
{
    /// <inheritdoc/>
    public BrandListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrandListPageResponse.FromRawUnchecked(rawData);
}
