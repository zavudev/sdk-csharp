using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Services.Senders.Agent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFlowService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFlowServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFlowService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new flow for an agent.
    /// </summary>
    Task<FlowCreateResponse> Create(
        FlowCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(FlowCreateParams, CancellationToken)"/>
    Task<FlowCreateResponse> Create(
        string senderID,
        FlowCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a specific flow.
    /// </summary>
    Task<FlowRetrieveResponse> Retrieve(
        FlowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FlowRetrieveParams, CancellationToken)"/>
    Task<FlowRetrieveResponse> Retrieve(
        string flowID,
        FlowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a flow.
    /// </summary>
    Task<FlowUpdateResponse> Update(
        FlowUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FlowUpdateParams, CancellationToken)"/>
    Task<FlowUpdateResponse> Update(
        string flowID,
        FlowUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List flows for an agent.
    /// </summary>
    Task<FlowListPage> List(
        FlowListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(FlowListParams, CancellationToken)"/>
    Task<FlowListPage> List(
        string senderID,
        FlowListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a flow. Cannot delete flows with active sessions.
    /// </summary>
    Task Delete(FlowDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(FlowDeleteParams, CancellationToken)"/>
    Task Delete(
        string flowID,
        FlowDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a copy of an existing flow with a new name.
    /// </summary>
    Task<FlowDuplicateResponse> Duplicate(
        FlowDuplicateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Duplicate(FlowDuplicateParams, CancellationToken)"/>
    Task<FlowDuplicateResponse> Duplicate(
        string flowID,
        FlowDuplicateParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFlowService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFlowServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFlowServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/agent/flows</c>, but is otherwise the
    /// same as <see cref="IFlowService.Create(FlowCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FlowCreateResponse>> Create(
        FlowCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(FlowCreateParams, CancellationToken)"/>
    Task<HttpResponse<FlowCreateResponse>> Create(
        string senderID,
        FlowCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent/flows/{flowId}</c>, but is otherwise the
    /// same as <see cref="IFlowService.Retrieve(FlowRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FlowRetrieveResponse>> Retrieve(
        FlowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(FlowRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<FlowRetrieveResponse>> Retrieve(
        string flowID,
        FlowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/senders/{senderId}/agent/flows/{flowId}</c>, but is otherwise the
    /// same as <see cref="IFlowService.Update(FlowUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FlowUpdateResponse>> Update(
        FlowUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(FlowUpdateParams, CancellationToken)"/>
    Task<HttpResponse<FlowUpdateResponse>> Update(
        string flowID,
        FlowUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent/flows</c>, but is otherwise the
    /// same as <see cref="IFlowService.List(FlowListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FlowListPage>> List(
        FlowListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(FlowListParams, CancellationToken)"/>
    Task<HttpResponse<FlowListPage>> List(
        string senderID,
        FlowListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/senders/{senderId}/agent/flows/{flowId}</c>, but is otherwise the
    /// same as <see cref="IFlowService.Delete(FlowDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        FlowDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(FlowDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string flowID,
        FlowDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/agent/flows/{flowId}/duplicate</c>, but is otherwise the
    /// same as <see cref="IFlowService.Duplicate(FlowDuplicateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FlowDuplicateResponse>> Duplicate(
        FlowDuplicateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Duplicate(FlowDuplicateParams, CancellationToken)"/>
    Task<HttpResponse<FlowDuplicateResponse>> Duplicate(
        string flowID,
        FlowDuplicateParams parameters,
        CancellationToken cancellationToken = default
    );
}
