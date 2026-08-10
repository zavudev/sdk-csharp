using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Brands;

[JsonConverter(typeof(JsonModelConverter<BrandSyncStatusResponse, BrandSyncStatusResponseFromRaw>))]
public sealed record class BrandSyncStatusResponse : JsonModel
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

    public BrandSyncStatusResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BrandSyncStatusResponse(BrandSyncStatusResponse brandSyncStatusResponse)
        : base(brandSyncStatusResponse) { }
#pragma warning restore CS8618

    public BrandSyncStatusResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSyncStatusResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BrandSyncStatusResponseFromRaw.FromRawUnchecked"/>
    public static BrandSyncStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BrandSyncStatusResponse(TenDlcBrand brand)
        : this()
    {
        this.Brand = brand;
    }
}

class BrandSyncStatusResponseFromRaw : IFromRawJson<BrandSyncStatusResponse>
{
    /// <inheritdoc/>
    public BrandSyncStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BrandSyncStatusResponse.FromRawUnchecked(rawData);
}
