using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.Executions;

namespace Zavudev.Services.Senders.Agent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IExecutionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IExecutionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExecutionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Fetch full details for one execution — including `errorMessage`, `errorCode`,
    /// and `responseText`. Use this to debug failures surfaced by the list endpoint.
    /// </summary>
    Task<ExecutionRetrieveResponse> Retrieve(
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExecutionRetrieveParams, CancellationToken)"/>
    Task<ExecutionRetrieveResponse> Retrieve(
        string executionID,
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List recent agent executions with pagination.
    ///
    /// <para>An execution is one inbound message answered by the agent, so this covers
    /// the messaging channels only. Voice calls are never listed here regardless of how
    /// many the agent handled. Use `GET /v1/calls` (and `GET /v1/calls/{callId}` for
    /// the transcript) for voice.</para>
    /// </summary>
    Task<ExecutionListPage> List(
        ExecutionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ExecutionListParams, CancellationToken)"/>
    Task<ExecutionListPage> List(
        string senderID,
        ExecutionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IExecutionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IExecutionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IExecutionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent/executions/{executionId}</c>, but is otherwise the
    /// same as <see cref="IExecutionService.Retrieve(ExecutionRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExecutionRetrieveResponse>> Retrieve(
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ExecutionRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ExecutionRetrieveResponse>> Retrieve(
        string executionID,
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent/executions</c>, but is otherwise the
    /// same as <see cref="IExecutionService.List(ExecutionListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ExecutionListPage>> List(
        ExecutionListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ExecutionListParams, CancellationToken)"/>
    Task<HttpResponse<ExecutionListPage>> List(
        string senderID,
        ExecutionListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
