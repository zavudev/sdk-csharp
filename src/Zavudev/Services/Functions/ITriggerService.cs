using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Functions.Triggers;

namespace Zavudev.Services.Functions;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ITriggerService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ITriggerServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITriggerService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Subscribe a function to one or more event types, optionally scoped to specific
    /// senders. Provide eventTypes and senderIds (use null in senderIds for all
    /// senders); a trigger is created for each event type and sender combination.
    ///
    /// <para>The special event type `cron` runs the function on a schedule instead of a
    /// messaging event: include a `cron` field with a 5-field UTC cron expression
    /// (minimum granularity one minute). A cron trigger ignores the sender axis, and a
    /// function may hold several cron triggers with different expressions. The function
    /// receives an event with `type: "cron"` and `data.cron`.</para>
    /// </summary>
    Task<TriggerCreateResponse> Create(
        TriggerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TriggerCreateParams, CancellationToken)"/>
    Task<TriggerCreateResponse> Create(
        string functionID,
        TriggerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Enable or disable a trigger
    /// </summary>
    Task<TriggerUpdateResponse> Update(
        TriggerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TriggerUpdateParams, CancellationToken)"/>
    Task<TriggerUpdateResponse> Update(
        string triggerID,
        TriggerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List function triggers
    /// </summary>
    Task<TriggerListResponse> List(
        TriggerListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TriggerListParams, CancellationToken)"/>
    Task<TriggerListResponse> List(
        string functionID,
        TriggerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a trigger
    /// </summary>
    Task Delete(TriggerDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(TriggerDeleteParams, CancellationToken)"/>
    Task Delete(
        string triggerID,
        TriggerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ITriggerService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ITriggerServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ITriggerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/functions/{functionId}/triggers</c>, but is otherwise the
    /// same as <see cref="ITriggerService.Create(TriggerCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TriggerCreateResponse>> Create(
        TriggerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(TriggerCreateParams, CancellationToken)"/>
    Task<HttpResponse<TriggerCreateResponse>> Create(
        string functionID,
        TriggerCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/functions/triggers/{triggerId}</c>, but is otherwise the
    /// same as <see cref="ITriggerService.Update(TriggerUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TriggerUpdateResponse>> Update(
        TriggerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(TriggerUpdateParams, CancellationToken)"/>
    Task<HttpResponse<TriggerUpdateResponse>> Update(
        string triggerID,
        TriggerUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/functions/{functionId}/triggers</c>, but is otherwise the
    /// same as <see cref="ITriggerService.List(TriggerListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<TriggerListResponse>> List(
        TriggerListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(TriggerListParams, CancellationToken)"/>
    Task<HttpResponse<TriggerListResponse>> List(
        string functionID,
        TriggerListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/functions/triggers/{triggerId}</c>, but is otherwise the
    /// same as <see cref="ITriggerService.Delete(TriggerDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        TriggerDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(TriggerDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string triggerID,
        TriggerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
