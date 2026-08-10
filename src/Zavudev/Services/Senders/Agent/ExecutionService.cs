using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent.Executions;

namespace Zavudev.Services.Senders.Agent;

/// <inheritdoc/>
public sealed class ExecutionService : IExecutionService
{
    readonly Lazy<IExecutionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IExecutionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IExecutionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExecutionService(this._client.WithOptions(modifier));
    }

    public ExecutionService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ExecutionServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ExecutionRetrieveResponse> Retrieve(
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExecutionRetrieveResponse> Retrieve(
        string executionID,
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ExecutionID = executionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExecutionListPage> List(
        ExecutionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ExecutionListPage> List(
        string senderID,
        ExecutionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SenderID = senderID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ExecutionServiceWithRawResponse : IExecutionServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IExecutionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ExecutionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ExecutionServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExecutionRetrieveResponse>> Retrieve(
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ExecutionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ExecutionID' cannot be null");
        }

        HttpRequest<ExecutionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var execution = await response
                    .Deserialize<ExecutionRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    execution.Validate();
                }
                return execution;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExecutionRetrieveResponse>> Retrieve(
        string executionID,
        ExecutionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ExecutionID = executionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ExecutionListPage>> List(
        ExecutionListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<ExecutionListParams> request = new()
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
                    .Deserialize<ExecutionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ExecutionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ExecutionListPage>> List(
        string senderID,
        ExecutionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SenderID = senderID }, cancellationToken);
    }
}
