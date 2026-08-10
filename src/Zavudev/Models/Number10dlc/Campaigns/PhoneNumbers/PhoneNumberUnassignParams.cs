using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using Zavudev.Core;

namespace Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

/// <summary>
/// Remove a phone number assignment from a 10DLC campaign.
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public record class PhoneNumberUnassignParams : ParamsBase
{
    public required string CampaignID { get; init; }

    public string? AssignmentID { get; init; }

    public PhoneNumberUnassignParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public PhoneNumberUnassignParams(PhoneNumberUnassignParams phoneNumberUnassignParams)
        : base(phoneNumberUnassignParams)
    {
        this.CampaignID = phoneNumberUnassignParams.CampaignID;
        this.AssignmentID = phoneNumberUnassignParams.AssignmentID;
    }
#pragma warning restore CS8618

    public PhoneNumberUnassignParams(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PhoneNumberUnassignParams(
        FrozenDictionary<string, JsonElement> rawHeaderData,
        FrozenDictionary<string, JsonElement> rawQueryData,
        string campaignID,
        string assignmentID
    )
    {
        this._rawHeaderData = new(rawHeaderData);
        this._rawQueryData = new(rawQueryData);
        this.CampaignID = campaignID;
        this.AssignmentID = assignmentID;
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="IFromRawJson{T}.FromRawUnchecked"/>
    public static PhoneNumberUnassignParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawHeaderData,
        IReadOnlyDictionary<string, JsonElement> rawQueryData,
        string campaignID,
        string assignmentID
    )
    {
        return new(
            FrozenDictionary.ToFrozenDictionary(rawHeaderData),
            FrozenDictionary.ToFrozenDictionary(rawQueryData),
            campaignID,
            assignmentID
        );
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(
                new Dictionary<string, JsonElement>()
                {
                    ["CampaignID"] = JsonSerializer.SerializeToElement(this.CampaignID),
                    ["AssignmentID"] = JsonSerializer.SerializeToElement(this.AssignmentID),
                    ["HeaderData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawHeaderData.Freeze())
                    ),
                    ["QueryData"] = FriendlyJsonPrinter.PrintValue(
                        JsonSerializer.SerializeToElement(this._rawQueryData.Freeze())
                    ),
                }
            ),
            ModelBase.ToStringSerializerOptions
        );

    public virtual bool Equals(PhoneNumberUnassignParams? other)
    {
        if (other == null)
        {
            return false;
        }
        return this.CampaignID.Equals(other.CampaignID)
            && (this.AssignmentID?.Equals(other.AssignmentID) ?? other.AssignmentID == null)
            && this._rawHeaderData.Equals(other._rawHeaderData)
            && this._rawQueryData.Equals(other._rawQueryData);
    }

    public override Uri Url(ClientOptions options)
    {
        return new UriBuilder(
            options.BaseUrl.ToString().TrimEnd('/')
                + string.Format(
                    "/v1/10dlc/campaigns/{0}/phone-numbers/{1}",
                    this.CampaignID,
                    this.AssignmentID
                )
        )
        {
            Query = this.QueryString(options),
        }.Uri;
    }

    internal override void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options)
    {
        ParamsBase.AddDefaultHeaders(request, options);
        foreach (var item in this.RawHeaderData)
        {
            ParamsBase.AddHeaderElementToRequest(request, item.Key, item.Value);
        }
    }

    public override int GetHashCode()
    {
        return 0;
    }
}
