using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.SubAccounts;
using Zavudev.Services.SubAccounts;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISubAccountService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISubAccountServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IApiKeyService ApiKeys { get; }

    /// <summary>
    /// Create a new sub-account (project) with its own API key. All charges are billed
    /// to the parent team's balance. Use creditLimit to set a spending cap. The
    /// sub-account's API key is returned only in the creation response. Requires a
    /// parent project API key; sub-account API keys receive HTTP 403.
    /// </summary>
    Task<SubAccountCreateResponse> Create(
        SubAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get sub-account. Requires a parent project API key; sub-account API keys receive
    /// HTTP 403.
    /// </summary>
    Task<SubAccountRetrieveResponse> Retrieve(
        SubAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SubAccountRetrieveParams, CancellationToken)"/>
    Task<SubAccountRetrieveResponse> Retrieve(
        string id,
        SubAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update sub-account. Requires a parent project API key; sub-account API keys
    /// receive HTTP 403.
    /// </summary>
    Task<SubAccountUpdateResponse> Update(
        SubAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SubAccountUpdateParams, CancellationToken)"/>
    Task<SubAccountUpdateResponse> Update(
        string id,
        SubAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List sub-accounts for this team. Requires a parent project API key; sub-account
    /// API keys receive HTTP 403.
    /// </summary>
    Task<SubAccountListPage> List(
        SubAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deactivate a sub-account. Remaining balance is returned to the parent team and
    /// all API keys are revoked. Requires a parent project API key; sub-account API
    /// keys receive HTTP 403.
    /// </summary>
    Task<SubAccountDeactivateResponse> Deactivate(
        SubAccountDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(SubAccountDeactivateParams, CancellationToken)"/>
    Task<SubAccountDeactivateResponse> Deactivate(
        string id,
        SubAccountDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get spending information for a sub-account. Returns the parent team's balance,
    /// the sub-account's total spending, and its credit limit (spending cap). Requires
    /// a parent project API key; sub-account API keys receive HTTP 403.
    /// </summary>
    Task<SubAccountGetBalanceResponse> GetBalance(
        SubAccountGetBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetBalance(SubAccountGetBalanceParams, CancellationToken)"/>
    Task<SubAccountGetBalanceResponse> GetBalance(
        string id,
        SubAccountGetBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISubAccountService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISubAccountServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISubAccountServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IApiKeyServiceWithRawResponse ApiKeys { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/sub-accounts</c>, but is otherwise the
    /// same as <see cref="ISubAccountService.Create(SubAccountCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubAccountCreateResponse>> Create(
        SubAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sub-accounts/{id}</c>, but is otherwise the
    /// same as <see cref="ISubAccountService.Retrieve(SubAccountRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubAccountRetrieveResponse>> Retrieve(
        SubAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(SubAccountRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<SubAccountRetrieveResponse>> Retrieve(
        string id,
        SubAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/sub-accounts/{id}</c>, but is otherwise the
    /// same as <see cref="ISubAccountService.Update(SubAccountUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubAccountUpdateResponse>> Update(
        SubAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(SubAccountUpdateParams, CancellationToken)"/>
    Task<HttpResponse<SubAccountUpdateResponse>> Update(
        string id,
        SubAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sub-accounts</c>, but is otherwise the
    /// same as <see cref="ISubAccountService.List(SubAccountListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubAccountListPage>> List(
        SubAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/sub-accounts/{id}</c>, but is otherwise the
    /// same as <see cref="ISubAccountService.Deactivate(SubAccountDeactivateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubAccountDeactivateResponse>> Deactivate(
        SubAccountDeactivateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Deactivate(SubAccountDeactivateParams, CancellationToken)"/>
    Task<HttpResponse<SubAccountDeactivateResponse>> Deactivate(
        string id,
        SubAccountDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/sub-accounts/{id}/balance</c>, but is otherwise the
    /// same as <see cref="ISubAccountService.GetBalance(SubAccountGetBalanceParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SubAccountGetBalanceResponse>> GetBalance(
        SubAccountGetBalanceParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="GetBalance(SubAccountGetBalanceParams, CancellationToken)"/>
    Task<HttpResponse<SubAccountGetBalanceResponse>> GetBalance(
        string id,
        SubAccountGetBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
