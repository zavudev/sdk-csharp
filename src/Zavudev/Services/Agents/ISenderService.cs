using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Agents.Senders;

namespace Zavudev.Services.Agents;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ISenderService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ISenderServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISenderService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Make the agent answer on this sender. An agent can serve several senders; a
    /// sender answers with at most one agent, so connecting one that is already in use
    /// returns `400` naming the agent that holds it.
    /// </summary>
    Task<SenderConnectResponse> Connect(
        SenderConnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Connect(SenderConnectParams, CancellationToken)"/>
    Task<SenderConnectResponse> Connect(
        string agentID,
        SenderConnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Stop the agent answering on this sender. The agent's primary sender is part of
    /// the agent itself and cannot be disconnected here.
    /// </summary>
    Task Disconnect(
        SenderDisconnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Disconnect(SenderDisconnectParams, CancellationToken)"/>
    Task Disconnect(
        string senderID,
        SenderDisconnectParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ISenderService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ISenderServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ISenderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/agents/{agentId}/senders</c>, but is otherwise the
    /// same as <see cref="ISenderService.Connect(SenderConnectParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<SenderConnectResponse>> Connect(
        SenderConnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Connect(SenderConnectParams, CancellationToken)"/>
    Task<HttpResponse<SenderConnectResponse>> Connect(
        string agentID,
        SenderConnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/agents/{agentId}/senders/{senderId}</c>, but is otherwise the
    /// same as <see cref="ISenderService.Disconnect(SenderDisconnectParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Disconnect(
        SenderDisconnectParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Disconnect(SenderDisconnectParams, CancellationToken)"/>
    Task<HttpResponse> Disconnect(
        string senderID,
        SenderDisconnectParams parameters,
        CancellationToken cancellationToken = default
    );
}
