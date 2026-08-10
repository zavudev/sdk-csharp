using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Services;

namespace Zavudev;

/// <inheritdoc/>
public sealed class ZavudevClient : IZavudevClient
{
    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    readonly Lazy<IZavudevClientWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IZavudevClientWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    /// <inheritdoc/>
    public IZavudevClient WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ZavudevClient(modifier(this._options));
    }

    readonly Lazy<IMessageService> _messages;
    public IMessageService Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<ITemplateService> _templates;
    public ITemplateService Templates
    {
        get { return _templates.Value; }
    }

    readonly Lazy<ISenderService> _senders;
    public ISenderService Senders
    {
        get { return _senders.Value; }
    }

    readonly Lazy<IContactService> _contacts;
    public IContactService Contacts
    {
        get { return _contacts.Value; }
    }

    readonly Lazy<IBroadcastService> _broadcasts;
    public IBroadcastService Broadcasts
    {
        get { return _broadcasts.Value; }
    }

    readonly Lazy<IIntrospectService> _introspect;
    public IIntrospectService Introspect
    {
        get { return _introspect.Value; }
    }

    readonly Lazy<IPhoneNumberService> _phoneNumbers;
    public IPhoneNumberService PhoneNumbers
    {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<IAddressService> _addresses;
    public IAddressService Addresses
    {
        get { return _addresses.Value; }
    }

    readonly Lazy<IRegulatoryDocumentService> _regulatoryDocuments;
    public IRegulatoryDocumentService RegulatoryDocuments
    {
        get { return _regulatoryDocuments.Value; }
    }

    readonly Lazy<IInvitationService> _invitations;
    public IInvitationService Invitations
    {
        get { return _invitations.Value; }
    }

    readonly Lazy<IUrlService> _urls;
    public IUrlService Urls
    {
        get { return _urls.Value; }
    }

    readonly Lazy<IBalanceService> _balance;
    public IBalanceService Balance
    {
        get { return _balance.Value; }
    }

    readonly Lazy<ISubAccountService> _subAccounts;
    public ISubAccountService SubAccounts
    {
        get { return _subAccounts.Value; }
    }

    readonly Lazy<INumber10dlcService> _number10dlc;
    public INumber10dlcService Number10dlc
    {
        get { return _number10dlc.Value; }
    }

    readonly Lazy<IMeService> _me;
    public IMeService Me
    {
        get { return _me.Value; }
    }

    readonly Lazy<IFunctionService> _functions;
    public IFunctionService Functions
    {
        get { return _functions.Value; }
    }

    public void Dispose() => this.HttpClient.Dispose();

    public ZavudevClient()
    {
        _options = new();

        _withRawResponse = new(() => new ZavudevClientWithRawResponse(this._options));
        _messages = new(() => new MessageService(this));
        _templates = new(() => new TemplateService(this));
        _senders = new(() => new SenderService(this));
        _contacts = new(() => new ContactService(this));
        _broadcasts = new(() => new BroadcastService(this));
        _introspect = new(() => new IntrospectService(this));
        _phoneNumbers = new(() => new PhoneNumberService(this));
        _addresses = new(() => new AddressService(this));
        _regulatoryDocuments = new(() => new RegulatoryDocumentService(this));
        _invitations = new(() => new InvitationService(this));
        _urls = new(() => new UrlService(this));
        _balance = new(() => new BalanceService(this));
        _subAccounts = new(() => new SubAccountService(this));
        _number10dlc = new(() => new Number10dlcService(this));
        _me = new(() => new MeService(this));
        _functions = new(() => new FunctionService(this));
    }

    public ZavudevClient(ClientOptions options)
        : this()
    {
        _options = options;
    }
}

/// <inheritdoc/>
public sealed class ZavudevClientWithRawResponse : IZavudevClientWithRawResponse
{
#if NET
    static readonly Random Random = Random.Shared;
#else
    static readonly ThreadLocal<Random> _threadLocalRandom = new(() => new Random());

    static Random Random
    {
        get { return _threadLocalRandom.Value!; }
    }
#endif

    internal static HttpMethod PatchMethod = new("PATCH");

    readonly ClientOptions _options;

    /// <inheritdoc/>
    public HttpClient HttpClient
    {
        get { return this._options.HttpClient; }
        init { this._options.HttpClient = value; }
    }

    /// <inheritdoc/>
    public string BaseUrl
    {
        get { return this._options.BaseUrl; }
        init { this._options.BaseUrl = value; }
    }

    /// <inheritdoc/>
    public bool ResponseValidation
    {
        get { return this._options.ResponseValidation; }
        init { this._options.ResponseValidation = value; }
    }

    /// <inheritdoc/>
    public int? MaxRetries
    {
        get { return this._options.MaxRetries; }
        init { this._options.MaxRetries = value; }
    }

