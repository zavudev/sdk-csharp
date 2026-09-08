using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Agents.Senders;

namespace Zavudev.Services.Agents;

/// <inheritdoc/>
public sealed class SenderService : ISenderService
{
    readonly Lazy<ISenderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISenderServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public ISenderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SenderService(this._client.WithOptions(modifier));
    }

    public SenderService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SenderServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SenderConnectResponse> Connect(
        SenderConnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Connect(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SenderConnectResponse> Connect(
        string agentID,
        SenderConnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Connect(parameters with { AgentID = agentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Disconnect(
        SenderDisconnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Disconnect(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Disconnect(
        string senderID,
        SenderDisconnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Disconnect(parameters with { SenderID = senderID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SenderServiceWithRawResponse : ISenderServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISenderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SenderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SenderServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SenderConnectResponse>> Connect(
        SenderConnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AgentID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.AgentID' cannot be null");
        }

        HttpRequest<SenderConnectParams> request = new()
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
                    .Deserialize<SenderConnectResponse>(token)
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
    public Task<HttpResponse<SenderConnectResponse>> Connect(
        string agentID,
        SenderConnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Connect(parameters with { AgentID = agentID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Disconnect(
        SenderDisconnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<SenderDisconnectParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Disconnect(
        string senderID,
        SenderDisconnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Disconnect(parameters with { SenderID = senderID }, cancellationToken);
    }
}
