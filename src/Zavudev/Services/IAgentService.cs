using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Agents;
using Agents = Zavudev.Services.Agents;

namespace Zavudev.Services;

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

    Agents::ISenderService Senders { get; }

    /// <summary>
    /// Create an agent without a sender. It is created disabled; connect a sender and
    /// enable it when you are ready for it to answer.
    ///
    /// <para>**Sub-resources.** An agent's tools, flows and knowledge bases are
    /// reachable at `/v1/agents/{agentId}/tools`, `/v1/agents/{agentId}/flows` and
    /// `/v1/agents/{agentId}/knowledge-bases`, mirroring the sender-scoped routes
    /// documented under `/v1/senders/{senderId}/agent/...` exactly. Use the
    /// agent-scoped form while the agent has no sender: the sender-scoped one cannot
    /// address it.</para>
    /// </summary>
    Task<AgentCreateResponse> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get an agent
    /// </summary>
    Task<AgentRetrieveResponse> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<AgentRetrieveResponse> Retrieve(
        string agentID,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an agent
    /// </summary>
    Task<AgentUpdateResponse> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<AgentUpdateResponse> Update(
        string agentID,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Every agent in the project, newest first — including agents that are not
    /// connected to any sender yet, which the sender-scoped routes cannot reach. Each
    /// item carries `senderIds`, the senders the agent answers on.
    /// </summary>
    Task<AgentListPage> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an agent
    /// </summary>
    Task Delete(AgentDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(AgentDeleteParams, CancellationToken)"/>
    Task Delete(
        string agentID,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The voices an agent can speak with, for `voice.ttsVoiceId`. Filter by `language`
    /// to get the ones that speak it; a voice can still be used with `language: auto`,
    /// where the agent follows the caller and keeps the chosen voice.
    /// </summary>
    Task<AgentListVoicesResponse> ListVoices(
        AgentListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run the agent's prompt, model and knowledge base against a message and return
    /// the reply instead of delivering it. Writes nothing and charges nothing, so it is
    /// safe to call repeatedly while iterating on a prompt.
    ///
    /// <para>Note that a dry run never **executes** tools — running them would cause
    /// real side effects. Live conversations on every channel do call them. When the
    /// agent has enabled tools, that gap is reported in `warnings` rather than silently
    /// producing an answer that looks like a tool call happened.</para>
    /// </summary>
    Task<AgentTestResponse> Test(
        AgentTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(AgentTestParams, CancellationToken)"/>
    Task<AgentTestResponse> Test(
        string agentID,
        AgentTestParams parameters,
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

    Agents::ISenderServiceWithRawResponse Senders { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/agents</c>, but is otherwise the
    /// same as <see cref="IAgentService.Create(AgentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentCreateResponse>> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/agents/{agentId}</c>, but is otherwise the
    /// same as <see cref="IAgentService.Retrieve(AgentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentRetrieveResponse>> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AgentRetrieveResponse>> Retrieve(
        string agentID,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/agents/{agentId}</c>, but is otherwise the
    /// same as <see cref="IAgentService.Update(AgentUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentUpdateResponse>> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(AgentUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AgentUpdateResponse>> Update(
        string agentID,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/agents</c>, but is otherwise the
    /// same as <see cref="IAgentService.List(AgentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentListPage>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/agents/{agentId}</c>, but is otherwise the
    /// same as <see cref="IAgentService.Delete(AgentDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        AgentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(AgentDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string agentID,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/agents/voices</c>, but is otherwise the
    /// same as <see cref="IAgentService.ListVoices(AgentListVoicesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentListVoicesResponse>> ListVoices(
        AgentListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/agents/{agentId}/test</c>, but is otherwise the
    /// same as <see cref="IAgentService.Test(AgentTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentTestResponse>> Test(
        AgentTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(AgentTestParams, CancellationToken)"/>
    Task<HttpResponse<AgentTestResponse>> Test(
        string agentID,
        AgentTestParams parameters,
        CancellationToken cancellationToken = default
    );
}
