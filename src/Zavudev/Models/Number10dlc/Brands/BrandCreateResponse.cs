using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandCreateResponse, BrandCreateResponseFromRaw>))]
public sealed record class BrandCreateResponse : JsonModel
{
    public required TenDlcBrand Brand
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TenDlcBrand>("brand");
        }
        init { this._rawData.Set("brand", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Brand.Validate();
    }

    public BrandCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandCreateResponse(BrandCreateResponse brandCreateResponse)
        : base(brandCreateResponse) { }
#pragma warning restore CS8618

    public BrandCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandCreateResponseFromRaw.FromRawUnchecked"/>
    public static BrandCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandCreateResponse(TenDlcBrand brand)
        : this()
    {
        this.Brand = brand;
    }
}

class BrandCreateResponseFromRaw : IFromRawJson<BrandCreateResponse>
{
    /// <inheritdoc/>
    public BrandCreateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandCreateResponse.FromRawUnchecked(rawData);
}
