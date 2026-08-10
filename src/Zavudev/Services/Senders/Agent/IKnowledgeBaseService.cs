using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.KnowledgeBases;
using Zavudev.Services.Senders.Agent.KnowledgeBases;

namespace Zavudev.Services.Senders.Agent;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IKnowledgeBaseService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IKnowledgeBaseServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKnowledgeBaseService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDocumentService Documents { get; }

    /// <summary>
    /// Create a new knowledge base for an agent.
    /// </summary>
    Task<KnowledgeBaseCreateResponse> Create(
        KnowledgeBaseCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(KnowledgeBaseCreateParams, CancellationToken)"/>
    Task<KnowledgeBaseCreateResponse> Create(
        string senderID,
        KnowledgeBaseCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a specific knowledge base.
    /// </summary>
    Task<KnowledgeBaseRetrieveResponse> Retrieve(
        KnowledgeBaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(KnowledgeBaseRetrieveParams, CancellationToken)"/>
    Task<KnowledgeBaseRetrieveResponse> Retrieve(
        string kbid,
        KnowledgeBaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a knowledge base.
    /// </summary>
    Task<KnowledgeBaseUpdateResponse> Update(
        KnowledgeBaseUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(KnowledgeBaseUpdateParams, CancellationToken)"/>
    Task<KnowledgeBaseUpdateResponse> Update(
        string kbid,
        KnowledgeBaseUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List knowledge bases for an agent.
    /// </summary>
    Task<KnowledgeBaseListPage> List(
        KnowledgeBaseListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(KnowledgeBaseListParams, CancellationToken)"/>
    Task<KnowledgeBaseListPage> List(
        string senderID,
        KnowledgeBaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a knowledge base and all its documents.
    /// </summary>
    Task Delete(
        KnowledgeBaseDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(KnowledgeBaseDeleteParams, CancellationToken)"/>
    Task Delete(
        string kbid,
        KnowledgeBaseDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IKnowledgeBaseService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IKnowledgeBaseServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IKnowledgeBaseServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDocumentServiceWithRawResponse Documents { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/agent/knowledge-bases</c>, but is otherwise the
    /// same as <see cref="IKnowledgeBaseService.Create(KnowledgeBaseCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KnowledgeBaseCreateResponse>> Create(
        KnowledgeBaseCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(KnowledgeBaseCreateParams, CancellationToken)"/>
    Task<HttpResponse<KnowledgeBaseCreateResponse>> Create(
        string senderID,
        KnowledgeBaseCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent/knowledge-bases/{kbId}</c>, but is otherwise the
    /// same as <see cref="IKnowledgeBaseService.Retrieve(KnowledgeBaseRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KnowledgeBaseRetrieveResponse>> Retrieve(
        KnowledgeBaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(KnowledgeBaseRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<KnowledgeBaseRetrieveResponse>> Retrieve(
        string kbid,
        KnowledgeBaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /v1/senders/{senderId}/agent/knowledge-bases/{kbId}</c>, but is otherwise the
    /// same as <see cref="IKnowledgeBaseService.Update(KnowledgeBaseUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KnowledgeBaseUpdateResponse>> Update(
        KnowledgeBaseUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(KnowledgeBaseUpdateParams, CancellationToken)"/>
    Task<HttpResponse<KnowledgeBaseUpdateResponse>> Update(
        string kbid,
        KnowledgeBaseUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent/knowledge-bases</c>, but is otherwise the
    /// same as <see cref="IKnowledgeBaseService.List(KnowledgeBaseListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<KnowledgeBaseListPage>> List(
        KnowledgeBaseListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(KnowledgeBaseListParams, CancellationToken)"/>
    Task<HttpResponse<KnowledgeBaseListPage>> List(
        string senderID,
        KnowledgeBaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/senders/{senderId}/agent/knowledge-bases/{kbId}</c>, but is otherwise the
    /// same as <see cref="IKnowledgeBaseService.Delete(KnowledgeBaseDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        KnowledgeBaseDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(KnowledgeBaseDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string kbid,
        KnowledgeBaseDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
