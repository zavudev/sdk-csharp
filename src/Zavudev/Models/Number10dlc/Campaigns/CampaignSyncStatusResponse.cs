using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Campaigns;

[JsonConverter(
    typeof(JsonModelConverter<CampaignSyncStatusResponse, CampaignSyncStatusResponseFromRaw>)
)]
public sealed record class CampaignSyncStatusResponse : JsonModel
{
    public required TenDlcCampaign Campaign
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<TenDlcCampaign>("campaign");
        }
        init { this._rawData.Set("campaign", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Campaign.Validate();
    }

    public CampaignSyncStatusResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignSyncStatusResponse(CampaignSyncStatusResponse campaignSyncStatusResponse)
        : base(campaignSyncStatusResponse) { }
#pragma warning restore CS8618

    public CampaignSyncStatusResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignSyncStatusResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignSyncStatusResponseFromRaw.FromRawUnchecked"/>
    public static CampaignSyncStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CampaignSyncStatusResponse(TenDlcCampaign campaign)
        : this()
    {
        this.Campaign = campaign;
    }
}

class CampaignSyncStatusResponseFromRaw : IFromRawJson<CampaignSyncStatusResponse>
{
    /// <inheritdoc/>
    public CampaignSyncStatusResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignSyncStatusResponse.FromRawUnchecked(rawData);
}
