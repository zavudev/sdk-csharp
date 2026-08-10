using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.SubAccounts;
using Zavudev.Services.SubAccounts;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class SubAccountService : ISubAccountService
{
    readonly Lazy<ISubAccountServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubAccountServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public ISubAccountService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubAccountService(this._client.WithOptions(modifier));
    }

    public SubAccountService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SubAccountServiceWithRawResponse(client.WithRawResponse));
        _apiKeys = new(() => new ApiKeyService(client));
    }

    readonly Lazy<IApiKeyService> _apiKeys;
    public IApiKeyService ApiKeys
    {
        get { return _apiKeys.Value; }
    }

    /// <inheritdoc/>
    public async Task<SubAccountCreateResponse> Create(
        SubAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubAccountRetrieveResponse> Retrieve(
        SubAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubAccountRetrieveResponse> Retrieve(
        string id,
        SubAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubAccountUpdateResponse> Update(
        SubAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubAccountUpdateResponse> Update(
        string id,
        SubAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubAccountListPage> List(
        SubAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubAccountDeactivateResponse> Deactivate(
        SubAccountDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Deactivate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubAccountDeactivateResponse> Deactivate(
        string id,
        SubAccountDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubAccountGetBalanceResponse> GetBalance(
        SubAccountGetBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetBalance(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubAccountGetBalanceResponse> GetBalance(
        string id,
        SubAccountGetBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetBalance(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SubAccountServiceWithRawResponse : ISubAccountServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubAccountServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubAccountServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubAccountServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;

        _apiKeys = new(() => new ApiKeyServiceWithRawResponse(client));
    }

    readonly Lazy<IApiKeyServiceWithRawResponse> _apiKeys;
    public IApiKeyServiceWithRawResponse ApiKeys
    {
        get { return _apiKeys.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubAccountCreateResponse>> Create(
        SubAccountCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubAccountCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subAccount = await response
                    .Deserialize<SubAccountCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subAccount.Validate();
                }
                return subAccount;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubAccountRetrieveResponse>> Retrieve(
        SubAccountRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SubAccountRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subAccount = await response
                    .Deserialize<SubAccountRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subAccount.Validate();
                }
                return subAccount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubAccountRetrieveResponse>> Retrieve(
        string id,
        SubAccountRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubAccountUpdateResponse>> Update(
        SubAccountUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SubAccountUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subAccount = await response
                    .Deserialize<SubAccountUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subAccount.Validate();
                }
                return subAccount;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubAccountUpdateResponse>> Update(
        string id,
        SubAccountUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubAccountListPage>> List(
        SubAccountListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubAccountListParams> request = new()
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
                    .Deserialize<SubAccountListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SubAccountListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubAccountDeactivateResponse>> Deactivate(
        SubAccountDeactivateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SubAccountDeactivateParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SubAccountDeactivateResponse>(token)
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
    public Task<HttpResponse<SubAccountDeactivateResponse>> Deactivate(
        string id,
        SubAccountDeactivateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deactivate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubAccountGetBalanceResponse>> GetBalance(
        SubAccountGetBalanceParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SubAccountGetBalanceParams> request = new()
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
                    .Deserialize<SubAccountGetBalanceResponse>(token)
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
    public Task<HttpResponse<SubAccountGetBalanceResponse>> GetBalance(
        string id,
        SubAccountGetBalanceParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetBalance(parameters with { ID = id }, cancellationToken);
    }
}
