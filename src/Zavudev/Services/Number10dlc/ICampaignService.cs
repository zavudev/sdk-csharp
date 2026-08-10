using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Number10dlc.Campaigns;
using Campaigns = Zavudev.Services.Number10dlc.Campaigns;

namespace Zavudev.Services.Number10dlc;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICampaignService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICampaignServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICampaignService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Campaigns::IPhoneNumberService PhoneNumbers { get; }

    /// <summary>
    /// Create a 10DLC campaign under an existing brand. The campaign starts in draft
    /// status. Submit it for carrier review using the submit endpoint.
    /// </summary>
    Task<CampaignCreateResponse> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get 10DLC campaign
    /// </summary>
    Task<CampaignRetrieveResponse> Retrieve(
        CampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CampaignRetrieveParams, CancellationToken)"/>
    Task<CampaignRetrieveResponse> Retrieve(
        string campaignID,
        CampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a 10DLC campaign in draft status. Cannot update after submission.
    /// </summary>
    Task<CampaignUpdateResponse> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CampaignUpdateParams, CancellationToken)"/>
    Task<CampaignUpdateResponse> Update(
        string campaignID,
        CampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List 10DLC campaign registrations for this project.
    /// </summary>
    Task<CampaignListPage> List(
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete 10DLC campaign
    /// </summary>
    Task Delete(CampaignDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(CampaignDeleteParams, CancellationToken)"/>
    Task Delete(
        string campaignID,
        CampaignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit a draft campaign for carrier review. The campaign must be in draft status
    /// and its brand must be verified. TCR's one-time registration fee is charged from
    /// your balance at submission ($15 for standard use cases, $2 for LOW_VOLUME),
    /// passed through at cost and refunded if the carrier rejects it. Once approved,
    /// the campaign's monthly TCR fee ($10 standard, $2 LOW_VOLUME) is charged from
    /// your balance while the campaign is active — see registrationCostCents and
    /// monthlyFeeCents on the campaign object.
    /// </summary>
    Task<CampaignSubmitResponse> Submit(
        CampaignSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(CampaignSubmitParams, CancellationToken)"/>
    Task<CampaignSubmitResponse> Submit(
        string campaignID,
        CampaignSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sync the campaign status with the registration provider. Use this to check for
    /// approval updates after submission.
    /// </summary>
    Task<CampaignSyncStatusResponse> SyncStatus(
        CampaignSyncStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SyncStatus(CampaignSyncStatusParams, CancellationToken)"/>
    Task<CampaignSyncStatusResponse> SyncStatus(
        string campaignID,
        CampaignSyncStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICampaignService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICampaignServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICampaignServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    Campaigns::IPhoneNumberServiceWithRawResponse PhoneNumbers { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/10dlc/campaigns</c>, but is otherwise the
    /// same as <see cref="ICampaignService.Create(CampaignCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CampaignCreateResponse>> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/10dlc/campaigns/{campaignId}</c>, but is otherwise the
    /// same as <see cref="ICampaignService.Retrieve(CampaignRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CampaignRetrieveResponse>> Retrieve(
        CampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CampaignRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<CampaignRetrieveResponse>> Retrieve(
        string campaignID,
        CampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/10dlc/campaigns/{campaignId}</c>, but is otherwise the
    /// same as <see cref="ICampaignService.Update(CampaignUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CampaignUpdateResponse>> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(CampaignUpdateParams, CancellationToken)"/>
    Task<HttpResponse<CampaignUpdateResponse>> Update(
        string campaignID,
        CampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/10dlc/campaigns</c>, but is otherwise the
    /// same as <see cref="ICampaignService.List(CampaignListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CampaignListPage>> List(
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/10dlc/campaigns/{campaignId}</c>, but is otherwise the
    /// same as <see cref="ICampaignService.Delete(CampaignDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(CampaignDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string campaignID,
        CampaignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/10dlc/campaigns/{campaignId}/submit</c>, but is otherwise the
    /// same as <see cref="ICampaignService.Submit(CampaignSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CampaignSubmitResponse>> Submit(
        CampaignSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(CampaignSubmitParams, CancellationToken)"/>
    Task<HttpResponse<CampaignSubmitResponse>> Submit(
        string campaignID,
        CampaignSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/10dlc/campaigns/{campaignId}/sync</c>, but is otherwise the
    /// same as <see cref="ICampaignService.SyncStatus(CampaignSyncStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CampaignSyncStatusResponse>> SyncStatus(
        CampaignSyncStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SyncStatus(CampaignSyncStatusParams, CancellationToken)"/>
    Task<HttpResponse<CampaignSyncStatusResponse>> SyncStatus(
        string campaignID,
        CampaignSyncStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
