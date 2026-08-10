using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Contacts.Channels;

namespace Zavudev.Services.Contacts;

/// <inheritdoc/>
public sealed class ChannelService : IChannelService
{
    readonly Lazy<IChannelServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IChannelServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IChannelService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChannelService(this._client.WithOptions(modifier));
    }

    public ChannelService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ChannelServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ChannelUpdateResponse> Update(
        ChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChannelUpdateResponse> Update(
        string channelID,
        ChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ChannelID = channelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ChannelAddResponse> Add(
        ChannelAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Add(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChannelAddResponse> Add(
        string contactID,
        ChannelAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { ContactID = contactID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Remove(
        ChannelRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Remove(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Remove(
        string channelID,
        ChannelRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Remove(parameters with { ChannelID = channelID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<ChannelSetPrimaryResponse> SetPrimary(
        ChannelSetPrimaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SetPrimary(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ChannelSetPrimaryResponse> SetPrimary(
        string channelID,
        ChannelSetPrimaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetPrimary(parameters with { ChannelID = channelID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ChannelServiceWithRawResponse : IChannelServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IChannelServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ChannelServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ChannelServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChannelUpdateResponse>> Update(
        ChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ChannelID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ChannelID' cannot be null");
        }

        HttpRequest<ChannelUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var channel = await response
                    .Deserialize<ChannelUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    channel.Validate();
                }
                return channel;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<ChannelUpdateResponse>> Update(
        string channelID,
        ChannelUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Update(parameters with { ChannelID = channelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChannelAddResponse>> Add(
        ChannelAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ContactID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ContactID' cannot be null");
        }

        HttpRequest<ChannelAddParams> request = new()
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
                    .Deserialize<ChannelAddResponse>(token)
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
    public Task<HttpResponse<ChannelAddResponse>> Add(
        string contactID,
        ChannelAddParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Add(parameters with { ContactID = contactID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        ChannelRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ChannelID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ChannelID' cannot be null");
        }

        HttpRequest<ChannelRemoveParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Remove(
        string channelID,
        ChannelRemoveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Remove(parameters with { ChannelID = channelID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ChannelSetPrimaryResponse>> SetPrimary(
        ChannelSetPrimaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ChannelID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.ChannelID' cannot be null");
        }

        HttpRequest<ChannelSetPrimaryParams> request = new()
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
                    .Deserialize<ChannelSetPrimaryResponse>(token)
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
    public Task<HttpResponse<ChannelSetPrimaryResponse>> SetPrimary(
        string channelID,
        ChannelSetPrimaryParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.SetPrimary(parameters with { ChannelID = channelID }, cancellationToken);
    }
}
