using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Urls;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class UrlService : IUrlService
{
    readonly Lazy<IUrlServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IUrlServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IUrlService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UrlService(this._client.WithOptions(modifier));
    }

    public UrlService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new UrlServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<UrlEscalateResponse> Escalate(
        UrlEscalateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Escalate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UrlEscalateResponse> Escalate(
        string urlID,
        UrlEscalateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Escalate(parameters with { UrlID = urlID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UrlListVerifiedPage> ListVerified(
        UrlListVerifiedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListVerified(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<UrlRetrieveDetailsResponse> RetrieveDetails(
        UrlRetrieveDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveDetails(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<UrlRetrieveDetailsResponse> RetrieveDetails(
        string urlID,
        UrlRetrieveDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveDetails(parameters with { UrlID = urlID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<UrlSubmitForVerificationResponse> SubmitForVerification(
        UrlSubmitForVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SubmitForVerification(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class UrlServiceWithRawResponse : IUrlServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IUrlServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new UrlServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public UrlServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UrlEscalateResponse>> Escalate(
        UrlEscalateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UrlID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.UrlID' cannot be null");
        }

        HttpRequest<UrlEscalateParams> request = new()
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
                    .Deserialize<UrlEscalateResponse>(token)
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
    public Task<HttpResponse<UrlEscalateResponse>> Escalate(
        string urlID,
        UrlEscalateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Escalate(parameters with { UrlID = urlID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UrlListVerifiedPage>> ListVerified(
        UrlListVerifiedParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<UrlListVerifiedParams> request = new()
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
                    .Deserialize<UrlListVerifiedPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new UrlListVerifiedPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UrlRetrieveDetailsResponse>> RetrieveDetails(
        UrlRetrieveDetailsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.UrlID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.UrlID' cannot be null");
        }

        HttpRequest<UrlRetrieveDetailsParams> request = new()
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
                    .Deserialize<UrlRetrieveDetailsResponse>(token)
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
    public Task<HttpResponse<UrlRetrieveDetailsResponse>> RetrieveDetails(
        string urlID,
        UrlRetrieveDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveDetails(parameters with { UrlID = urlID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<UrlSubmitForVerificationResponse>> SubmitForVerification(
        UrlSubmitForVerificationParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<UrlSubmitForVerificationParams> request = new()
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
                    .Deserialize<UrlSubmitForVerificationResponse>(token)
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
