using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent.KnowledgeBases.Documents;

namespace Zavudev.Services.Senders.Agent.KnowledgeBases;

/// <inheritdoc/>
public sealed class DocumentService : IDocumentService
{
    readonly Lazy<IDocumentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDocumentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DocumentService(this._client.WithOptions(modifier));
    }

    public DocumentService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DocumentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<DocumentCreateResponse> Create(
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DocumentCreateResponse> Create(
        string kbid,
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { KBID = kbid }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DocumentListPage> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DocumentListPage> List(
        string kbid,
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { KBID = kbid }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string docID,
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { DocID = docID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class DocumentServiceWithRawResponse : IDocumentServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDocumentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DocumentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DocumentServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DocumentCreateResponse>> Create(
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.KBID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.KBID' cannot be null");
        }

        HttpRequest<DocumentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var document = await response
                    .Deserialize<DocumentCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    document.Validate();
                }
                return document;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DocumentCreateResponse>> Create(
        string kbid,
        DocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { KBID = kbid }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DocumentListPage>> List(
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.KBID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.KBID' cannot be null");
        }

        HttpRequest<DocumentListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<DocumentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new DocumentListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<DocumentListPage>> List(
        string kbid,
        DocumentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.List(parameters with { KBID = kbid }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DocID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.DocID' cannot be null");
        }

        HttpRequest<DocumentDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string docID,
        DocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { DocID = docID }, cancellationToken);
    }
}
