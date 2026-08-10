using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Introspect;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class IntrospectService : IIntrospectService
{
    readonly Lazy<IIntrospectServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IIntrospectServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IIntrospectService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new IntrospectService(this._client.WithOptions(modifier));
    }

    public IntrospectService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new IntrospectServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<IntrospectValidatePhoneResponse> ValidatePhone(
        IntrospectValidatePhoneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ValidatePhone(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class IntrospectServiceWithRawResponse : IIntrospectServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IIntrospectServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new IntrospectServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public IntrospectServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<IntrospectValidatePhoneResponse>> ValidatePhone(
        IntrospectValidatePhoneParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<IntrospectValidatePhoneParams> request = new()
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
                    .Deserialize<IntrospectValidatePhoneResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
