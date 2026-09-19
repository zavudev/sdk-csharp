using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Services;

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
    /// Get details of a specific phone number.
    /// </summary>
    Task<PhoneNumberRetrieveResponse> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PhoneNumberRetrieveParams, CancellationToken)"/>
    Task<PhoneNumberRetrieveResponse> Retrieve(
        string phoneNumberID,
        PhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a phone number's name or sender assignment.
    /// </summary>
    Task<PhoneNumberUpdateResponse> Update(
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PhoneNumberUpdateParams, CancellationToken)"/>
    Task<PhoneNumberUpdateResponse> Update(
        string phoneNumberID,
        PhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all phone numbers owned by this project.
    /// </summary>
    Task<PhoneNumberListPage> List(
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Purchase an available phone number. Requires a paid plan: the Free plan cannot
    /// purchase phone numbers and receives `402` with code `paid_plan_required`.
    ///
    /// <para>**The included number.** A paid plan includes one number at no charge,
    /// once per account: it must be a US or Canadian number (a +1 number) costing $20 a
    /// month or less. `isFreeEligible` in `GET /v1/phone-numbers/available` marks the
    /// numbers that qualify. Claiming it spends the benefit for good, across every team
    /// the account owner owns, so releasing that number does not make another one free.</para>
    ///
    /// <para>**Numbers with regulatory requirements.** Which numbers need regulatory
    /// information is decided per number, not by a fixed country list. The purchase
    /// looks the requirements up for the exact number before charging anything:</para>
    ///
    /// <para>1. `GET /v1/phone-numbers/requirements?phoneNumber=...`. If `items` is
    /// empty, buy normally. 2. Create what it asks for: addresses with `POST
    /// /v1/addresses`, documents with `POST /v1/documents`. 3. Purchase with `type` and
    /// `regulatoryRequirements`. The number is bought and billed at once with
    /// `regulatoryStatus: pending_review`. 4. Poll `GET
    /// /v1/phone-numbers/{phoneNumberId}` until `regulatoryStatus` is `approved`.
    /// Assign it to a sender before or after approval; it starts carrying messages once
    /// approved.</para>
    ///
    /// <para>**Reuse.** Information you submitted is kept for your project, per country
    /// and `type`, and a later purchase there may omit `regulatoryRequirements`. Reuse
    /// only happens when what is kept still covers every requirement of the new number
    /// and every address and document in it belongs to the project. Otherwise, or when
    /// nothing is kept, the purchase returns `400 regulatory_compliance_required` with
    /// the missing requirements in `details`.</para>
    ///
    /// <para>Invalid values (a missing, unknown or repeated requirement id, an address
    /// or document from another project, or one rejected in review) return `400
    /// invalid_request`. If an address or document cannot be registered for review, the
    /// purchase returns `400 invalid_request` naming the requirement. If the
    /// requirements cannot be looked up, the purchase returns `502
    /// requirements_unavailable`, except for US and Canadian numbers, which are sold as
    /// numbers without requirements. None of these errors charge anything.</para>
    /// </summary>
    Task<PhoneNumberPurchaseResponse> Purchase(
        PhoneNumberPurchaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Release a phone number. The phone number must not be assigned to a sender.
    /// </summary>
    Task Release(
        PhoneNumberReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(PhoneNumberReleaseParams, CancellationToken)"/>
    Task Release(
        string phoneNumberID,
        PhoneNumberReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the regulatory information needed to buy a phone number, for one specific
    /// number or for a country and number type. Prefer `phoneNumber`: the response is
    /// then exactly the list the purchase of that number validates against. Pass each
    /// `requirementTypes[].id` back as `requirementType` in `regulatoryRequirements` on
    /// `POST /v1/phone-numbers`.
    ///
    /// <para>For `phoneNumber`, the requirements of that exact number are returned.
    /// When they cannot be resolved for the number itself, the list for its country and
    /// `type` is returned instead, and the purchase uses the same list. An empty
    /// `items` array means the number needs no regulatory information. If the
    /// requirements cannot be retrieved at all, the response is `502
    /// requirements_unavailable`, never an empty list.</para>
    ///
    /// <para>URL-encode the `+` of `phoneNumber` as `%2B`. An unencoded `+` is also
    /// accepted.</para>
    /// </summary>
    Task<PhoneNumberRequirementsResponse> Requirements(
        PhoneNumberRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Search for available phone numbers to purchase by country and type.
    /// </summary>
    Task<PhoneNumberSearchAvailableResponse> SearchAvailable(
        PhoneNumberSearchAvailableParams parameters,
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
    /// Returns a raw HTTP response for <c>get /v1/phone-numbers/{phoneNumberId}</c>, but is otherwise the
    /// same as <see cref="IPhoneNumberService.Retrieve(PhoneNumberRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PhoneNumberRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        string phoneNumberID,
        PhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/phone-numbers/{phoneNumberId}</c>, but is otherwise the
    /// same as <see cref="IPhoneNumberService.Update(PhoneNumberUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhoneNumberUpdateResponse>> Update(
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(PhoneNumberUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PhoneNumberUpdateResponse>> Update(
        string phoneNumberID,
        PhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/phone-numbers</c>, but is otherwise the
    /// same as <see cref="IPhoneNumberService.List(PhoneNumberListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhoneNumberListPage>> List(
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/phone-numbers</c>, but is otherwise the
    /// same as <see cref="IPhoneNumberService.Purchase(PhoneNumberPurchaseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhoneNumberPurchaseResponse>> Purchase(
        PhoneNumberPurchaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/phone-numbers/{phoneNumberId}</c>, but is otherwise the
    /// same as <see cref="IPhoneNumberService.Release(PhoneNumberReleaseParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Release(
        PhoneNumberReleaseParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Release(PhoneNumberReleaseParams, CancellationToken)"/>
    Task<HttpResponse> Release(
        string phoneNumberID,
        PhoneNumberReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/phone-numbers/requirements</c>, but is otherwise the
    /// same as <see cref="IPhoneNumberService.Requirements(PhoneNumberRequirementsParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhoneNumberRequirementsResponse>> Requirements(
        PhoneNumberRequirementsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/phone-numbers/available</c>, but is otherwise the
    /// same as <see cref="IPhoneNumberService.SearchAvailable(PhoneNumberSearchAvailableParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhoneNumberSearchAvailableResponse>> SearchAvailable(
        PhoneNumberSearchAvailableParams parameters,
        CancellationToken cancellationToken = default
    );
}
