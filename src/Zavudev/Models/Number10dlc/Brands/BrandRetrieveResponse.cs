using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandRetrieveResponse, BrandRetrieveResponseFromRaw>))]
public sealed record class BrandRetrieveResponse : JsonModel
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

    public BrandRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandRetrieveResponse(BrandRetrieveResponse brandRetrieveResponse)
        : base(brandRetrieveResponse) { }
#pragma warning restore CS8618

    public BrandRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static BrandRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandRetrieveResponse(TenDlcBrand brand)
        : this()
    {
        this.Brand = brand;
    }
}

class BrandRetrieveResponseFromRaw : IFromRawJson<BrandRetrieveResponse>
{
    /// <inheritdoc/>
    public BrandRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrandRetrieveResponse.FromRawUnchecked(rawData);
}
