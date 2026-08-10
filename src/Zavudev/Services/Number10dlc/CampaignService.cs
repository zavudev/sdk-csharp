using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Number10dlc.Campaigns;
using Campaigns = Zavudev.Services.Number10dlc.Campaigns;

namespace Zavudev.Services.Number10dlc;

/// <inheritdoc/>
public sealed class CampaignService : ICampaignService
{
    readonly Lazy<ICampaignServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICampaignServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public ICampaignService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CampaignService(this._client.WithOptions(modifier));
    }

    public CampaignService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CampaignServiceWithRawResponse(client.WithRawResponse));
        _phoneNumbers = new(() => new Campaigns::PhoneNumberService(client));
    }

    readonly Lazy<Campaigns::IPhoneNumberService> _phoneNumbers;
    public Campaigns::IPhoneNumberService PhoneNumbers
    {
        get { return _phoneNumbers.Value; }
    }

    /// <inheritdoc/>
    public async Task<CampaignCreateResponse> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CampaignRetrieveResponse> Retrieve(
        CampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CampaignRetrieveResponse> Retrieve(
        string campaignID,
        CampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CampaignUpdateResponse> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CampaignUpdateResponse> Update(
        string campaignID,
        CampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CampaignListPage> List(
        CampaignListParams? parameters = null,
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
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Delete(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Delete(
        string campaignID,
        CampaignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        await this.Delete(parameters with { CampaignID = campaignID }, cancellationToken)
            .ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CampaignSubmitResponse> Submit(
        CampaignSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Submit(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CampaignSubmitResponse> Submit(
        string campaignID,
        CampaignSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CampaignSyncStatusResponse> SyncStatus(
        CampaignSyncStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.SyncStatus(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CampaignSyncStatusResponse> SyncStatus(
        string campaignID,
        CampaignSyncStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SyncStatus(parameters with { CampaignID = campaignID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CampaignServiceWithRawResponse : ICampaignServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICampaignServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CampaignServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CampaignServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;

        _phoneNumbers = new(() => new Campaigns::PhoneNumberServiceWithRawResponse(client));
    }

    readonly Lazy<Campaigns::IPhoneNumberServiceWithRawResponse> _phoneNumbers;
    public Campaigns::IPhoneNumberServiceWithRawResponse PhoneNumbers
    {
        get { return _phoneNumbers.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignCreateResponse>> Create(
        CampaignCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CampaignCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var campaign = await response
                    .Deserialize<CampaignCreateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    campaign.Validate();
                }
                return campaign;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignRetrieveResponse>> Retrieve(
        CampaignRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.CampaignID' cannot be null");
        }

        HttpRequest<CampaignRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var campaign = await response
                    .Deserialize<CampaignRetrieveResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    campaign.Validate();
                }
                return campaign;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CampaignRetrieveResponse>> Retrieve(
        string campaignID,
        CampaignRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignUpdateResponse>> Update(
        CampaignUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.CampaignID' cannot be null");
        }

        HttpRequest<CampaignUpdateParams> request = new()
        {
            Method = ZavudevClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var campaign = await response
                    .Deserialize<CampaignUpdateResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    campaign.Validate();
                }
                return campaign;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CampaignUpdateResponse>> Update(
        string campaignID,
        CampaignUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignListPage>> List(
        CampaignListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CampaignListParams> request = new()
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
                    .Deserialize<CampaignListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CampaignListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        CampaignDeleteParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.CampaignID' cannot be null");
        }

        HttpRequest<CampaignDeleteParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Delete(
        string campaignID,
        CampaignDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Delete(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignSubmitResponse>> Submit(
        CampaignSubmitParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.CampaignID' cannot be null");
        }

        HttpRequest<CampaignSubmitParams> request = new()
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
                    .Deserialize<CampaignSubmitResponse>(token)
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
    public Task<HttpResponse<CampaignSubmitResponse>> Submit(
        string campaignID,
        CampaignSubmitParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Submit(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CampaignSyncStatusResponse>> SyncStatus(
        CampaignSyncStatusParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.CampaignID' cannot be null");
        }

        HttpRequest<CampaignSyncStatusParams> request = new()
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
                    .Deserialize<CampaignSyncStatusResponse>(token)
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
    public Task<HttpResponse<CampaignSyncStatusResponse>> SyncStatus(
        string campaignID,
        CampaignSyncStatusParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.SyncStatus(parameters with { CampaignID = campaignID }, cancellationToken);
    }
}
