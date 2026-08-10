using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Campaigns;

[JsonConverter(typeof(JsonModelConverter<CampaignCreateResponse, CampaignCreateResponseFromRaw>))]
public sealed record class CampaignCreateResponse : JsonModel
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

    public CampaignCreateResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public CampaignCreateResponse(CampaignCreateResponse campaignCreateResponse)
        : base(campaignCreateResponse) { }
#pragma warning restore CS8618

    public CampaignCreateResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    CampaignCreateResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="CampaignCreateResponseFromRaw.FromRawUnchecked"/>
    public static CampaignCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public CampaignCreateResponse(TenDlcCampaign campaign)
        : this()
    {
        this.Campaign = campaign;
    }
}

class CampaignCreateResponseFromRaw : IFromRawJson<CampaignCreateResponse>
{
    /// <inheritdoc/>
    public CampaignCreateResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => CampaignCreateResponse.FromRawUnchecked(rawData);
}
