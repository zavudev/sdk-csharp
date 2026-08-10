using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

namespace Zavudev.Services.Number10dlc.Campaigns;

/// <inheritdoc/>
public sealed class PhoneNumberService : IPhoneNumberService
{
    readonly Lazy<IPhoneNumberServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPhoneNumberServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IZavudevClient _client;

    /// <inheritdoc/>
    public IPhoneNumberService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PhoneNumberService(this._client.WithOptions(modifier));
    }

    public PhoneNumberService(IZavudevClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PhoneNumberServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberListResponse> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhoneNumberListResponse> List(
        string campaignID,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PhoneNumberAssignResponse> Assign(
        PhoneNumberAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Assign(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PhoneNumberAssignResponse> Assign(
        string campaignID,
        PhoneNumberAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Assign(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task Unassign(
        PhoneNumberUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.WithRawResponse.Unassign(parameters, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task Unassign(
        string assignmentID,
        PhoneNumberUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        await this.Unassign(parameters with { AssignmentID = assignmentID }, cancellationToken)
            .ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class PhoneNumberServiceWithRawResponse : IPhoneNumberServiceWithRawResponse
{
    readonly IZavudevClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPhoneNumberServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PhoneNumberServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PhoneNumberServiceWithRawResponse(IZavudevClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberListResponse>> List(
        PhoneNumberListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.CampaignID' cannot be null");
        }

        HttpRequest<PhoneNumberListParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var phoneNumbers = await response
                    .Deserialize<PhoneNumberListResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    phoneNumbers.Validate();
                }
                return phoneNumbers;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PhoneNumberListResponse>> List(
        string campaignID,
        PhoneNumberListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PhoneNumberAssignResponse>> Assign(
        PhoneNumberAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.CampaignID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.CampaignID' cannot be null");
        }

        HttpRequest<PhoneNumberAssignParams> request = new()
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
                    .Deserialize<PhoneNumberAssignResponse>(token)
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
    public Task<HttpResponse<PhoneNumberAssignResponse>> Assign(
        string campaignID,
        PhoneNumberAssignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Assign(parameters with { CampaignID = campaignID }, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unassign(
        PhoneNumberUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.AssignmentID == null)
        {
            throw new ZavudevInvalidDataException("'parameters.AssignmentID' cannot be null");
        }

        HttpRequest<PhoneNumberUnassignParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        return this._client.Execute(request, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<HttpResponse> Unassign(
        string assignmentID,
        PhoneNumberUnassignParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Unassign(parameters with { AssignmentID = assignmentID }, cancellationToken);
    }
}
