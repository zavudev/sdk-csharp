using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Functions.Triggers;

namespace Zavudev.Services.Functions;

/// <inheritdoc/>
public sealed class TriggerService : ITriggerService
{
    readonly Lazy<ITriggerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ITriggerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public ITriggerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TriggerService(this._client.WithOptions(modifier));
    }

    public TriggerService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new TriggerServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<TriggerCreateResponse> Create(
        TriggerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TriggerCreateResponse> Create(
        string functionID,
        TriggerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TriggerUpdateResponse> Update(
        TriggerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TriggerUpdateResponse> Update(
        string triggerID,
        TriggerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { TriggerID = triggerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<TriggerListResponse> List(
        TriggerListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<TriggerListResponse> List(
        string functionID,
        TriggerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Delete(
        TriggerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string triggerID,
        TriggerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { TriggerID = triggerID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class TriggerServiceWithRawResponse : ITriggerServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ITriggerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new TriggerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public TriggerServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TriggerCreateResponse>> Create(
        TriggerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<TriggerCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var trigger = await response
                    .Deserialize<TriggerCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    trigger.Validate();
                }
                return trigger;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TriggerCreateResponse>> Create(
        string functionID,
        TriggerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Create(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TriggerUpdateResponse>> Update(
        TriggerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TriggerID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.TriggerID' cannot be null");
        }

        HttpRequest<TriggerUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var trigger = await response
                    .Deserialize<TriggerUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    trigger.Validate();
                }
                return trigger;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TriggerUpdateResponse>> Update(
        string triggerID,
        TriggerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { TriggerID = triggerID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<TriggerListResponse>> List(
        TriggerListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.FunctionID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.FunctionID' cannot be null");
        }

        HttpRequest<TriggerListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var triggers = await response
                    .Deserialize<TriggerListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    triggers.Validate();
                }
                return triggers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<TriggerListResponse>> List(
        string functionID,
        TriggerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { FunctionID = functionID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        TriggerDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.TriggerID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.TriggerID' cannot be null");
        }

        HttpRequest<TriggerDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string triggerID,
        TriggerDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { TriggerID = triggerID }, cancellationToken);
    }
}
