using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent;
using Zavudev.Services.Senders.Agent;

namespace Zavudev.Services.Senders;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAgentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAgentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExecutionService Executions { get; }

    IFlowService Flows { get; }

    IToolService Tools { get; }

    IKnowledgeBaseService KnowledgeBases { get; }

    /// <summary>
    /// Create an AI agent for a sender. Each sender can have at most one agent.
    /// </summary>
    Task<AgentResponse> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(AgentCreateParams, CancellationToken)"/>
    Task<AgentResponse> Create(
        string senderID,
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get the AI agent configuration for a sender.
    /// </summary>
    Task<AgentResponse> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<AgentResponse> Retrieve(
        string senderID,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an AI agent's configuration.
    /// </summary>
    Task<AgentResponse> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<AgentResponse> Update(
        string senderID,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an AI agent.
    /// </summary>
    Task Delete(AgentDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(AgentDeleteParams, CancellationToken)"/>
    Task Delete(
        string senderID,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get statistics for an AI agent including invocations, tokens, and costs.
    ///
    /// <para>Covers the messaging channels only. Voice calls are not counted here: a
    /// call is a multi-turn conversation rather than one inbound message and one reply,
    /// so it is recorded as a call, not an execution. An agent that only answers phone
    /// calls reports zeros on every field. Use `GET /v1/calls` for voice activity,
    /// duration, and cost.</para>
    /// </summary>
    Task<AgentStats> Stats(
        AgentStatsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stats(AgentStatsParams, CancellationToken)"/>
    Task<AgentStats> Stats(
        string senderID,
        AgentStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAgentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAgentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IExecutionServiceWithRawResponse Executions { get; }

    IFlowServiceWithRawResponse Flows { get; }

    IToolServiceWithRawResponse Tools { get; }

    IKnowledgeBaseServiceWithRawResponse KnowledgeBases { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/agent</c>, but is otherwise the
    /// same as <see cref="IAgentService.Create(AgentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentResponse>> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(AgentCreateParams, CancellationToken)"/>
    Task<HttpResponse<AgentResponse>> Create(
        string senderID,
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent</c>, but is otherwise the
    /// same as <see cref="IAgentService.Retrieve(AgentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentResponse>> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AgentResponse>> Retrieve(
        string senderID,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/senders/{senderId}/agent</c>, but is otherwise the
    /// same as <see cref="IAgentService.Update(AgentUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentResponse>> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AgentResponse>> Update(
        string senderID,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/senders/{senderId}/agent</c>, but is otherwise the
    /// same as <see cref="IAgentService.Delete(AgentDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        AgentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AgentDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string senderID,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent/stats</c>, but is otherwise the
    /// same as <see cref="IAgentService.Stats(AgentStatsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentStats>> Stats(
        AgentStatsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Stats(AgentStatsParams, CancellationToken)"/>
    Task<HttpResponse<AgentStats>> Stats(
        string senderID,
        AgentStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
