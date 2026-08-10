using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent.KnowledgeBases;
using Zavudev.Services.Senders.Agent.KnowledgeBases;

namespace Zavudev.Services.Senders.Agent;

/// <inheritdoc/>
public sealed class KnowledgeBaseService : IKnowledgeBaseService
{
    readonly Lazy<IKnowledgeBaseServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IKnowledgeBaseServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IKnowledgeBaseService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new KnowledgeBaseService(this._client.WithOptions(modifier));
    }

    public KnowledgeBaseService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new KnowledgeBaseServiceWithRawResponse(client.WithRawResponse)
        );
        _documents = new(() => new DocumentService(client));
    }

    readonly Lazy<IDocumentService> _documents;
    public IDocumentService Documents
    {
        get { return _documents.Value; }
    }

    /// <inheritdoc/>
    public async Task<KnowledgeBaseCreateResponse> Create(
        KnowledgeBaseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<KnowledgeBaseCreateResponse> Create(
        string senderID,
        KnowledgeBaseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<KnowledgeBaseRetrieveResponse> Retrieve(
        KnowledgeBaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<KnowledgeBaseRetrieveResponse> Retrieve(
        string kbid,
        KnowledgeBaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { KBID = kbid }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<KnowledgeBaseUpdateResponse> Update(
        KnowledgeBaseUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<KnowledgeBaseUpdateResponse> Update(
        string kbid,
        KnowledgeBaseUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { KBID = kbid }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<KnowledgeBaseListPage> List(
        KnowledgeBaseListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<KnowledgeBaseListPage> List(
        string senderID,
        KnowledgeBaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        KnowledgeBaseDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string kbid,
        KnowledgeBaseDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { KBID = kbid }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class KnowledgeBaseServiceWithRawResponse : IKnowledgeBaseServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IKnowledgeBaseServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new KnowledgeBaseServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public KnowledgeBaseServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;

        _documents = new(() => new DocumentServiceWithRawResponse(client));
    }

    readonly Lazy<IDocumentServiceWithRawResponse> _documents;
    public IDocumentServiceWithRawResponse Documents
    {
        get { return _documents.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KnowledgeBaseCreateResponse>> Create(
        KnowledgeBaseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<KnowledgeBaseCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var knowledgeBase = await response
                    .Deserialize<KnowledgeBaseCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    knowledgeBase.Validate();
                }
                return knowledgeBase;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<KnowledgeBaseCreateResponse>> Create(
        string senderID,
        KnowledgeBaseCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KnowledgeBaseRetrieveResponse>> Retrieve(
        KnowledgeBaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.KBID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.KBID' cannot be null");
        }

        HttpRequest<KnowledgeBaseRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var knowledgeBase = await response
                    .Deserialize<KnowledgeBaseRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    knowledgeBase.Validate();
                }
                return knowledgeBase;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<KnowledgeBaseRetrieveResponse>> Retrieve(
        string kbid,
        KnowledgeBaseRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { KBID = kbid }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KnowledgeBaseUpdateResponse>> Update(
        KnowledgeBaseUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.KBID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.KBID' cannot be null");
        }

        HttpRequest<KnowledgeBaseUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var knowledgeBase = await response
                    .Deserialize<KnowledgeBaseUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    knowledgeBase.Validate();
                }
                return knowledgeBase;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<KnowledgeBaseUpdateResponse>> Update(
        string kbid,
        KnowledgeBaseUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { KBID = kbid }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<KnowledgeBaseListPage>> List(
        KnowledgeBaseListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<KnowledgeBaseListParams> request = new()
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
                    .Deserialize<KnowledgeBaseListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new KnowledgeBaseListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<KnowledgeBaseListPage>> List(
        string senderID,
        KnowledgeBaseListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        KnowledgeBaseDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.KBID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.KBID' cannot be null");
        }

        HttpRequest<KnowledgeBaseDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string kbid,
        KnowledgeBaseDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { KBID = kbid }, cancellationToken);
    }
}
