using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

namespace Zavudev.Services.Number10dlc.Campaigns;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPhoneNumberService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPhoneNumberServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List phone numbers assigned to a 10DLC campaign.
    /// </summary>
    Task<PhoneNumberListResponse> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(PhoneNumberListParams, CancellationToken)"/>
    Task<PhoneNumberListResponse> List(
        string campaignID,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign a US phone number to an approved 10DLC campaign. The campaign must be in
    /// approved status.
    /// </summary>
    Task<PhoneNumberAssignResponse> Assign(
        PhoneNumberAssignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Assign(PhoneNumberAssignParams, CancellationToken)"/>
    Task<PhoneNumberAssignResponse> Assign(
        string campaignID,
        PhoneNumberAssignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a phone number assignment from a 10DLC campaign.
    /// </summary>
    Task Unassign(
        PhoneNumberUnassignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unassign(PhoneNumberUnassignParams, CancellationToken)"/>
    Task Unassign(
        string assignmentID,
        PhoneNumberUnassignParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPhoneNumberService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPhoneNumberServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPhoneNumberServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/10dlc/campaigns/{campaignId}/phone-numbers</c>, but is otherwise the
    /// same as <see cref="IPhoneNumberService.List(PhoneNumberListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhoneNumberListResponse>> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(PhoneNumberListParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberListResponse>> List(
        string campaignID,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/10dlc/campaigns/{campaignId}/phone-numbers</c>, but is otherwise the
    /// same as <see cref="IPhoneNumberService.Assign(PhoneNumberAssignParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhoneNumberAssignResponse>> Assign(
        PhoneNumberAssignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Assign(PhoneNumberAssignParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberAssignResponse>> Assign(
        string campaignID,
        PhoneNumberAssignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/10dlc/campaigns/{campaignId}/phone-numbers/{assignmentId}</c>, but is otherwise the
    /// same as <see cref="IPhoneNumberService.Unassign(PhoneNumberUnassignParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Unassign(
        PhoneNumberUnassignParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unassign(PhoneNumberUnassignParams, CancellationToken)"/>
    Task<HttpResponse> Unassign(
        string assignmentID,
        PhoneNumberUnassignParams parameters,
        CancellationToken cancellationToken = default
    );
}
