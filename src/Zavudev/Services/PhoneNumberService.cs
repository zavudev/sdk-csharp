using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class PhoneNumberService : IPhoneNumberService
{
    readonly Lazy<IPhoneNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IPhoneNumberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PhoneNumberService(this._client.WithOptions(modifier));
    }

    public PhoneNumberService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PhoneNumberServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberRetrieveResponse> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhoneNumberRetrieveResponse> Retrieve(
        string phoneNumberID,
        PhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PhoneNumberID = phoneNumberID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberUpdateResponse> Update(
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhoneNumberUpdateResponse> Update(
        string phoneNumberID,
        PhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PhoneNumberID = phoneNumberID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberListPage> List(
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberPurchaseResponse> Purchase(
        PhoneNumberPurchaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Purchase(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Release(
        PhoneNumberReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Release(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Release(
        string phoneNumberID,
        PhoneNumberReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Release(parameters with { PhoneNumberID = phoneNumberID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberRequirementsResponse> Requirements(
        PhoneNumberRequirementsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Requirements(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberSearchAvailableResponse> SearchAvailable(
        PhoneNumberSearchAvailableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SearchAvailable(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumberServiceWithRawResponse : IPhoneNumberServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        PhoneNumberRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumberID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.PhoneNumberID' cannot be null");
        }

        HttpRequest<PhoneNumberRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var phoneNumber = await response
                    .Deserialize<PhoneNumberRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    phoneNumber.Validate();
                }
                return phoneNumber;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberRetrieveResponse>> Retrieve(
        string phoneNumberID,
        PhoneNumberRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { PhoneNumberID = phoneNumberID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberUpdateResponse>> Update(
        PhoneNumberUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumberID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.PhoneNumberID' cannot be null");
        }

        HttpRequest<PhoneNumberUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var phoneNumber = await response
                    .Deserialize<PhoneNumberUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    phoneNumber.Validate();
                }
                return phoneNumber;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberUpdateResponse>> Update(
        string phoneNumberID,
        PhoneNumberUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { PhoneNumberID = phoneNumberID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberListPage>> List(
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PhoneNumberListParams> request = new()
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
                    .Deserialize<PhoneNumberListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PhoneNumberListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberPurchaseResponse>> Purchase(
        PhoneNumberPurchaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PhoneNumberPurchaseParams> request = new()
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
                    .Deserialize<PhoneNumberPurchaseResponse>(token)
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
    public Task<HttpResponse> Release(
        PhoneNumberReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.PhoneNumberID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.PhoneNumberID' cannot be null");
        }

        HttpRequest<PhoneNumberReleaseParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Release(
        string phoneNumberID,
        PhoneNumberReleaseParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Release(parameters with { PhoneNumberID = phoneNumberID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberRequirementsResponse>> Requirements(
        PhoneNumberRequirementsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PhoneNumberRequirementsParams> request = new()
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
                    .Deserialize<PhoneNumberRequirementsResponse>(token)
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
    public async Task<HttpResponse<PhoneNumberSearchAvailableResponse>> SearchAvailable(
        PhoneNumberSearchAvailableParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PhoneNumberSearchAvailableParams> request = new()
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
                    .Deserialize<PhoneNumberSearchAvailableResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
