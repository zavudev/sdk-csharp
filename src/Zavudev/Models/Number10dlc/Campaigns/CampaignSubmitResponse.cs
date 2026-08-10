using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Campaigns;

[JsonConverter(typeof(JsonModelConverter<CampaignSubmitResponse, CampaignSubmitResponseFromRaw>))]
public sealed record class CampaignSubmitResponse : JsonModel
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

    public CampaignSubmitResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignSubmitResponse(CampaignSubmitResponse campaignSubmitResponse)
        : base(campaignSubmitResponse) { }
#pragma warning restore CS8618

    public CampaignSubmitResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignSubmitResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignSubmitResponseFromRaw.FromRawUnchecked"/>
    public static CampaignSubmitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CampaignSubmitResponse(TenDlcCampaign campaign)
        : this()
    {
        this.Campaign = campaign;
    }
}

class CampaignSubmitResponseFromRaw : IFromRawJson<CampaignSubmitResponse>
{
    /// <inheritdoc/>
    public CampaignSubmitResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignSubmitResponse.FromRawUnchecked(rawData);
}
