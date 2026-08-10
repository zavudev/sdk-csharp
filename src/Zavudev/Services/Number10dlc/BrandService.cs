using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Number10dlc.Brands;

namespace Zavudev.Services.Number10dlc;

/// <inheritdoc/>
public sealed class BrandService : IBrandService
{
    readonly Lazy<IBrandServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBrandServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IBrandService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrandService(this._client.WithOptions(modifier));
    }

    public BrandService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BrandServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<BrandCreateResponse> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BrandRetrieveResponse> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BrandRetrieveResponse> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BrandUpdateResponse> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BrandUpdateResponse> Update(
        string brandID,
        BrandUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BrandListPage> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(BrandDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { BrandID = brandID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BrandListUseCasesResponse> ListUseCases(
        BrandListUseCasesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListUseCases(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<BrandSubmitResponse> Submit(
        BrandSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Submit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BrandSubmitResponse> Submit(
        string brandID,
        BrandSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<BrandSyncStatusResponse> SyncStatus(
        BrandSyncStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SyncStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<BrandSyncStatusResponse> SyncStatus(
        string brandID,
        BrandSyncStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SyncStatus(parameters with { BrandID = brandID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class BrandServiceWithRawResponse : IBrandServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBrandServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BrandServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BrandServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandCreateResponse>> Create(
        BrandCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<BrandCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var brand = await response
                    .Deserialize<BrandCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    brand.Validate();
                }
                return brand;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandRetrieveResponse>> Retrieve(
        BrandRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BrandID' cannot be null");
        }

        HttpRequest<BrandRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var brand = await response
                    .Deserialize<BrandRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    brand.Validate();
                }
                return brand;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BrandRetrieveResponse>> Retrieve(
        string brandID,
        BrandRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandUpdateResponse>> Update(
        BrandUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BrandID' cannot be null");
        }

        HttpRequest<BrandUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var brand = await response
                    .Deserialize<BrandUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    brand.Validate();
                }
                return brand;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<BrandUpdateResponse>> Update(
        string brandID,
        BrandUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandListPage>> List(
        BrandListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BrandListParams> request = new()
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
                    .Deserialize<BrandListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new BrandListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        BrandDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BrandID' cannot be null");
        }

        HttpRequest<BrandDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string brandID,
        BrandDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandListUseCasesResponse>> ListUseCases(
        BrandListUseCasesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<BrandListUseCasesParams> request = new()
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
                    .Deserialize<BrandListUseCasesResponse>(token)
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
    public async Task<HttpResponse<BrandSubmitResponse>> Submit(
        BrandSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BrandID' cannot be null");
        }

        HttpRequest<BrandSubmitParams> request = new()
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
                    .Deserialize<BrandSubmitResponse>(token)
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
    public Task<HttpResponse<BrandSubmitResponse>> Submit(
        string brandID,
        BrandSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { BrandID = brandID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<BrandSyncStatusResponse>> SyncStatus(
        BrandSyncStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.BrandID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.BrandID' cannot be null");
        }

        HttpRequest<BrandSyncStatusParams> request = new()
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
                    .Deserialize<BrandSyncStatusResponse>(token)
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
    public Task<HttpResponse<BrandSyncStatusResponse>> SyncStatus(
        string brandID,
        BrandSyncStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SyncStatus(parameters with { BrandID = brandID }, cancellationToken);
    }
}
