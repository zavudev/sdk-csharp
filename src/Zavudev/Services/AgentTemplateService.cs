using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.AgentTemplates;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class AgentTemplateService : IAgentTemplateService
{
    readonly Lazy<IAgentTemplateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAgentTemplateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IAgentTemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AgentTemplateService(this._client.WithOptions(modifier));
    }

    public AgentTemplateService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AgentTemplateServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AgentTemplateRetrieveResponse> Retrieve(
        AgentTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AgentTemplateRetrieveResponse> Retrieve(
        string templateID,
        AgentTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AgentTemplateListResponse> List(
        AgentTemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AgentTemplateServiceWithRawResponse : IAgentTemplateServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAgentTemplateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AgentTemplateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AgentTemplateServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentTemplateRetrieveResponse>> Retrieve(
        AgentTemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<AgentTemplateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var agentTemplate = await response
                    .Deserialize<AgentTemplateRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agentTemplate.Validate();
                }
                return agentTemplate;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AgentTemplateRetrieveResponse>> Retrieve(
        string templateID,
        AgentTemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AgentTemplateListResponse>> List(
        AgentTemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AgentTemplateListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var agentTemplates = await response
                    .Deserialize<AgentTemplateListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    agentTemplates.Validate();
                }
                return agentTemplates;
            }
        );
    }
}
