using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent.Flows;

namespace Zavudev.Services.Senders.Agent;

/// <inheritdoc/>
public sealed class FlowService : IFlowService
{
    readonly Lazy<IFlowServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFlowServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IFlowService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FlowService(this._client.WithOptions(modifier));
    }

    public FlowService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FlowServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<FlowCreateResponse> Create(
        FlowCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FlowCreateResponse> Create(
        string senderID,
        FlowCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FlowRetrieveResponse> Retrieve(
        FlowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FlowRetrieveResponse> Retrieve(
        string flowID,
        FlowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { FlowID = flowID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FlowUpdateResponse> Update(
        FlowUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FlowUpdateResponse> Update(
        string flowID,
        FlowUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { FlowID = flowID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FlowListPage> List(
        FlowListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FlowListPage> List(
        string senderID,
        FlowListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(FlowDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string flowID,
        FlowDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { FlowID = flowID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FlowDuplicateResponse> Duplicate(
        FlowDuplicateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Duplicate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FlowDuplicateResponse> Duplicate(
        string flowID,
        FlowDuplicateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Duplicate(parameters with { FlowID = flowID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FlowServiceWithRawResponse : IFlowServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFlowServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FlowServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FlowServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FlowCreateResponse>> Create(
        FlowCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<FlowCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var flow = await response
                    .Deserialize<FlowCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    flow.Validate();
                }
                return flow;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FlowCreateResponse>> Create(
        string senderID,
        FlowCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FlowRetrieveResponse>> Retrieve(
        FlowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FlowID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FlowID' cannot be null");
        }

        HttpRequest<FlowRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var flow = await response
                    .Deserialize<FlowRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    flow.Validate();
                }
                return flow;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FlowRetrieveResponse>> Retrieve(
        string flowID,
        FlowRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { FlowID = flowID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FlowUpdateResponse>> Update(
        FlowUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FlowID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FlowID' cannot be null");
        }

        HttpRequest<FlowUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var flow = await response
                    .Deserialize<FlowUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    flow.Validate();
                }
                return flow;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FlowUpdateResponse>> Update(
        string flowID,
        FlowUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { FlowID = flowID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FlowListPage>> List(
        FlowListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<FlowListParams> request = new()
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
                    .Deserialize<FlowListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new FlowListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FlowListPage>> List(
        string senderID,
        FlowListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        FlowDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FlowID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FlowID' cannot be null");
        }

        HttpRequest<FlowDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string flowID,
        FlowDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { FlowID = flowID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FlowDuplicateResponse>> Duplicate(
        FlowDuplicateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FlowID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FlowID' cannot be null");
        }

        HttpRequest<FlowDuplicateParams> request = new()
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
                    .Deserialize<FlowDuplicateResponse>(token)
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
    public Task<HttpResponse<FlowDuplicateResponse>> Duplicate(
        string flowID,
        FlowDuplicateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Duplicate(parameters with { FlowID = flowID }, cancellationToken);
    }
}
