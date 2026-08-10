using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.RegulatoryDocuments;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class RegulatoryDocumentService : IRegulatoryDocumentService
{
    readonly Lazy<IRegulatoryDocumentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IRegulatoryDocumentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IRegulatoryDocumentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new RegulatoryDocumentService(this._client.WithOptions(modifier));
    }

    public RegulatoryDocumentService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new RegulatoryDocumentServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<RegulatoryDocumentCreateResponse> Create(
        RegulatoryDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RegulatoryDocumentRetrieveResponse> Retrieve(
        RegulatoryDocumentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<RegulatoryDocumentRetrieveResponse> Retrieve(
        string documentID,
        RegulatoryDocumentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<RegulatoryDocumentListPage> List(
        RegulatoryDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        RegulatoryDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string documentID,
        RegulatoryDocumentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { DocumentID = documentID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<RegulatoryDocumentUploadUrlResponse> UploadUrl(
        RegulatoryDocumentUploadUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UploadUrl(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class RegulatoryDocumentServiceWithRawResponse
    : IRegulatoryDocumentServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IRegulatoryDocumentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new RegulatoryDocumentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public RegulatoryDocumentServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RegulatoryDocumentCreateResponse>> Create(
        RegulatoryDocumentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<RegulatoryDocumentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var regulatoryDocument = await response
                    .Deserialize<RegulatoryDocumentCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    regulatoryDocument.Validate();
                }
                return regulatoryDocument;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RegulatoryDocumentRetrieveResponse>> Retrieve(
        RegulatoryDocumentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DocumentID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.DocumentID' cannot be null");
        }

        HttpRequest<RegulatoryDocumentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var regulatoryDocument = await response
                    .Deserialize<RegulatoryDocumentRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    regulatoryDocument.Validate();
                }
                return regulatoryDocument;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<RegulatoryDocumentRetrieveResponse>> Retrieve(
        string documentID,
        RegulatoryDocumentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RegulatoryDocumentListPage>> List(
        RegulatoryDocumentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RegulatoryDocumentListParams> request = new()
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
                    .Deserialize<RegulatoryDocumentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new RegulatoryDocumentListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        RegulatoryDocumentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DocumentID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.DocumentID' cannot be null");
        }

        HttpRequest<RegulatoryDocumentDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string documentID,
        RegulatoryDocumentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { DocumentID = documentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<RegulatoryDocumentUploadUrlResponse>> UploadUrl(
        RegulatoryDocumentUploadUrlParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<RegulatoryDocumentUploadUrlParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<RegulatoryDocumentUploadUrlResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
