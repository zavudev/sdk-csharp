using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Telegram;

namespace Zavudev.Services.Senders;

/// <inheritdoc/>
public sealed class TelegramService : ITelegramService
{
    readonly Lazy<ITelegramServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITelegramServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public ITelegramService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TelegramService(this._client.WithOptions(modifier));
    }

    public TelegramService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TelegramServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TelegramConnectResponse> Connect(
        TelegramConnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Connect(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TelegramConnectResponse> Connect(
        string senderID,
        TelegramConnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Connect(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Disconnect(
        TelegramDisconnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Disconnect(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Disconnect(
        string senderID,
        TelegramDisconnectParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Disconnect(parameters with { SenderID = senderID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TelegramServiceWithRawResponse : ITelegramServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITelegramServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TelegramServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TelegramServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TelegramConnectResponse>> Connect(
        TelegramConnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<TelegramConnectParams> request = new()
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
                    .Deserialize<TelegramConnectResponse>(token)
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
    public Task<HttpResponse<TelegramConnectResponse>> Connect(
        string senderID,
        TelegramConnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Connect(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Disconnect(
        TelegramDisconnectParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<TelegramDisconnectParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Disconnect(
        string senderID,
        TelegramDisconnectParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Disconnect(parameters with { SenderID = senderID }, cancellationToken);
    }
}
