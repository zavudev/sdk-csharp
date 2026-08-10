using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Number10dlc.Brands;

namespace Zavudev.Services.Number10dlc;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IBrandService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IBrandServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a 10DLC brand registration. The brand starts in draft status. Submit it
    /// for review using the submit endpoint.
    /// </summary>
    Task<BrandCreateResponse> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get 10DLC brand
    /// </summary>
    Task<BrandRetrieveResponse> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BrandRetrieveParams, CancellationToken)"/>
    Task<BrandRetrieveResponse> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a 10DLC brand in draft status. Cannot update after submission.
    /// </summary>
    Task<BrandUpdateResponse> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<BrandUpdateResponse> Update(
        string brandID,
        BrandUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List 10DLC brand registrations for this project.
    /// </summary>
    Task<BrandListPage> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete 10DLC brand
    /// </summary>
    Task Delete(BrandDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(BrandDeleteParams, CancellationToken)"/>
    Task Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List available use cases for 10DLC campaign registration.
    /// </summary>
    Task<BrandListUseCasesResponse> ListUseCases(
        BrandListUseCasesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit a draft brand to The Campaign Registry (TCR) for vetting. The brand must
    /// be in draft status. TCR's one-time $4 brand registration fee is charged from
    /// your balance at submission (passed through at cost) and refunded if the carrier
    /// rejects the registration. A team that already paid this fee through the
    /// compliance flow is not charged again. Campaign registration is billed separately
    /// when a campaign is submitted.
    /// </summary>
    Task<BrandSubmitResponse> Submit(
        BrandSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(BrandSubmitParams, CancellationToken)"/>
    Task<BrandSubmitResponse> Submit(
        string brandID,
        BrandSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sync the brand status with the registration provider. Use this to check for
    /// approval updates after submission.
    /// </summary>
    Task<BrandSyncStatusResponse> SyncStatus(
        BrandSyncStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SyncStatus(BrandSyncStatusParams, CancellationToken)"/>
    Task<BrandSyncStatusResponse> SyncStatus(
        string brandID,
        BrandSyncStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IBrandService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IBrandServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IBrandServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/10dlc/brands</c>, but is otherwise the
    /// same as <see cref="IBrandService.Create(BrandCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BrandCreateResponse>> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/10dlc/brands/{brandId}</c>, but is otherwise the
    /// same as <see cref="IBrandService.Retrieve(BrandRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BrandRetrieveResponse>> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(BrandRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<BrandRetrieveResponse>> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/10dlc/brands/{brandId}</c>, but is otherwise the
    /// same as <see cref="IBrandService.Update(BrandUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BrandUpdateResponse>> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(BrandUpdateParams, CancellationToken)"/>
    Task<HttpResponse<BrandUpdateResponse>> Update(
        string brandID,
        BrandUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/10dlc/brands</c>, but is otherwise the
    /// same as <see cref="IBrandService.List(BrandListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BrandListPage>> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/10dlc/brands/{brandId}</c>, but is otherwise the
    /// same as <see cref="IBrandService.Delete(BrandDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(BrandDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/10dlc/brands/use-cases</c>, but is otherwise the
    /// same as <see cref="IBrandService.ListUseCases(BrandListUseCasesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BrandListUseCasesResponse>> ListUseCases(
        BrandListUseCasesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/10dlc/brands/{brandId}/submit</c>, but is otherwise the
    /// same as <see cref="IBrandService.Submit(BrandSubmitParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BrandSubmitResponse>> Submit(
        BrandSubmitParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Submit(BrandSubmitParams, CancellationToken)"/>
    Task<HttpResponse<BrandSubmitResponse>> Submit(
        string brandID,
        BrandSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/10dlc/brands/{brandId}/sync</c>, but is otherwise the
    /// same as <see cref="IBrandService.SyncStatus(BrandSyncStatusParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<BrandSyncStatusResponse>> SyncStatus(
        BrandSyncStatusParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="SyncStatus(BrandSyncStatusParams, CancellationToken)"/>
    Task<HttpResponse<BrandSyncStatusResponse>> SyncStatus(
        string brandID,
        BrandSyncStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
