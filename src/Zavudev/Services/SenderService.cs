using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders;
using Zavudev.Services.Senders;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class SenderService : ISenderService
{
    readonly Lazy<ISenderServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISenderServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public ISenderService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SenderService(this._client.WithOptions(modifier));
    }

    public SenderService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new SenderServiceWithRawResponse(client.WithRawResponse));
        _agent = new(() => new AgentService(client));
        _whatsappSync = new(() => new WhatsappSyncService(client));
    }

    readonly Lazy<IAgentService> _agent;
    public IAgentService Agent
    {
        get { return _agent.Value; }
    }

    readonly Lazy<IWhatsappSyncService> _whatsappSync;
    public IWhatsappSyncService WhatsappSync
    {
        get { return _whatsappSync.Value; }
    }

    /// <inheritdoc/>
    public async Task<Sender> Create(
        SenderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Sender> Retrieve(
        SenderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Sender> Retrieve(
        string senderID,
        SenderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Sender> Update(
        SenderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Sender> Update(
        string senderID,
        SenderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SenderListPage> List(
        SenderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task Delete(SenderDeleteParams parameters, CancellationToken cancellationToken = default)
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string senderID,
        SenderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { SenderID = senderID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<WhatsappBusinessProfileResponse> GetProfile(
        SenderGetProfileParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetProfile(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WhatsappBusinessProfileResponse> GetProfile(
        string senderID,
        SenderGetProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetProfile(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<WebhookSecretResponse> RegenerateWebhookSecret(
        SenderRegenerateWebhookSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RegenerateWebhookSecret(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookSecretResponse> RegenerateWebhookSecret(
        string senderID,
        SenderRegenerateWebhookSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RegenerateWebhookSecret(
            parameters with
            {
                SenderID = senderID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<SenderUpdateProfileResponse> UpdateProfile(
        SenderUpdateProfileParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateProfile(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SenderUpdateProfileResponse> UpdateProfile(
        string senderID,
        SenderUpdateProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateProfile(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SenderUploadProfilePictureResponse> UploadProfilePicture(
        SenderUploadProfilePictureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UploadProfilePicture(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SenderUploadProfilePictureResponse> UploadProfilePicture(
        string senderID,
        SenderUploadProfilePictureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UploadProfilePicture(
            parameters with
            {
                SenderID = senderID,
            },
            cancellationToken
        );
    }
}

/// <inheritdoc/>
public sealed class SenderServiceWithRawResponse : ISenderServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISenderServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SenderServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SenderServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;

        _agent = new(() => new AgentServiceWithRawResponse(client));
        _whatsappSync = new(() => new WhatsappSyncServiceWithRawResponse(client));
    }

    readonly Lazy<IAgentServiceWithRawResponse> _agent;
    public IAgentServiceWithRawResponse Agent
    {
        get { return _agent.Value; }
    }

    readonly Lazy<IWhatsappSyncServiceWithRawResponse> _whatsappSync;
    public IWhatsappSyncServiceWithRawResponse WhatsappSync
    {
        get { return _whatsappSync.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Sender>> Create(
        SenderCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SenderCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var sender = await response.Deserialize<Sender>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    sender.Validate();
                }
                return sender;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Sender>> Retrieve(
        SenderRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<SenderRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var sender = await response.Deserialize<Sender>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    sender.Validate();
                }
                return sender;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Sender>> Retrieve(
        string senderID,
        SenderRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Sender>> Update(
        SenderUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<SenderUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var sender = await response.Deserialize<Sender>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    sender.Validate();
                }
                return sender;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Sender>> Update(
        string senderID,
        SenderUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SenderListPage>> List(
        SenderListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SenderListParams> request = new()
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
                    .Deserialize<SenderListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SenderListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        SenderDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<SenderDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string senderID,
        SenderDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WhatsappBusinessProfileResponse>> GetProfile(
        SenderGetProfileParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<SenderGetProfileParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var whatsappBusinessProfileResponse = await response
                    .Deserialize<WhatsappBusinessProfileResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    whatsappBusinessProfileResponse.Validate();
                }
                return whatsappBusinessProfileResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WhatsappBusinessProfileResponse>> GetProfile(
        string senderID,
        SenderGetProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.GetProfile(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookSecretResponse>> RegenerateWebhookSecret(
        SenderRegenerateWebhookSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<SenderRegenerateWebhookSecretParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var webhookSecretResponse = await response
                    .Deserialize<WebhookSecretResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    webhookSecretResponse.Validate();
                }
                return webhookSecretResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<WebhookSecretResponse>> RegenerateWebhookSecret(
        string senderID,
        SenderRegenerateWebhookSecretParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RegenerateWebhookSecret(
            parameters with
            {
                SenderID = senderID,
            },
            cancellationToken
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SenderUpdateProfileResponse>> UpdateProfile(
        SenderUpdateProfileParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<SenderUpdateProfileParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<SenderUpdateProfileResponse>(token)
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
    public Task<HttpResponse<SenderUpdateProfileResponse>> UpdateProfile(
        string senderID,
        SenderUpdateProfileParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateProfile(parameters with { SenderID = senderID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SenderUploadProfilePictureResponse>> UploadProfilePicture(
        SenderUploadProfilePictureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.SenderID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.SenderID' cannot be null");
        }

        HttpRequest<SenderUploadProfilePictureParams> request = new()
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
                    .Deserialize<SenderUploadProfilePictureResponse>(token)
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
    public Task<HttpResponse<SenderUploadProfilePictureResponse>> UploadProfilePicture(
        string senderID,
        SenderUploadProfilePictureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.UploadProfilePicture(
            parameters with
            {
                SenderID = senderID,
            },
            cancellationToken
        );
    }
}
