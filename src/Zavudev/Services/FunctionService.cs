using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Functions;
using Zavudev.Services.Functions;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class FunctionService : IFunctionService
{
    readonly Lazy<IFunctionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFunctionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IFunctionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FunctionService(this._client.WithOptions(modifier));
    }

    public FunctionService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FunctionServiceWithRawResponse(client.WithRawResponse));
        _secrets = new(() => new SecretService(client));
        _triggers = new(() => new TriggerService(client));
        _gitLink = new(() => new GitLinkService(client));
    }

    readonly Lazy<ISecretService> _secrets;
    public ISecretService Secrets
    {
        get { return _secrets.Value; }
    }

    readonly Lazy<ITriggerService> _triggers;
    public ITriggerService Triggers
    {
        get { return _triggers.Value; }
    }

    readonly Lazy<IGitLinkService> _gitLink;
    public IGitLinkService GitLink
    {
        get { return _gitLink.Value; }
    }

    /// <inheritdoc/>
    public async Task<FunctionCreateResponse> Create(
        FunctionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FunctionRetrieveResponse> Retrieve(
        FunctionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FunctionRetrieveResponse> Retrieve(
        string functionID,
        FunctionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FunctionUpdateResponse> Update(
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FunctionUpdateResponse> Update(
        string functionID,
        FunctionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FunctionDeleteResponse> Delete(
        FunctionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delete(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FunctionDeleteResponse> Delete(
        string functionID,
        FunctionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FunctionDeployResponse> Deploy(
        FunctionDeployParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Deploy(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FunctionDeployResponse> Deploy(
        string functionID,
        FunctionDeployParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deploy(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FunctionGetDeploymentResponse> GetDeployment(
        FunctionGetDeploymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetDeployment(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FunctionGetDeploymentResponse> GetDeployment(
        string deploymentID,
        FunctionGetDeploymentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetDeployment(
            parameters with
            {
                DeploymentID = deploymentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<FunctionListDeploymentsResponse> ListDeployments(
        FunctionListDeploymentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListDeployments(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FunctionListDeploymentsResponse> ListDeployments(
        string functionID,
        FunctionListDeploymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListDeployments(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FunctionListEventTypesResponse> ListEventTypes(
        FunctionListEventTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListEventTypes(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FunctionRollbackDeploymentResponse> RollbackDeployment(
        FunctionRollbackDeploymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RollbackDeployment(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FunctionRollbackDeploymentResponse> RollbackDeployment(
        string functionID,
        FunctionRollbackDeploymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RollbackDeployment(
            parameters with
            {
                FunctionID = functionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<FunctionTailLogsResponse> TailLogs(
        FunctionTailLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.TailLogs(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FunctionTailLogsResponse> TailLogs(
        string functionID,
        FunctionTailLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.TailLogs(parameters with { FunctionID = functionID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FunctionServiceWithRawResponse : IFunctionServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFunctionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FunctionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FunctionServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;

        _secrets = new(() => new SecretServiceWithRawResponse(client));
        _triggers = new(() => new TriggerServiceWithRawResponse(client));
        _gitLink = new(() => new GitLinkServiceWithRawResponse(client));
    }

    readonly Lazy<ISecretServiceWithRawResponse> _secrets;
    public ISecretServiceWithRawResponse Secrets
    {
        get { return _secrets.Value; }
    }

    readonly Lazy<ITriggerServiceWithRawResponse> _triggers;
    public ITriggerServiceWithRawResponse Triggers
    {
        get { return _triggers.Value; }
    }

    readonly Lazy<IGitLinkServiceWithRawResponse> _gitLink;
    public IGitLinkServiceWithRawResponse GitLink
    {
        get { return _gitLink.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionCreateResponse>> Create(
        FunctionCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FunctionCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var function = await response
                    .Deserialize<FunctionCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    function.Validate();
                }
                return function;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionRetrieveResponse>> Retrieve(
        FunctionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<FunctionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var function = await response
                    .Deserialize<FunctionRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    function.Validate();
                }
                return function;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FunctionRetrieveResponse>> Retrieve(
        string functionID,
        FunctionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionUpdateResponse>> Update(
        FunctionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<FunctionUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var function = await response
                    .Deserialize<FunctionUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    function.Validate();
                }
                return function;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FunctionUpdateResponse>> Update(
        string functionID,
        FunctionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionDeleteResponse>> Delete(
        FunctionDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<FunctionDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var function = await response
                    .Deserialize<FunctionDeleteResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    function.Validate();
                }
                return function;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<FunctionDeleteResponse>> Delete(
        string functionID,
        FunctionDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionDeployResponse>> Deploy(
        FunctionDeployParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<FunctionDeployParams> request = new()
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
                    .Deserialize<FunctionDeployResponse>(token)
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
    public Task<HttpResponse<FunctionDeployResponse>> Deploy(
        string functionID,
        FunctionDeployParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Deploy(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionGetDeploymentResponse>> GetDeployment(
        FunctionGetDeploymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.DeploymentID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.DeploymentID' cannot be null");
        }

        HttpRequest<FunctionGetDeploymentParams> request = new()
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
                    .Deserialize<FunctionGetDeploymentResponse>(token)
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
    public Task<HttpResponse<FunctionGetDeploymentResponse>> GetDeployment(
        string deploymentID,
        FunctionGetDeploymentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetDeployment(
            parameters with
            {
                DeploymentID = deploymentID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionListDeploymentsResponse>> ListDeployments(
        FunctionListDeploymentsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<FunctionListDeploymentsParams> request = new()
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
                    .Deserialize<FunctionListDeploymentsResponse>(token)
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
    public Task<HttpResponse<FunctionListDeploymentsResponse>> ListDeployments(
        string functionID,
        FunctionListDeploymentsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListDeployments(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionListEventTypesResponse>> ListEventTypes(
        FunctionListEventTypesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FunctionListEventTypesParams> request = new()
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
                    .Deserialize<FunctionListEventTypesResponse>(token)
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
    public async Task<HttpResponse<FunctionRollbackDeploymentResponse>> RollbackDeployment(
        FunctionRollbackDeploymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<FunctionRollbackDeploymentParams> request = new()
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
                    .Deserialize<FunctionRollbackDeploymentResponse>(token)
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
    public Task<HttpResponse<FunctionRollbackDeploymentResponse>> RollbackDeployment(
        string functionID,
        FunctionRollbackDeploymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RollbackDeployment(
            parameters with
            {
                FunctionID = functionID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FunctionTailLogsResponse>> TailLogs(
        FunctionTailLogsParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<FunctionTailLogsParams> request = new()
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
                    .Deserialize<FunctionTailLogsResponse>(token)
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
    public Task<HttpResponse<FunctionTailLogsResponse>> TailLogs(
        string functionID,
        FunctionTailLogsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.TailLogs(parameters with { FunctionID = functionID }, cancellationToken);
    }
}
