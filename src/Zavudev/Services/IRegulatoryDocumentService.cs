using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.RegulatoryDocuments;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IRegulatoryDocumentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IRegulatoryDocumentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegulatoryDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a regulatory document record after uploading the file. Use the upload-url
    /// endpoint first to get an upload URL.
    /// </summary>
    Task<RegulatoryDocumentCreateResponse> Create(
        RegulatoryDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a specific regulatory document.
    /// </summary>
    Task<RegulatoryDocumentRetrieveResponse> Retrieve(
        RegulatoryDocumentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RegulatoryDocumentRetrieveParams, CancellationToken)"/>
    Task<RegulatoryDocumentRetrieveResponse> Retrieve(
        string documentID,
        RegulatoryDocumentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List regulatory documents for this project.
    /// </summary>
    Task<RegulatoryDocumentListPage> List(
        RegulatoryDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a regulatory document. Cannot delete verified documents.
    /// </summary>
    Task Delete(
        RegulatoryDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RegulatoryDocumentDeleteParams, CancellationToken)"/>
    Task Delete(
        string documentID,
        RegulatoryDocumentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a presigned URL to upload a document file. After uploading, use the
    /// storageId to create the document record.
    /// </summary>
    Task<RegulatoryDocumentUploadUrlResponse> UploadUrl(
        RegulatoryDocumentUploadUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IRegulatoryDocumentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IRegulatoryDocumentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IRegulatoryDocumentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/documents</c>, but is otherwise the
    /// same as <see cref="IRegulatoryDocumentService.Create(RegulatoryDocumentCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RegulatoryDocumentCreateResponse>> Create(
        RegulatoryDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/documents/{documentId}</c>, but is otherwise the
    /// same as <see cref="IRegulatoryDocumentService.Retrieve(RegulatoryDocumentRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RegulatoryDocumentRetrieveResponse>> Retrieve(
        RegulatoryDocumentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(RegulatoryDocumentRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<RegulatoryDocumentRetrieveResponse>> Retrieve(
        string documentID,
        RegulatoryDocumentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/documents</c>, but is otherwise the
    /// same as <see cref="IRegulatoryDocumentService.List(RegulatoryDocumentListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RegulatoryDocumentListPage>> List(
        RegulatoryDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/documents/{documentId}</c>, but is otherwise the
    /// same as <see cref="IRegulatoryDocumentService.Delete(RegulatoryDocumentDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        RegulatoryDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(RegulatoryDocumentDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string documentID,
        RegulatoryDocumentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/documents/upload-url</c>, but is otherwise the
    /// same as <see cref="IRegulatoryDocumentService.UploadUrl(RegulatoryDocumentUploadUrlParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<RegulatoryDocumentUploadUrlResponse>> UploadUrl(
        RegulatoryDocumentUploadUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
