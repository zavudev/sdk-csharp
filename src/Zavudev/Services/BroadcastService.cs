using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Broadcasts;
using Broadcasts = Zavudev.Services.Broadcasts;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class BroadcastService : IBroadcastService
{
    readonly Lazy<IBroadcastServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBroadcastServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IBroadcastService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BroadcastService(this._client.WithOptions(modifier));
    }

    public BroadcastService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BroadcastServiceWithRawResponse(client.WithRawResponse));
        _contacts = new(() => new Broadcasts::ContactService(client));
    }

    readonly Lazy<Broadcasts::IContactService> _contacts;
    public Broadcasts::IContactService Contacts
    {
        get { return _contacts.Value; }
    }

    /// <inheritdoc/>
    public async Task<BroadcastCreateResponse> Create(
        BroadcastCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BroadcastRetrieveResponse> Retrieve(
        BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BroadcastRetrieveResponse> Retrieve(
        string broadcastID,
        BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BroadcastUpdateResponse> Update(
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BroadcastUpdateResponse> Update(
        string broadcastID,
        BroadcastUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BroadcastListPage> List(
        BroadcastListParams? parameters = null,
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
        BroadcastDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string broadcastID,
        BroadcastDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { BroadcastID = broadcastID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BroadcastCancelResponse> Cancel(
        BroadcastCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BroadcastCancelResponse> Cancel(
        string broadcastID,
        BroadcastCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BroadcastEscalateReviewResponse> EscalateReview(
        BroadcastEscalateReviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.EscalateReview(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BroadcastEscalateReviewResponse> EscalateReview(
        string broadcastID,
        BroadcastEscalateReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.EscalateReview(
            parameters with
            {
                BroadcastID = broadcastID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<BroadcastProgress> Progress(
        BroadcastProgressParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Progress(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BroadcastProgress> Progress(
        string broadcastID,
        BroadcastProgressParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Progress(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BroadcastRescheduleResponse> Reschedule(
        BroadcastRescheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Reschedule(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BroadcastRescheduleResponse> Reschedule(
        string broadcastID,
        BroadcastRescheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reschedule(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BroadcastRetryReviewResponse> RetryReview(
        BroadcastRetryReviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetryReview(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BroadcastRetryReviewResponse> RetryReview(
        string broadcastID,
        BroadcastRetryReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetryReview(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BroadcastSendResponse> Send(
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Send(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BroadcastSendResponse> Send(
        string broadcastID,
        BroadcastSendParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Send(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BroadcastServiceWithRawResponse : IBroadcastServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBroadcastServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BroadcastServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BroadcastServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;

        _contacts = new(() => new Broadcasts::ContactServiceWithRawResponse(client));
    }

    readonly Lazy<Broadcasts::IContactServiceWithRawResponse> _contacts;
    public Broadcasts::IContactServiceWithRawResponse Contacts
    {
        get { return _contacts.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastCreateResponse>> Create(
        BroadcastCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BroadcastCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response
                    .Deserialize<BroadcastCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastRetrieveResponse>> Retrieve(
        BroadcastRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response
                    .Deserialize<BroadcastRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BroadcastRetrieveResponse>> Retrieve(
        string broadcastID,
        BroadcastRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastUpdateResponse>> Update(
        BroadcastUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcast = await response
                    .Deserialize<BroadcastUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcast.Validate();
                }
                return broadcast;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BroadcastUpdateResponse>> Update(
        string broadcastID,
        BroadcastUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastListPage>> List(
        BroadcastListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BroadcastListParams> request = new()
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
                    .Deserialize<BroadcastListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BroadcastListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        BroadcastDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string broadcastID,
        BroadcastDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastCancelResponse>> Cancel(
        BroadcastCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastCancelParams> request = new()
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
                    .Deserialize<BroadcastCancelResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BroadcastCancelResponse>> Cancel(
        string broadcastID,
        BroadcastCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastEscalateReviewResponse>> EscalateReview(
        BroadcastEscalateReviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastEscalateReviewParams> request = new()
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
                    .Deserialize<BroadcastEscalateReviewResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BroadcastEscalateReviewResponse>> EscalateReview(
        string broadcastID,
        BroadcastEscalateReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.EscalateReview(
            parameters with
            {
                BroadcastID = broadcastID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastProgress>> Progress(
        BroadcastProgressParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastProgressParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var broadcastProgress = await response
                    .Deserialize<BroadcastProgress>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    broadcastProgress.Validate();
                }
                return broadcastProgress;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BroadcastProgress>> Progress(
        string broadcastID,
        BroadcastProgressParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Progress(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastRescheduleResponse>> Reschedule(
        BroadcastRescheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastRescheduleParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<BroadcastRescheduleResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BroadcastRescheduleResponse>> Reschedule(
        string broadcastID,
        BroadcastRescheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Reschedule(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastRetryReviewResponse>> RetryReview(
        BroadcastRetryReviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastRetryReviewParams> request = new()
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
                    .Deserialize<BroadcastRetryReviewResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BroadcastRetryReviewResponse>> RetryReview(
        string broadcastID,
        BroadcastRetryReviewParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetryReview(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BroadcastSendResponse>> Send(
        BroadcastSendParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<BroadcastSendParams> request = new()
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
                    .Deserialize<BroadcastSendResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BroadcastSendResponse>> Send(
        string broadcastID,
        BroadcastSendParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Send(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }
}
