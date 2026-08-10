using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Broadcasts.Contacts;

namespace Zavudev.Services.Broadcasts;

/// <inheritdoc/>
public sealed class ContactService : IContactService
{
    readonly Lazy<IContactServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IContactServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IContactService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ContactService(this._client.WithOptions(modifier));
    }

    public ContactService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ContactServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ContactListPage> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ContactListPage> List(
        string broadcastID,
        ContactListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ContactAddResponse> Add(
        ContactAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ContactAddResponse> Add(
        string broadcastID,
        ContactAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Remove(
        ContactRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Remove(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Remove(
        string contactID,
        ContactRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Remove(parameters with { ContactID = contactID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ContactServiceWithRawResponse : IContactServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IContactServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ContactServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ContactServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ContactListPage>> List(
        ContactListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<ContactListParams> request = new()
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
                    .Deserialize<ContactListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ContactListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ContactListPage>> List(
        string broadcastID,
        ContactListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ContactAddResponse>> Add(
        ContactAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BroadcastID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BroadcastID' cannot be null");
        }

        HttpRequest<ContactAddParams> request = new()
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
                    .Deserialize<ContactAddResponse>(token)
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
    public Task<HttpResponse<ContactAddResponse>> Add(
        string broadcastID,
        ContactAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { BroadcastID = broadcastID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        ContactRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ContactID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ContactID' cannot be null");
        }

        HttpRequest<ContactRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        string contactID,
        ContactRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { ContactID = contactID }, cancellationToken);
    }
}
