using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Addresses;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class AddressService : IAddressService
{
    readonly Lazy<IAddressServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAddressServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IAddressService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddressService(this._client.WithOptions(modifier));
    }

    public AddressService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AddressServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AddressCreateResponse> Create(
        AddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AddressRetrieveResponse> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddressRetrieveResponse> Retrieve(
        string addressID,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AddressID = addressID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddressListPage> List(
        AddressListParams? parameters = null,
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
        AddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string addressID,
        AddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { AddressID = addressID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AddressServiceWithRawResponse : IAddressServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAddressServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddressServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AddressServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddressCreateResponse>> Create(
        AddressCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AddressCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var address = await response
                    .Deserialize<AddressCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    address.Validate();
                }
                return address;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        AddressRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AddressID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.AddressID' cannot be null");
        }

        HttpRequest<AddressRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var address = await response
                    .Deserialize<AddressRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    address.Validate();
                }
                return address;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddressRetrieveResponse>> Retrieve(
        string addressID,
        AddressRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { AddressID = addressID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddressListPage>> List(
        AddressListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AddressListParams> request = new()
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
                    .Deserialize<AddressListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AddressListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        AddressDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AddressID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.AddressID' cannot be null");
        }

        HttpRequest<AddressDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string addressID,
        AddressDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { AddressID = addressID }, cancellationToken);
    }
}
