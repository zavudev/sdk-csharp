using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Campaigns;

[JsonConverter(typeof(JsonModelConverter<CampaignUpdateResponse, CampaignUpdateResponseFromRaw>))]
public sealed record class CampaignUpdateResponse : JsonModel
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

    public CampaignUpdateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignUpdateResponse(CampaignUpdateResponse campaignUpdateResponse)
        : base(campaignUpdateResponse) { }
#pragma warning restore CS8618

    public CampaignUpdateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignUpdateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignUpdateResponseFromRaw.FromRawUnchecked"/>
    public static CampaignUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CampaignUpdateResponse(TenDlcCampaign campaign)
        : this()
    {
        this.Campaign = campaign;
    }
}

class CampaignUpdateResponseFromRaw : IFromRawJson<CampaignUpdateResponse>
{
    /// <inheritdoc/>
    public CampaignUpdateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignUpdateResponse.FromRawUnchecked(rawData);
}
