using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Templates;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class TemplateService : ITemplateService
{
    readonly Lazy<ITemplateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITemplateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public ITemplateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TemplateService(this._client.WithOptions(modifier));
    }

    public TemplateService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TemplateServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Template> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Template> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Template> Retrieve(
        string templateID,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TemplateListPage> List(
        TemplateListParams? parameters = null,
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
        TemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string templateID,
        TemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { TemplateID = templateID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Template> Submit(
        TemplateSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Submit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Template> Submit(
        string templateID,
        TemplateSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Submit(parameters with { TemplateID = templateID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class TemplateServiceWithRawResponse : ITemplateServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITemplateServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TemplateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TemplateServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Template>> Create(
        TemplateCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<TemplateCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var template = await response.Deserialize<Template>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    template.Validate();
                }
                return template;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Template>> Retrieve(
        TemplateRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<TemplateRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var template = await response.Deserialize<Template>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    template.Validate();
                }
                return template;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Template>> Retrieve(
        string templateID,
        TemplateRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TemplateListPage>> List(
        TemplateListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<TemplateListParams> request = new()
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
                    .Deserialize<TemplateListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new TemplateListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TemplateDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<TemplateDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string templateID,
        TemplateDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { TemplateID = templateID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Template>> Submit(
        TemplateSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TemplateID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.TemplateID' cannot be null");
        }

        HttpRequest<TemplateSubmitParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var template = await response.Deserialize<Template>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    template.Validate();
                }
                return template;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Template>> Submit(
        string templateID,
        TemplateSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Submit(parameters with { TemplateID = templateID }, cancellationToken);
    }
}
