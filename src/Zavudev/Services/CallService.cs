using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Calls;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class CallService : ICallService
{
    readonly Lazy<ICallServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICallServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public ICallService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CallService(this._client.WithOptions(modifier));
    }

    public CallService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CallServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CallCreateResponse> Create(
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CallRetrieveResponse> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CallRetrieveResponse> Retrieve(
        string callID,
        CallRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CallID = callID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CallListPage> List(
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CallHangupResponse> Hangup(
        CallHangupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Hangup(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CallHangupResponse> Hangup(
        string callID,
        CallHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Hangup(parameters with { CallID = callID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CallServiceWithRawResponse : ICallServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICallServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CallServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CallServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallCreateResponse>> Create(
        CallCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CallCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var call = await response
                    .Deserialize<CallCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    call.Validate();
                }
                return call;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallRetrieveResponse>> Retrieve(
        CallRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.CallID' cannot be null");
        }

        HttpRequest<CallRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var call = await response
                    .Deserialize<CallRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    call.Validate();
                }
                return call;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CallRetrieveResponse>> Retrieve(
        string callID,
        CallRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CallID = callID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallListPage>> List(
        CallListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CallListParams> request = new()
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
                    .Deserialize<CallListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CallListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CallHangupResponse>> Hangup(
        CallHangupParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CallID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.CallID' cannot be null");
        }

        HttpRequest<CallHangupParams> request = new()
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
                    .Deserialize<CallHangupResponse>(token)
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
    public Task<HttpResponse<CallHangupResponse>> Hangup(
        string callID,
        CallHangupParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Hangup(parameters with { CallID = callID }, cancellationToken);
    }
}
