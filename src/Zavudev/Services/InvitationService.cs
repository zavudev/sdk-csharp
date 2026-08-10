using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Invitations;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class InvitationService : IInvitationService
{
    readonly Lazy<IInvitationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInvitationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IInvitationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InvitationService(this._client.WithOptions(modifier));
    }

    public InvitationService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InvitationServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<InvitationCreateResponse> Create(
        InvitationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InvitationRetrieveResponse> Retrieve(
        InvitationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InvitationRetrieveResponse> Retrieve(
        string invitationID,
        InvitationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { InvitationID = invitationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<InvitationListPage> List(
        InvitationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<InvitationCancelResponse> Cancel(
        InvitationCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<InvitationCancelResponse> Cancel(
        string invitationID,
        InvitationCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { InvitationID = invitationID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class InvitationServiceWithRawResponse : IInvitationServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInvitationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new InvitationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InvitationServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvitationCreateResponse>> Create(
        InvitationCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InvitationCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invitation = await response
                    .Deserialize<InvitationCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invitation.Validate();
                }
                return invitation;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvitationRetrieveResponse>> Retrieve(
        InvitationRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvitationID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.InvitationID' cannot be null");
        }

        HttpRequest<InvitationRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var invitation = await response
                    .Deserialize<InvitationRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    invitation.Validate();
                }
                return invitation;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<InvitationRetrieveResponse>> Retrieve(
        string invitationID,
        InvitationRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { InvitationID = invitationID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvitationListPage>> List(
        InvitationListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<InvitationListParams> request = new()
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
                    .Deserialize<InvitationListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new InvitationListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<InvitationCancelResponse>> Cancel(
        InvitationCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.InvitationID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.InvitationID' cannot be null");
        }

        HttpRequest<InvitationCancelParams> request = new()
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
                    .Deserialize<InvitationCancelResponse>(token)
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
    public Task<HttpResponse<InvitationCancelResponse>> Cancel(
        string invitationID,
        InvitationCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { InvitationID = invitationID }, cancellationToken);
    }
}
