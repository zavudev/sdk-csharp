using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Functions.Secrets;

namespace Zavudev.Services.Functions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISecretService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISecretServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISecretService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Lists every secret key set on the function. Plaintext is NEVER returned — only
    /// the last 4 characters of each value, for visual confirmation.
    /// </summary>
    Task<SecretListResponse> List(
        SecretListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SecretListParams, CancellationToken)"/>
    Task<SecretListResponse> List(
        string functionID,
        SecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create or update a secret on a function. Marks the function out-of-sync; the
    /// next `POST /deploy` re-publishes the Lambda with the new env. Keys must match
    /// `[A-Z_][A-Z0-9_]*` (uppercase env-var style) and cannot start with reserved
    /// prefixes (AWS_, LAMBDA_, etc).
    /// </summary>
    Task<JsonElement> Set(
        SecretSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Set(SecretSetParams, CancellationToken)"/>
    Task<JsonElement> Set(
        string key,
        SecretSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a secret from a function. Doesn't take effect on the running Lambda until
    /// the next deploy.
    /// </summary>
    Task Unset(SecretUnsetParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Unset(SecretUnsetParams, CancellationToken)"/>
    Task Unset(
        string key,
        SecretUnsetParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISecretService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISecretServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISecretServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/functions/{functionId}/secrets</c>, but is otherwise the
    /// same as <see cref="ISecretService.List(SecretListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SecretListResponse>> List(
        SecretListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(SecretListParams, CancellationToken)"/>
    Task<HttpResponse<SecretListResponse>> List(
        string functionID,
        SecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /v1/functions/{functionId}/secrets/{key}</c>, but is otherwise the
    /// same as <see cref="ISecretService.Set(SecretSetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<JsonElement>> Set(
        SecretSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Set(SecretSetParams, CancellationToken)"/>
    Task<HttpResponse<JsonElement>> Set(
        string key,
        SecretSetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/functions/{functionId}/secrets/{key}</c>, but is otherwise the
    /// same as <see cref="ISecretService.Unset(SecretUnsetParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Unset(
        SecretUnsetParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unset(SecretUnsetParams, CancellationToken)"/>
    Task<HttpResponse> Unset(
        string key,
        SecretUnsetParams parameters,
        CancellationToken cancellationToken = default
    );
}
