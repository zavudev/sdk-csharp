using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Campaigns;

[JsonConverter(
    typeof(JsonModelConverter<CampaignListPageResponse, CampaignListPageResponseFromRaw>)
)]
public sealed record class CampaignListPageResponse : JsonModel
{
    public required IReadOnlyList<TenDlcCampaign> Items
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<TenDlcCampaign>>("items");
        }
        init
        {
            this._rawData.Set<ImmutableArray<TenDlcCampaign>>(
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

    public CampaignListPageResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignListPageResponse(CampaignListPageResponse campaignListPageResponse)
        : base(campaignListPageResponse) { }
#pragma warning restore CS8618

    public CampaignListPageResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignListPageResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignListPageResponseFromRaw.FromRawUnchecked"/>
    public static CampaignListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CampaignListPageResponse(IReadOnlyList<TenDlcCampaign> items)
        : this()
    {
        this.Items = items;
    }
}

class CampaignListPageResponseFromRaw : IFromRawJson<CampaignListPageResponse>
{
    /// <inheritdoc/>
    public CampaignListPageResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignListPageResponse.FromRawUnchecked(rawData);
}