    /// <inheritdoc/>
    public TimeSpan? Timeout
    {
        get { return this._options.Timeout; }
        init { this._options.Timeout = value; }
    }

    /// <inheritdoc/>
    public string ApiKey
    {
        get { return this._options.ApiKey; }
        init { this._options.ApiKey = value; }
    }

    /// <inheritdoc/>
    public IZavudevClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ZavudevClientWithRawResponse(modifier(this._options));
    }

    readonly Lazy<IMessageServiceWithRawResponse> _messages;
    public IMessageServiceWithRawResponse Messages
    {
        get { return _messages.Value; }
    }

    readonly Lazy<ITemplateServiceWithRawResponse> _templates;
    public ITemplateServiceWithRawResponse Templates
    {
        get { return _templates.Value; }
    }

    readonly Lazy<ISenderServiceWithRawResponse> _senders;
    public ISenderServiceWithRawResponse Senders
    {
        get { return _senders.Value; }
    }

    readonly Lazy<IContactServiceWithRawResponse> _contacts;
    public IContactServiceWithRawResponse Contacts
    {
        get { return _contacts.Value; }
    }

    readonly Lazy<IBroadcastServiceWithRawResponse> _broadcasts;
    public IBroadcastServiceWithRawResponse Broadcasts
    {
        get { return _broadcasts.Value; }
    }

    readonly Lazy<IIntrospectServiceWithRawResponse> _introspect;
    public IIntrospectServiceWithRawResponse Introspect
    {
        get { return _introspect.Value; }
    }

    readonly Lazy<IPhoneNumberServiceWithRawResponse> _phoneNumbers;
    public IPhoneNumberServiceWithRawResponse PhoneNumbers
    {
        get { return _phoneNumbers.Value; }
    }

    readonly Lazy<IAddressServiceWithRawResponse> _addresses;
    public IAddressServiceWithRawResponse Addresses
    {
        get { return _addresses.Value; }
    }

    readonly Lazy<IRegulatoryDocumentServiceWithRawResponse> _regulatoryDocuments;
    public IRegulatoryDocumentServiceWithRawResponse RegulatoryDocuments
    {
        get { return _regulatoryDocuments.Value; }
    }

    readonly Lazy<IInvitationServiceWithRawResponse> _invitations;
    public IInvitationServiceWithRawResponse Invitations
    {
        get { return _invitations.Value; }
    }

    readonly Lazy<IUrlServiceWithRawResponse> _urls;
    public IUrlServiceWithRawResponse Urls
    {
        get { return _urls.Value; }
    }

    readonly Lazy<IBalanceServiceWithRawResponse> _balance;
    public IBalanceServiceWithRawResponse Balance
    {
        get { return _balance.Value; }
    }

    readonly Lazy<ISubAccountServiceWithRawResponse> _subAccounts;
    public ISubAccountServiceWithRawResponse SubAccounts
    {
        get { return _subAccounts.Value; }
    }

    readonly Lazy<INumber10dlcServiceWithRawResponse> _number10dlc;
    public INumber10dlcServiceWithRawResponse Number10dlc
    {
        get { return _number10dlc.Value; }
    }

    readonly Lazy<IMeServiceWithRawResponse> _me;
    public IMeServiceWithRawResponse Me
    {
        get { return _me.Value; }
    }

    readonly Lazy<IFunctionServiceWithRawResponse> _functions;
    public IFunctionServiceWithRawResponse Functions
    {
        get { return _functions.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        var maxRetries = this.MaxRetries ?? ClientOptions.DefaultMaxRetries;
        var retries = 0;
        while (true)
        {
            HttpResponse? response = null;
            try
            {
                response = await ExecuteOnce(request, retries, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (++retries > maxRetries || !ShouldRetry(e))
                {
                    throw;
                }
            }

            if (response != null && (++retries > maxRetries || !ShouldRetry(response)))
            {
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                try
                {
                    throw ZavudevExceptionFactory.CreateApiException(
                        response.StatusCode,
                        await response.ReadAsString(cancellationToken).ConfigureAwait(false)
                    );
                }
                catch (HttpRequestException e)
                {
                    throw new ZavudevIOException("I/O Exception", e);
                }
                finally
                {
                    response.Dispose();
                }
            }

            var backoff = ComputeRetryBackoff(retries, response);
            response?.Dispose();
            await Task.Delay(backoff, cancellationToken).ConfigureAwait(false);
        }
    }

    async Task<HttpResponse> ExecuteOnce<T>(
        HttpRequest<T> request,
        int retryCount,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase
    {
        using HttpRequestMessage requestMessage = new(
            request.Method,
            request.Params.Url(this._options)
        )
        {
            Content = request.Params.BodyContent(),
        };
        request.Params.AddHeadersToRequest(requestMessage, this._options);
        if (!requestMessage.Headers.Contains("x-stainless-retry-count"))
        {
            requestMessage.Headers.Add("x-stainless-retry-count", retryCount.ToString());
        }
        using CancellationTokenSource timeoutCts = new(
            this.Timeout ?? ClientOptions.DefaultTimeout
        );
        using var cts = CancellationTokenSource.CreateLinkedTokenSource(
            timeoutCts.Token,
            cancellationToken
        );
        HttpResponseMessage responseMessage;
        try
        {
            responseMessage = await this
                .HttpClient.SendAsync(
                    requestMessage,
                    HttpCompletionOption.ResponseHeadersRead,
                    cts.Token
                )
                .ConfigureAwait(false);
        }
        catch (HttpRequestException e)
        {
            throw new ZavudevIOException("I/O exception", e);
        }
        return new() { RawMessage = responseMessage, CancellationToken = cts.Token };
    }

    static TimeSpan ComputeRetryBackoff(int retries, HttpResponse? response)
    {
        TimeSpan? apiBackoff = ParseRetryAfterMsHeader(response) ?? ParseRetryAfterHeader(response);
        if (
            apiBackoff != null
            && apiBackoff > TimeSpan.Zero
            && apiBackoff < TimeSpan.FromMinutes(1)
        )
        {
            // If the API asks us to wait a certain amount of time (and it's a reasonable amount), then just
            // do what it says.
            return (TimeSpan)apiBackoff;
        }

        // Apply exponential backoff, but not more than the max.
        var backoffSeconds = Math.Min(0.5 * Math.Pow(2.0, retries - 1), 8.0);
        var jitter = 1.0 - 0.25 * Random.NextDouble();
        return TimeSpan.FromSeconds(backoffSeconds * jitter);
    }

    static TimeSpan? ParseRetryAfterMsHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After-Ms", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterMs))
        {
            return TimeSpan.FromMilliseconds(retryAfterMs);
        }

        return null;
    }

    static TimeSpan? ParseRetryAfterHeader(HttpResponse? response)
    {
        IEnumerable<string>? headerValues = null;
        response?.TryGetHeaderValues("Retry-After", out headerValues);
        var headerValue = headerValues == null ? null : Enumerable.FirstOrDefault(headerValues);
        if (headerValue == null)
        {
            return null;
        }

        if (float.TryParse(headerValue, out var retryAfterSeconds))
        {
            return TimeSpan.FromSeconds(retryAfterSeconds);
        }
        else if (DateTimeOffset.TryParse(headerValue, out var retryAfterDate))
        {
            return retryAfterDate - DateTimeOffset.Now;
        }

        return null;
    }

    static bool ShouldRetry(HttpResponse response)
    {
        if (
            response.TryGetHeaderValues("X-Should-Retry", out var headerValues)
            && bool.TryParse(Enumerable.FirstOrDefault(headerValues), out var shouldRetry)
        )
        {
            // If the server explicitly says whether to retry, then we obey.
            return shouldRetry;
        }

        return (int)response.StatusCode switch
        {
            // Retry on request timeouts
            408
            or
            // Retry on lock timeouts
            409
            or
            // Retry on rate limits
            429
            or
            // Retry internal errors
            >= 500 => true,
            _ => false,
        };
    }

    static bool ShouldRetry(Exception e)
    {
        return e is IOException || e is ZavudevIOException;
    }

    public void Dispose() => this.HttpClient.Dispose();

    public ZavudevClientWithRawResponse()
    {
        _options = new();

        _messages = new(() => new MessageServiceWithRawResponse(this));
        _templates = new(() => new TemplateServiceWithRawResponse(this));
        _senders = new(() => new SenderServiceWithRawResponse(this));
        _contacts = new(() => new ContactServiceWithRawResponse(this));
        _broadcasts = new(() => new BroadcastServiceWithRawResponse(this));
        _introspect = new(() => new IntrospectServiceWithRawResponse(this));
        _phoneNumbers = new(() => new PhoneNumberServiceWithRawResponse(this));
        _addresses = new(() => new AddressServiceWithRawResponse(this));
        _regulatoryDocuments = new(() => new RegulatoryDocumentServiceWithRawResponse(this));
        _invitations = new(() => new InvitationServiceWithRawResponse(this));
        _urls = new(() => new UrlServiceWithRawResponse(this));
        _balance = new(() => new BalanceServiceWithRawResponse(this));
        _subAccounts = new(() => new SubAccountServiceWithRawResponse(this));
        _number10dlc = new(() => new Number10dlcServiceWithRawResponse(this));
        _me = new(() => new MeServiceWithRawResponse(this));
        _functions = new(() => new FunctionServiceWithRawResponse(this));
    }

    public ZavudevClientWithRawResponse(ClientOptions options)
        : this()
    {
        _options = options;
    }
}
