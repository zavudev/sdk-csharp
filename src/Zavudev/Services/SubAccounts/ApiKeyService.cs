using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.SubAccounts.ApiKeys;

namespace Zavudev.Services.SubAccounts;

/// <inheritdoc/>
public sealed class ApiKeyService : IApiKeyService
{
    readonly Lazy<IApiKeyServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IApiKeyServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IApiKeyService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ApiKeyService(this._client.WithOptions(modifier));
    }

    public ApiKeyService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ApiKeyServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ApiKeyCreateResponse> Create(
        ApiKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiKeyCreateResponse> Create(
        string id,
        ApiKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ApiKeyListResponse> List(
        ApiKeyListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ApiKeyListResponse> List(
        string id,
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Revoke(ApiKeyRevokeParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Revoke(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Revoke(
        string keyID,
        ApiKeyRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Revoke(parameters with { KeyID = keyID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class ApiKeyServiceWithRawResponse : IApiKeyServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IApiKeyServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ApiKeyServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ApiKeyServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiKeyCreateResponse>> Create(
        ApiKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ApiKeyCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiKey = await response
                    .Deserialize<ApiKeyCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiKey.Validate();
                }
                return apiKey;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiKeyCreateResponse>> Create(
        string id,
        ApiKeyCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ApiKeyListResponse>> List(
        ApiKeyListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<ApiKeyListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var apiKeys = await response
                    .Deserialize<ApiKeyListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    apiKeys.Validate();
                }
                return apiKeys;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ApiKeyListResponse>> List(
        string id,
        ApiKeyListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Revoke(
        ApiKeyRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.KeyID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.KeyID' cannot be null");
        }

        HttpRequest<ApiKeyRevokeParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Revoke(
        string keyID,
        ApiKeyRevokeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Revoke(parameters with { KeyID = keyID }, cancellationToken);
    }
}
