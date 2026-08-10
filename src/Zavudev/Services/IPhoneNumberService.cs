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
    /// purchase phone numbers and receives `402` with code `paid_plan_required`. Paid
    /// plans include one US number at no charge. The included number is one per account
    /// and is granted once: claiming it spends the benefit for good, so releasing that
    /// number does not make another one free, and numbers the account already bought do
    /// not consume it.
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
    /// Get regulatory requirements for purchasing phone numbers in a specific country.
    /// Some countries require additional documentation (addresses, identity documents)
    /// before phone numbers can be activated.
    /// </summary>
    Task<PhoneNumberRequirementsResponse> Requirements(
        PhoneNumberRequirementsParams parameters,
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
    /// same as <see cref="IPhoneNumberService.Requirements(PhoneNumberRequirementsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PhoneNumberRequirementsResponse>> Requirements(
        PhoneNumberRequirementsParams parameters,
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
