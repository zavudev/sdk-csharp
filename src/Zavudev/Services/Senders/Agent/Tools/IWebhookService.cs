using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Senders;
using Zavudev.Models.Senders.Agent.Tools.Webhook;

namespace Zavudev.Services.Senders.Agent.Tools;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IWebhookService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IWebhookServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Generate a new signing secret for this tool. The previous one stops working on
    /// the next call, with no overlap, so update your endpoint first. The tool keeps
    /// its id, so flows that reference it by name are unaffected.
    /// </summary>
    Task<WebhookSecretResponse> RotateSecret(
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateSecret(WebhookRotateSecretParams, CancellationToken)"/>
    Task<WebhookSecretResponse> RotateSecret(
        string toolID,
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IWebhookService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IWebhookServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/agent/tools/{toolId}/webhook/secret</c>, but is otherwise the
    /// same as <see cref="IWebhookService.RotateSecret(WebhookRotateSecretParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<WebhookSecretResponse>> RotateSecret(
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RotateSecret(WebhookRotateSecretParams, CancellationToken)"/>
    Task<HttpResponse<WebhookSecretResponse>> RotateSecret(
        string toolID,
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    );
}
