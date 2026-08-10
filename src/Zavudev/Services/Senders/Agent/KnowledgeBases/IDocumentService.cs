using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

namespace Zavudev.Services.Senders.Agent.KnowledgeBases;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDocumentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDocumentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add a document to a knowledge base. The document will be automatically processed
    /// for RAG.
    /// </summary>
    Task<DocumentCreateResponse> Create(
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(DocumentCreateParams, CancellationToken)"/>
    Task<DocumentCreateResponse> Create(
        string kbid,
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List documents in a knowledge base.
    /// </summary>
    Task<DocumentListPage> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(DocumentListParams, CancellationToken)"/>
    Task<DocumentListPage> List(
        string kbid,
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a document from a knowledge base.
    /// </summary>
    Task Delete(DocumentDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(DocumentDeleteParams, CancellationToken)"/>
    Task Delete(
        string docID,
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDocumentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDocumentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDocumentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/senders/{senderId}/agent/knowledge-bases/{kbId}/documents</c>, but is otherwise the
    /// same as <see cref="IDocumentService.Create(DocumentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DocumentCreateResponse>> Create(
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(DocumentCreateParams, CancellationToken)"/>
    Task<HttpResponse<DocumentCreateResponse>> Create(
        string kbid,
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/senders/{senderId}/agent/knowledge-bases/{kbId}/documents</c>, but is otherwise the
    /// same as <see cref="IDocumentService.List(DocumentListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DocumentListPage>> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(DocumentListParams, CancellationToken)"/>
    Task<HttpResponse<DocumentListPage>> List(
        string kbid,
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/senders/{senderId}/agent/knowledge-bases/{kbId}/documents/{docId}</c>, but is otherwise the
    /// same as <see cref="IDocumentService.Delete(DocumentDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(DocumentDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string docID,
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
