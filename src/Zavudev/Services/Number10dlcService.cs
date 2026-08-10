using System;
using Zavudev.Core;
using Zavudev.Services.Number10dlc;

namespace Zavudev.Services;

/// <inheritdoc/>
public sealed class Number10dlcService : INumber10dlcService
{
    readonly Lazy<INumber10dlcServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public INumber10dlcServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public INumber10dlcService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new Number10dlcService(this._client.WithOptions(modifier));
    }

    public Number10dlcService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new Number10dlcServiceWithRawResponse(client.WithRawResponse));
        _brands = new(() => new BrandService(client));
        _campaigns = new(() => new CampaignService(client));
    }

    readonly Lazy<IBrandService> _brands;
    public IBrandService Brands
    {
        get { return _brands.Value; }
    }

    readonly Lazy<ICampaignService> _campaigns;
    public ICampaignService Campaigns
    {
        get { return _campaigns.Value; }
    }
}

/// <inheritdoc/>
public sealed class Number10dlcServiceWithRawResponse : INumber10dlcServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public INumber10dlcServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new Number10dlcServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public Number10dlcServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;

        _brands = new(() => new BrandServiceWithRawResponse(client));
        _campaigns = new(() => new CampaignServiceWithRawResponse(client));
    }

    readonly Lazy<IBrandServiceWithRawResponse> _brands;
    public IBrandServiceWithRawResponse Brands
    {
        get { return _brands.Value; }
    }

    readonly Lazy<ICampaignServiceWithRawResponse> _campaigns;
    public ICampaignServiceWithRawResponse Campaigns
    {
        get { return _campaigns.Value; }
    }
}
