using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.AgentTemplates;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAgentTemplateService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAgentTemplateServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentTemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Fetch a single factory agent fully rendered: the function files to scaffold (an
    /// `index.ts` that declares the agent with `defineAgent` and its skills with
    /// `defineTool`) plus the secrets it needs. This is what `npx zavudev agents pull
    /// &lt;id&gt;` writes to disk before `npx zavudev deploy`.
    /// </summary>
    Task<AgentTemplateRetrieveResponse> Retrieve(
        AgentTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentTemplateRetrieveParams, CancellationToken)"/>
    Task<AgentTemplateRetrieveResponse> Retrieve(
        string templateID,
        AgentTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List the factory agents available to scaffold with `npx zavudev agents pull`.
    /// Each entry is a ready-made voice or text agent (system prompt, skills, and — for
    /// voice agents — a co-located voice config).
    /// </summary>
    Task<AgentTemplateListResponse> List(
        AgentTemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAgentTemplateService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAgentTemplateServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAgentTemplateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/agent-templates/{templateId}</c>, but is otherwise the
    /// same as <see cref="IAgentTemplateService.Retrieve(AgentTemplateRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentTemplateRetrieveResponse>> Retrieve(
        AgentTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(AgentTemplateRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<AgentTemplateRetrieveResponse>> Retrieve(
        string templateID,
        AgentTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/agent-templates</c>, but is otherwise the
    /// same as <see cref="IAgentTemplateService.List(AgentTemplateListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AgentTemplateListResponse>> List(
        AgentTemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
