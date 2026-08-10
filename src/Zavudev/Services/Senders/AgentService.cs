using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent;
using Zavudev.Services.Senders.Agent;

namespace Zavudev.Services.Senders;

/// <inheritdoc/>
public sealed class AgentService : IAgentService
{
    readonly Lazy<IAgentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAgentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IAgentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentService(this._client.WithOptions(modifier));
    }

    public AgentService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AgentServiceWithRawResponse(client.WithRawResponse));
        _executions = new(() => new ExecutionService(client));
        _flows = new(() => new FlowService(client));
        _tools = new(() => new ToolService(client));
        _knowledgeBases = new(() => new KnowledgeBaseService(client));
    }

    readonly Lazy<IExecutionService> _executions;
    public IExecutionService Executions
    {
        get { return _executions.Value; }
    }

    readonly Lazy<IFlowService> _flows;
    public IFlowService Flows
    {
        get { return _flows.Value; }
    }

    readonly Lazy<IToolService> _tools;
    public IToolService Tools
    {
        get { return _tools.Value; }
    }

    readonly Lazy<IKnowledgeBaseService> _knowledgeBases;
    public IKnowledgeBaseService KnowledgeBases
    {
        get { return _knowledgeBases.Value; }
    }

    /// <inheritdoc/>
    public async Task<AgentResponse> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AgentResponse> Create(
        string senderID,
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AgentResponse> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AgentResponse> Retrieve(
        string senderID,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AgentResponse> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AgentResponse> Update(
        string senderID,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(AgentDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string senderID,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { SenderID = senderID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AgentStats> Stats(
        AgentStatsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Stats(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AgentStats> Stats(
        string senderID,
        AgentStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Stats(parameters with { SenderID = senderID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AgentServiceWithRawResponse : IAgentServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAgentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AgentServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;

        _executions = new(() => new ExecutionServiceWithRawResponse(client));
        _flows = new(() => new FlowServiceWithRawResponse(client));
        _tools = new(() => new ToolServiceWithRawResponse(client));
        _knowledgeBases = new(() => new KnowledgeBaseServiceWithRawResponse(client));
    }

    readonly Lazy<IExecutionServiceWithRawResponse> _executions;
    public IExecutionServiceWithRawResponse Executions
    {
        get { return _executions.Value; }
    }

    readonly Lazy<IFlowServiceWithRawResponse> _flows;
    public IFlowServiceWithRawResponse Flows
    {
        get { return _flows.Value; }
    }

    readonly Lazy<IToolServiceWithRawResponse> _tools;
    public IToolServiceWithRawResponse Tools
    {
        get { return _tools.Value; }
    }

    readonly Lazy<IKnowledgeBaseServiceWithRawResponse> _knowledgeBases;
    public IKnowledgeBaseServiceWithRawResponse KnowledgeBases
    {
        get { return _knowledgeBases.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentResponse>> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<AgentCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var agentResponse = await response
                    .Deserialize<AgentResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agentResponse.Validate();
                }
                return agentResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AgentResponse>> Create(
        string senderID,
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentResponse>> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<AgentRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var agentResponse = await response
                    .Deserialize<AgentResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agentResponse.Validate();
                }
                return agentResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AgentResponse>> Retrieve(
        string senderID,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentResponse>> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<AgentUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var agentResponse = await response
                    .Deserialize<AgentResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agentResponse.Validate();
                }
                return agentResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AgentResponse>> Update(
        string senderID,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        AgentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<AgentDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string senderID,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentStats>> Stats(
        AgentStatsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<AgentStatsParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var agentStats = await response
                    .Deserialize<AgentStats>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agentStats.Validate();
                }
                return agentStats;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AgentStats>> Stats(
        string senderID,
        AgentStatsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Stats(parameters with { SenderID = senderID }, cancellationToken);
    }
}
