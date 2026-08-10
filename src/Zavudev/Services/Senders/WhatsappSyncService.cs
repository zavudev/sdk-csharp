using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.WhatsappSync;

namespace Zavudev.Services.Senders;

/// <inheritdoc/>
public sealed class WhatsappSyncService : IWhatsappSyncService
{
    readonly Lazy<IWhatsappSyncServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWhatsappSyncServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IWhatsappSyncService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WhatsappSyncService(this._client.WithOptions(modifier));
    }

    public WhatsappSyncService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new WhatsappSyncServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<WhatsappSyncRetrieveResponse> Retrieve(
        WhatsappSyncRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WhatsappSyncRetrieveResponse> Retrieve(
        string senderID,
        WhatsappSyncRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WhatsappSyncStartContactsSyncResponse> StartContactsSync(
        WhatsappSyncStartContactsSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.StartContactsSync(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WhatsappSyncStartContactsSyncResponse> StartContactsSync(
        string senderID,
        WhatsappSyncStartContactsSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartContactsSync(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WhatsappSyncStartHistorySyncResponse> StartHistorySync(
        WhatsappSyncStartHistorySyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.StartHistorySync(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WhatsappSyncStartHistorySyncResponse> StartHistorySync(
        string senderID,
        WhatsappSyncStartHistorySyncParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartHistorySync(parameters with { SenderID = senderID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WhatsappSyncServiceWithRawResponse : IWhatsappSyncServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWhatsappSyncServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new WhatsappSyncServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WhatsappSyncServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WhatsappSyncRetrieveResponse>> Retrieve(
        WhatsappSyncRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<WhatsappSyncRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var whatsappSync = await response
                    .Deserialize<WhatsappSyncRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    whatsappSync.Validate();
                }
                return whatsappSync;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WhatsappSyncRetrieveResponse>> Retrieve(
        string senderID,
        WhatsappSyncRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WhatsappSyncStartContactsSyncResponse>> StartContactsSync(
        WhatsappSyncStartContactsSyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<WhatsappSyncStartContactsSyncParams> request = new()
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
                    .Deserialize<WhatsappSyncStartContactsSyncResponse>(token)
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
    public Task<HttpResponse<WhatsappSyncStartContactsSyncResponse>> StartContactsSync(
        string senderID,
        WhatsappSyncStartContactsSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartContactsSync(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WhatsappSyncStartHistorySyncResponse>> StartHistorySync(
        WhatsappSyncStartHistorySyncParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<WhatsappSyncStartHistorySyncParams> request = new()
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
                    .Deserialize<WhatsappSyncStartHistorySyncResponse>(token)
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
    public Task<HttpResponse<WhatsappSyncStartHistorySyncResponse>> StartHistorySync(
        string senderID,
        WhatsappSyncStartHistorySyncParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.StartHistorySync(parameters with { SenderID = senderID }, cancellationToken);
    }
}
