using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Functions.Secrets;

namespace Zavudev.Services.Functions;

/// <inheritdoc/>
public sealed class SecretService : ISecretService
{
    readonly Lazy<ISecretServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISecretServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public ISecretService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SecretService(this._client.WithOptions(modifier));
    }

    public SecretService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SecretServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<SecretListResponse> List(
        SecretListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SecretListResponse> List(
        string functionID,
        SecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<JsonElement> Set(
        SecretSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Set(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<JsonElement> Set(
        string key,
        SecretSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Set(parameters with { Key = key }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Unset(SecretUnsetParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Unset(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Unset(
        string key,
        SecretUnsetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Unset(parameters with { Key = key }, cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class SecretServiceWithRawResponse : ISecretServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISecretServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SecretServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SecretServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SecretListResponse>> List(
        SecretListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<SecretListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var secrets = await response
                    .Deserialize<SecretListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    secrets.Validate();
                }
                return secrets;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SecretListResponse>> List(
        string functionID,
        SecretListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<JsonElement>> Set(
        SecretSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Key == null)
        {
            throw new ZavudevInvalidDataException("'parameters.Key' cannot be null");
        }

        HttpRequest<SecretSetParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                return await response.Deserialize<JsonElement>(token).ConfigureAwait(false);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<JsonElement>> Set(
        string key,
        SecretSetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Set(parameters with { Key = key }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unset(
        SecretUnsetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.Key == null)
        {
            throw new ZavudevInvalidDataException("'parameters.Key' cannot be null");
        }

        HttpRequest<SecretUnsetParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unset(
        string key,
        SecretUnsetParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unset(parameters with { Key = key }, cancellationToken);
    }
}
