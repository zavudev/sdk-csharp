using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.SubAccounts.ApiKeys;

namespace Zavudev.Services.SubAccounts;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IApiKeyService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IApiKeyServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IApiKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create sub-account API key. Requires a parent project API key; sub-account API
    /// keys receive HTTP 403.
    /// </summary>
    Task<ApiKeyCreateResponse> Create(
        ApiKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ApiKeyCreateParams, CancellationToken)"/>
    Task<ApiKeyCreateResponse> Create(
        string id,
        ApiKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List sub-account API keys. Requires a parent project API key; sub-account API
    /// keys receive HTTP 403.
    /// </summary>
    Task<ApiKeyListResponse> List(
        ApiKeyListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ApiKeyListParams, CancellationToken)"/>
    Task<ApiKeyListResponse> List(
        string id,
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revoke sub-account API key. Requires a parent project API key; sub-account API
    /// keys receive HTTP 403.
    /// </summary>
    Task Revoke(ApiKeyRevokeParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Revoke(ApiKeyRevokeParams, CancellationToken)"/>
    Task Revoke(
        string keyID,
        ApiKeyRevokeParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IApiKeyService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IApiKeyServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IApiKeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sub-accounts/{id}/api-keys</c>, but is otherwise the
    /// same as <see cref="IApiKeyService.Create(ApiKeyCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiKeyCreateResponse>> Create(
        ApiKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ApiKeyCreateParams, CancellationToken)"/>
    Task<HttpResponse<ApiKeyCreateResponse>> Create(
        string id,
        ApiKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sub-accounts/{id}/api-keys</c>, but is otherwise the
    /// same as <see cref="IApiKeyService.List(ApiKeyListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ApiKeyListResponse>> List(
        ApiKeyListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ApiKeyListParams, CancellationToken)"/>
    Task<HttpResponse<ApiKeyListResponse>> List(
        string id,
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/sub-accounts/{id}/api-keys/{keyId}</c>, but is otherwise the
    /// same as <see cref="IApiKeyService.Revoke(ApiKeyRevokeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Revoke(
        ApiKeyRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(ApiKeyRevokeParams, CancellationToken)"/>
    Task<HttpResponse> Revoke(
        string keyID,
        ApiKeyRevokeParams parameters,
        CancellationToken cancellationToken = default
    );
}
