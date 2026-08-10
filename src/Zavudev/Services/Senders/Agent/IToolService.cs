using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Services.Senders.Agent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IToolService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IToolServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IToolService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new tool for an agent. Tools allow the agent to call external webhooks.
    /// </summary>
    Task<ToolCreateResponse> Create(
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ToolCreateParams, CancellationToken)"/>
    Task<ToolCreateResponse> Create(
        string senderID,
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a specific tool.
    /// </summary>
    Task<ToolRetrieveResponse> Retrieve(
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ToolRetrieveParams, CancellationToken)"/>
    Task<ToolRetrieveResponse> Retrieve(
        string toolID,
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a tool.
    /// </summary>
    Task<ToolUpdateResponse> Update(
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ToolUpdateParams, CancellationToken)"/>
    Task<ToolUpdateResponse> Update(
        string toolID,
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List tools for an agent.
    /// </summary>
    Task<ToolListPage> List(
        ToolListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ToolListParams, CancellationToken)"/>
    Task<ToolListPage> List(
        string senderID,
        ToolListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a tool.
    /// </summary>
    Task Delete(ToolDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(ToolDeleteParams, CancellationToken)"/>
    Task Delete(
        string toolID,
        ToolDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Run a tool with the parameters you supply and return what it answered.
    ///
    /// <para>The call is synchronous: the response carries the tool's status, body, and
    /// duration, so a green result is evidence the tool ran rather than evidence it was
    /// accepted. Each run is also recorded and readable afterwards via `GET
    /// /v1/senders/{senderId}/agent/tools/{toolId}/test-runs`.</para>
    ///
    /// <para>A tool that answers with an error is reported as a run with `success:
    /// false` — the endpoint itself still returns 200. This fires the tool's real
    /// webhook, so a test has whatever side effects the tool has.</para>
    /// </summary>
    Task<ToolTestResponse> Test(
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(ToolTestParams, CancellationToken)"/>
    Task<ToolTestResponse> Test(
        string toolID,
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IToolService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IToolServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IToolServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/agent/tools</c>, but is otherwise the
    /// same as <see cref="IToolService.Create(ToolCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ToolCreateResponse>> Create(
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(ToolCreateParams, CancellationToken)"/>
    Task<HttpResponse<ToolCreateResponse>> Create(
        string senderID,
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent/tools/{toolId}</c>, but is otherwise the
    /// same as <see cref="IToolService.Retrieve(ToolRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ToolRetrieveResponse>> Retrieve(
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(ToolRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<ToolRetrieveResponse>> Retrieve(
        string toolID,
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/senders/{senderId}/agent/tools/{toolId}</c>, but is otherwise the
    /// same as <see cref="IToolService.Update(ToolUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ToolUpdateResponse>> Update(
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(ToolUpdateParams, CancellationToken)"/>
    Task<HttpResponse<ToolUpdateResponse>> Update(
        string toolID,
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent/tools</c>, but is otherwise the
    /// same as <see cref="IToolService.List(ToolListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ToolListPage>> List(
        ToolListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(ToolListParams, CancellationToken)"/>
    Task<HttpResponse<ToolListPage>> List(
        string senderID,
        ToolListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/senders/{senderId}/agent/tools/{toolId}</c>, but is otherwise the
    /// same as <see cref="IToolService.Delete(ToolDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        ToolDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(ToolDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string toolID,
        ToolDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/agent/tools/{toolId}/test</c>, but is otherwise the
    /// same as <see cref="IToolService.Test(ToolTestParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ToolTestResponse>> Test(
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Test(ToolTestParams, CancellationToken)"/>
    Task<HttpResponse<ToolTestResponse>> Test(
        string toolID,
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    );
}
