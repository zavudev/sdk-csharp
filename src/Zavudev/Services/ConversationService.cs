using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Conversations;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class ConversationService : IConversationService
{
    readonly Lazy<IConversationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IConversationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IConversationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ConversationService(this._client.WithOptions(modifier));
    }

    public ConversationService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new ConversationServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<ConversationRetrieveResponse> Retrieve(
        ConversationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ConversationRetrieveResponse> Retrieve(
        string conversationID,
        ConversationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ConversationID = conversationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ConversationListPage> List(
        ConversationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ConversationListMessagesPage> ListMessages(
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListMessages(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ConversationListMessagesPage> ListMessages(
        string conversationID,
        ConversationListMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListMessages(
            parameters with
            {
                ConversationID = conversationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<ConversationMarkAsReadResponse> MarkAsRead(
        ConversationMarkAsReadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.MarkAsRead(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ConversationMarkAsReadResponse> MarkAsRead(
        string conversationID,
        ConversationMarkAsReadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.MarkAsRead(
            parameters with
            {
                ConversationID = conversationID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class ConversationServiceWithRawResponse : IConversationServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IConversationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ConversationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ConversationServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationRetrieveResponse>> Retrieve(
        ConversationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConversationID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ConversationID' cannot be null");
        }

        HttpRequest<ConversationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var conversation = await response
                    .Deserialize<ConversationRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    conversation.Validate();
                }
                return conversation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ConversationRetrieveResponse>> Retrieve(
        string conversationID,
        ConversationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(
            parameters with
            {
                ConversationID = conversationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationListPage>> List(
        ConversationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<ConversationListParams> request = new()
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
                    .Deserialize<ConversationListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ConversationListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationListMessagesPage>> ListMessages(
        ConversationListMessagesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConversationID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ConversationID' cannot be null");
        }

        HttpRequest<ConversationListMessagesParams> request = new()
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
                    .Deserialize<ConversationListMessagesPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ConversationListMessagesPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ConversationListMessagesPage>> ListMessages(
        string conversationID,
        ConversationListMessagesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListMessages(
            parameters with
            {
                ConversationID = conversationID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ConversationMarkAsReadResponse>> MarkAsRead(
        ConversationMarkAsReadParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ConversationID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ConversationID' cannot be null");
        }

        HttpRequest<ConversationMarkAsReadParams> request = new()
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
                    .Deserialize<ConversationMarkAsReadResponse>(token)
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
    public Task<HttpResponse<ConversationMarkAsReadResponse>> MarkAsRead(
        string conversationID,
        ConversationMarkAsReadParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.MarkAsRead(
            parameters with
            {
                ConversationID = conversationID,
            },
            cancellationToken
        );
    }
}
