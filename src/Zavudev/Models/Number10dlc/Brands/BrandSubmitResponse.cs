using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandSubmitResponse, BrandSubmitResponseFromRaw>))]
public sealed record class BrandSubmitResponse : JsonModel
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

    public BrandSubmitResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandSubmitResponse(BrandSubmitResponse brandSubmitResponse)
        : base(brandSubmitResponse) { }
#pragma warning restore CS8618

    public BrandSubmitResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSubmitResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandSubmitResponseFromRaw.FromRawUnchecked"/>
    public static BrandSubmitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandSubmitResponse(TenDlcBrand brand)
        : this()
    {
        this.Brand = brand;
    }
}

class BrandSubmitResponseFromRaw : IFromRawJson<BrandSubmitResponse>
{
    /// <inheritdoc/>
    public BrandSubmitResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSubmitResponse.FromRawUnchecked(rawData);
}
