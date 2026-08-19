using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.EmailDomains;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class EmailDomainService : IEmailDomainService
{
    readonly Lazy<IEmailDomainServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEmailDomainServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IEmailDomainService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EmailDomainService(this._client.WithOptions(modifier));
    }

    public EmailDomainService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EmailDomainServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EmailDomainCreateResponse> Create(
        EmailDomainCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainRetrieveResponse> Retrieve(
        EmailDomainRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EmailDomainRetrieveResponse> Retrieve(
        string domainID,
        EmailDomainRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DomainID = domainID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainListResponse> List(
        EmailDomainListParams? parameters = null,
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
        EmailDomainDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string domainID,
        EmailDomainDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { DomainID = domainID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EmailDomainVerifyResponse> Verify(
        EmailDomainVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Verify(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EmailDomainVerifyResponse> Verify(
        string domainID,
        EmailDomainVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Verify(parameters with { DomainID = domainID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EmailDomainServiceWithRawResponse : IEmailDomainServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEmailDomainServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EmailDomainServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EmailDomainServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainCreateResponse>> Create(
        EmailDomainCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EmailDomainCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var emailDomain = await response
                    .Deserialize<EmailDomainCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    emailDomain.Validate();
                }
                return emailDomain;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainRetrieveResponse>> Retrieve(
        EmailDomainRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DomainID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.DomainID' cannot be null");
        }

        HttpRequest<EmailDomainRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var emailDomain = await response
                    .Deserialize<EmailDomainRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    emailDomain.Validate();
                }
                return emailDomain;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EmailDomainRetrieveResponse>> Retrieve(
        string domainID,
        EmailDomainRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { DomainID = domainID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainListResponse>> List(
        EmailDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EmailDomainListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var emailDomains = await response
                    .Deserialize<EmailDomainListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    emailDomains.Validate();
                }
                return emailDomains;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        EmailDomainDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DomainID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.DomainID' cannot be null");
        }

        HttpRequest<EmailDomainDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string domainID,
        EmailDomainDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { DomainID = domainID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EmailDomainVerifyResponse>> Verify(
        EmailDomainVerifyParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DomainID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.DomainID' cannot be null");
        }

        HttpRequest<EmailDomainVerifyParams> request = new()
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
                    .Deserialize<EmailDomainVerifyResponse>(token)
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
    public Task<HttpResponse<EmailDomainVerifyResponse>> Verify(
        string domainID,
        EmailDomainVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Verify(parameters with { DomainID = domainID }, cancellationToken);
    }
}
