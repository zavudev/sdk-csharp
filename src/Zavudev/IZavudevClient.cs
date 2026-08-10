using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Services;

namespace Zavudev;

/// <summary>
/// A client for interacting with the Zavudev REST API.
///
/// <para>This client performs best when you create a single instance and reuse it
/// for all interactions with the REST API. This is because each client holds its
/// own connection pool and thread pools. Reusing connections and threads reduces
/// latency and saves memory.</para>
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IZavudevClient : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IZavudevClientWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IZavudevClient WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMessageService Messages { get; }

    ITemplateService Templates { get; }

    ISenderService Senders { get; }

    IContactService Contacts { get; }

    IBroadcastService Broadcasts { get; }

    IIntrospectService Introspect { get; }

    IPhoneNumberService PhoneNumbers { get; }

    IAddressService Addresses { get; }

    IRegulatoryDocumentService RegulatoryDocuments { get; }

    IInvitationService Invitations { get; }

    IUrlService Urls { get; }

    IBalanceService Balance { get; }

    ISubAccountService SubAccounts { get; }

    INumber10dlcService Number10dlc { get; }

    IMeService Me { get; }

    IFunctionService Functions { get; }
}

/// <summary>
/// A view of <see cref="IZavudevClient"/> that provides access to raw HTTP responses for each method.
/// </summary>
public interface IZavudevClientWithRawResponse : IDisposable
{
    /// <inheritdoc cref="ClientOptions.HttpClient" />
    HttpClient HttpClient { get; init; }

    /// <inheritdoc cref="ClientOptions.BaseUrl" />
    string BaseUrl { get; init; }

    /// <inheritdoc cref="ClientOptions.ResponseValidation" />
    bool ResponseValidation { get; init; }

    /// <inheritdoc cref="ClientOptions.MaxRetries" />
    int? MaxRetries { get; init; }

    /// <inheritdoc cref="ClientOptions.Timeout" />
    TimeSpan? Timeout { get; init; }

    string ApiKey { get; init; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IZavudevClientWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IMessageServiceWithRawResponse Messages { get; }

    ITemplateServiceWithRawResponse Templates { get; }

    ISenderServiceWithRawResponse Senders { get; }

    IContactServiceWithRawResponse Contacts { get; }

    IBroadcastServiceWithRawResponse Broadcasts { get; }

    IIntrospectServiceWithRawResponse Introspect { get; }

    IPhoneNumberServiceWithRawResponse PhoneNumbers { get; }

    IAddressServiceWithRawResponse Addresses { get; }

    IRegulatoryDocumentServiceWithRawResponse RegulatoryDocuments { get; }

    IInvitationServiceWithRawResponse Invitations { get; }

    IUrlServiceWithRawResponse Urls { get; }

    IBalanceServiceWithRawResponse Balance { get; }

    ISubAccountServiceWithRawResponse SubAccounts { get; }

    INumber10dlcServiceWithRawResponse Number10dlc { get; }

    IMeServiceWithRawResponse Me { get; }

    IFunctionServiceWithRawResponse Functions { get; }

    /// <summary>
    /// Sends a request to the Zavudev REST API.
    /// </summary>
    Task<HttpResponse> Execute<T>(
        HttpRequest<T> request,
        CancellationToken cancellationToken = default
    )
        where T : ParamsBase;
}
