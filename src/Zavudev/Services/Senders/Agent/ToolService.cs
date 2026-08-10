using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Services.Senders.Agent;

/// <inheritdoc/>
public sealed class ToolService : IToolService
{
    readonly Lazy<IToolServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IToolServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IToolService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ToolService(this._client.WithOptions(modifier));
    }

    public ToolService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ToolServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ToolCreateResponse> Create(
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ToolCreateResponse> Create(
        string senderID,
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ToolRetrieveResponse> Retrieve(
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ToolRetrieveResponse> Retrieve(
        string toolID,
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ToolID = toolID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ToolUpdateResponse> Update(
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ToolUpdateResponse> Update(
        string toolID,
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ToolID = toolID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ToolListPage> List(
        ToolListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ToolListPage> List(
        string senderID,
        ToolListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(ToolDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string toolID,
        ToolDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Delete(parameters with { ToolID = toolID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ToolTestResponse> Test(
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Test(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ToolTestResponse> Test(
        string toolID,
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Test(parameters with { ToolID = toolID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ToolServiceWithRawResponse : IToolServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IToolServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ToolServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ToolServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ToolCreateResponse>> Create(
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<ToolCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tool = await response
                    .Deserialize<ToolCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tool.Validate();
                }
                return tool;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ToolCreateResponse>> Create(
        string senderID,
        ToolCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ToolRetrieveResponse>> Retrieve(
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ToolID' cannot be null");
        }

        HttpRequest<ToolRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tool = await response
                    .Deserialize<ToolRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tool.Validate();
                }
                return tool;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ToolRetrieveResponse>> Retrieve(
        string toolID,
        ToolRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Retrieve(parameters with { ToolID = toolID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ToolUpdateResponse>> Update(
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ToolID' cannot be null");
        }

        HttpRequest<ToolUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var tool = await response
                    .Deserialize<ToolUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    tool.Validate();
                }
                return tool;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ToolUpdateResponse>> Update(
        string toolID,
        ToolUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ToolID = toolID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ToolListPage>> List(
        ToolListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<ToolListParams> request = new()
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
                    .Deserialize<ToolListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new ToolListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ToolListPage>> List(
        string senderID,
        ToolListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        ToolDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ToolID' cannot be null");
        }

        HttpRequest<ToolDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string toolID,
        ToolDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delete(parameters with { ToolID = toolID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ToolTestResponse>> Test(
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ToolID' cannot be null");
        }

        HttpRequest<ToolTestParams> request = new()
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
                    .Deserialize<ToolTestResponse>(token)
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
    public Task<HttpResponse<ToolTestResponse>> Test(
        string toolID,
        ToolTestParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Test(parameters with { ToolID = toolID }, cancellationToken);
    }
}
