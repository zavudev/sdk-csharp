using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Senders;
using Zavudev.Models.Senders.Agent.Tools.Webhook;

namespace Zavudev.Services.Senders.Agent.Tools;

/// <inheritdoc/>
public sealed class WebhookService : IWebhookService
{
    readonly Lazy<IWebhookServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IWebhookService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookService(this._client.WithOptions(modifier));
    }

    public WebhookService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new WebhookServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<WebhookSecretResponse> RotateSecret(
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RotateSecret(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<WebhookSecretResponse> RotateSecret(
        string toolID,
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RotateSecret(parameters with { ToolID = toolID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class WebhookServiceWithRawResponse : IWebhookServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IWebhookServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new WebhookServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public WebhookServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<WebhookSecretResponse>> RotateSecret(
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ToolID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ToolID' cannot be null");
        }

        HttpRequest<WebhookRotateSecretParams> request = new()
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
    public Task<HttpResponse<WebhookSecretResponse>> RotateSecret(
        string toolID,
        WebhookRotateSecretParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.RotateSecret(parameters with { ToolID = toolID }, cancellationToken);
    }
}
