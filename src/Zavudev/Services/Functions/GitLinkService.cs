using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Functions.GitLink;

namespace Zavudev.Services.Functions;

/// <inheritdoc/>
public sealed class GitLinkService : IGitLinkService
{
    readonly Lazy<IGitLinkServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGitLinkServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IGitLinkService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GitLinkService(this._client.WithOptions(modifier));
    }

    public GitLinkService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GitLinkServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<GitLinkRetrieveResponse> Retrieve(
        GitLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GitLinkRetrieveResponse> Retrieve(
        string functionID,
        GitLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<GitLinkUpdateResponse> Update(
        GitLinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GitLinkUpdateResponse> Update(
        string functionID,
        GitLinkUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<GitLinkDeployNowResponse> DeployNow(
        GitLinkDeployNowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.DeployNow(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GitLinkDeployNowResponse> DeployNow(
        string functionID,
        GitLinkDeployNowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeployNow(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<GitLinkLinkResponse> Link(
        GitLinkLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Link(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GitLinkLinkResponse> Link(
        string functionID,
        GitLinkLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Link(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Unlink(
        GitLinkUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Unlink(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Unlink(
        string functionID,
        GitLinkUnlinkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Unlink(parameters with { FunctionID = functionID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class GitLinkServiceWithRawResponse : IGitLinkServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGitLinkServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GitLinkServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GitLinkServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GitLinkRetrieveResponse>> Retrieve(
        GitLinkRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<GitLinkRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var gitLink = await response
                    .Deserialize<GitLinkRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    gitLink.Validate();
                }
                return gitLink;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<GitLinkRetrieveResponse>> Retrieve(
        string functionID,
        GitLinkRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GitLinkUpdateResponse>> Update(
        GitLinkUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<GitLinkUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var gitLink = await response
                    .Deserialize<GitLinkUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    gitLink.Validate();
                }
                return gitLink;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<GitLinkUpdateResponse>> Update(
        string functionID,
        GitLinkUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GitLinkDeployNowResponse>> DeployNow(
        GitLinkDeployNowParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<GitLinkDeployNowParams> request = new()
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
                    .Deserialize<GitLinkDeployNowResponse>(token)
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
    public Task<HttpResponse<GitLinkDeployNowResponse>> DeployNow(
        string functionID,
        GitLinkDeployNowParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.DeployNow(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GitLinkLinkResponse>> Link(
        GitLinkLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<GitLinkLinkParams> request = new()
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
                    .Deserialize<GitLinkLinkResponse>(token)
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
    public Task<HttpResponse<GitLinkLinkResponse>> Link(
        string functionID,
        GitLinkLinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Link(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unlink(
        GitLinkUnlinkParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<GitLinkUnlinkParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unlink(
        string functionID,
        GitLinkUnlinkParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unlink(parameters with { FunctionID = functionID }, cancellationToken);
    }
}
