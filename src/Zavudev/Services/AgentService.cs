using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Agents;
using Agents = Zavudev.Services.Agents;

namespace Zavudev.Services;

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
        _senders = new(() => new Agents::SenderService(client));
    }

    readonly Lazy<Agents::ISenderService> _senders;
    public Agents::ISenderService Senders
    {
        get { return _senders.Value; }
    }

    /// <inheritdoc/>
    public async Task<AgentCreateResponse> Create(
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
    public async Task<AgentRetrieveResponse> Retrieve(
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
    public Task<AgentRetrieveResponse> Retrieve(
        string agentID,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AgentID = agentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AgentUpdateResponse> Update(
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
    public Task<AgentUpdateResponse> Update(
        string agentID,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { AgentID = agentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AgentListPage> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(AgentDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string agentID,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { AgentID = agentID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AgentListVoicesResponse> ListVoices(
        AgentListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListVoices(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AgentTestResponse> Test(
        AgentTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Test(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AgentTestResponse> Test(
        string agentID,
        AgentTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Test(parameters with { AgentID = agentID }, cancellationToken);
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

        _senders = new(() => new Agents::SenderServiceWithRawResponse(client));
    }

    readonly Lazy<Agents::ISenderServiceWithRawResponse> _senders;
    public Agents::ISenderServiceWithRawResponse Senders
    {
        get { return _senders.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentCreateResponse>> Create(
        AgentCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
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
                var agent = await response
                    .Deserialize<AgentCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agent.Validate();
                }
                return agent;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentRetrieveResponse>> Retrieve(
        AgentRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AgentID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.AgentID' cannot be null");
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
                var agent = await response
                    .Deserialize<AgentRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agent.Validate();
                }
                return agent;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AgentRetrieveResponse>> Retrieve(
        string agentID,
        AgentRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AgentID = agentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentUpdateResponse>> Update(
        AgentUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AgentID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.AgentID' cannot be null");
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
                var agent = await response
                    .Deserialize<AgentUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agent.Validate();
                }
                return agent;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AgentUpdateResponse>> Update(
        string agentID,
        AgentUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { AgentID = agentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentListPage>> List(
        AgentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AgentListParams> request = new()
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
                    .Deserialize<AgentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AgentListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        AgentDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AgentID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.AgentID' cannot be null");
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
        string agentID,
        AgentDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { AgentID = agentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentListVoicesResponse>> ListVoices(
        AgentListVoicesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AgentListVoicesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AgentListVoicesResponse>(token)
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
    public async Task<HttpResponse<AgentTestResponse>> Test(
        AgentTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AgentID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.AgentID' cannot be null");
        }

        HttpRequest<AgentTestParams> request = new()
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
                    .Deserialize<AgentTestResponse>(token)
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
    public Task<HttpResponse<AgentTestResponse>> Test(
        string agentID,
        AgentTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Test(parameters with { AgentID = agentID }, cancellationToken);
    }
}
