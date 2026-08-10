using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandUpdateResponse, BrandUpdateResponseFromRaw>))]
public sealed record class BrandUpdateResponse : JsonModel
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

    public BrandUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandUpdateResponse(BrandUpdateResponse brandUpdateResponse)
        : base(brandUpdateResponse) { }
#pragma warning restore CS8618

    public BrandUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandUpdateResponseFromRaw.FromRawUnchecked"/>
    public static BrandUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandUpdateResponse(TenDlcBrand brand)
        : this()
    {
        this.Brand = brand;
    }
}

class BrandUpdateResponseFromRaw : IFromRawJson<BrandUpdateResponse>
{
    /// <inheritdoc/>
    public BrandUpdateResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandUpdateResponse.FromRawUnchecked(rawData);
}
