using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Contacts;
using Zavudev.Services.Contacts;

namespace Zavudev.Services;

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
        _channels = new(() => new ChannelService(client));
    }

    readonly Lazy<IChannelService> _channels;
    public IChannelService Channels
    {
        get { return _channels.Value; }
    }

    /// <inheritdoc/>
    public async Task<Contact> Create(
        ContactCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Contact> Retrieve(
        ContactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Contact> Retrieve(
        string contactID,
        ContactRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ContactID = contactID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Contact> Update(
        ContactUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Contact> Update(
        string contactID,
        ContactUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ContactID = contactID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ContactListPage> List(
        ContactListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(
        ContactDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string contactID,
        ContactDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { ContactID = contactID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Contact> Merge(
        ContactMergeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Merge(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Contact> Merge(
        string contactID,
        ContactMergeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Merge(parameters with { ContactID = contactID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Contact> RetrieveByPhone(
        ContactRetrieveByPhoneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveByPhone(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Contact> RetrieveByPhone(
        string phoneNumber,
        ContactRetrieveByPhoneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveByPhone(
            parameters with
            {
                PhoneNumber = phoneNumber,
            },
            cancellationToken
        );
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

        _channels = new(() => new ChannelServiceWithRawResponse(client));
    }

    readonly Lazy<IChannelServiceWithRawResponse> _channels;
    public IChannelServiceWithRawResponse Channels
    {
        get { return _channels.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Contact>> Create(
        ContactCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<ContactCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var contact = await response.Deserialize<Contact>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    contact.Validate();
                }
                return contact;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Contact>> Retrieve(
        ContactRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ContactID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ContactID' cannot be null");
        }

        HttpRequest<ContactRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var contact = await response.Deserialize<Contact>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    contact.Validate();
                }
                return contact;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Contact>> Retrieve(
        string contactID,
        ContactRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ContactID = contactID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Contact>> Update(
        ContactUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ContactID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ContactID' cannot be null");
        }

        HttpRequest<ContactUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var contact = await response.Deserialize<Contact>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    contact.Validate();
                }
                return contact;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Contact>> Update(
        string contactID,
        ContactUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ContactID = contactID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ContactListPage>> List(
        ContactListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

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
    public Task<HttpResponse> Delete(
        ContactDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ContactID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ContactID' cannot be null");
        }

        HttpRequest<ContactDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string contactID,
        ContactDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { ContactID = contactID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Contact>> Merge(
        ContactMergeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ContactID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ContactID' cannot be null");
        }

        HttpRequest<ContactMergeParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var contact = await response.Deserialize<Contact>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    contact.Validate();
                }
                return contact;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Contact>> Merge(
        string contactID,
        ContactMergeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Merge(parameters with { ContactID = contactID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Contact>> RetrieveByPhone(
        ContactRetrieveByPhoneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumber == null)
        {
            throw new ZavudevInvalidDataException("'parameters.PhoneNumber' cannot be null");
        }

        HttpRequest<ContactRetrieveByPhoneParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var contact = await response.Deserialize<Contact>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    contact.Validate();
                }
                return contact;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Contact>> RetrieveByPhone(
        string phoneNumber,
        ContactRetrieveByPhoneParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveByPhone(
            parameters with
            {
                PhoneNumber = phoneNumber,
            },
            cancellationToken
        );
    }
}
