using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.Urls;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUrlService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUrlServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUrlService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// List URLs that have been verified for this project.
    /// </summary>
    Task<UrlListVerifiedPage> ListVerified(
        UrlListVerifiedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get details of a specific verified URL.
    /// </summary>
    Task<UrlRetrieveDetailsResponse> RetrieveDetails(
        UrlRetrieveDetailsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveDetails(UrlRetrieveDetailsParams, CancellationToken)"/>
    Task<UrlRetrieveDetailsResponse> RetrieveDetails(
        string urlID,
        UrlRetrieveDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Submit a URL for verification. URLs are automatically checked against Google Web
    /// Risk API. Safe URLs are auto-approved, malicious URLs are blocked. URL
    /// shorteners (bit.ly, t.co, etc.) are always blocked.
    ///
    /// <para>**Important:** All SMS and Email messages containing URLs require those
    /// URLs to be verified before the message can be sent. This endpoint allows
    /// pre-verification of URLs.</para>
    /// </summary>
    Task<UrlSubmitForVerificationResponse> SubmitForVerification(
        UrlSubmitForVerificationParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUrlService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUrlServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUrlServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/urls</c>, but is otherwise the
    /// same as <see cref="IUrlService.ListVerified(UrlListVerifiedParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UrlListVerifiedPage>> ListVerified(
        UrlListVerifiedParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/urls/{urlId}</c>, but is otherwise the
    /// same as <see cref="IUrlService.RetrieveDetails(UrlRetrieveDetailsParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UrlRetrieveDetailsResponse>> RetrieveDetails(
        UrlRetrieveDetailsParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveDetails(UrlRetrieveDetailsParams, CancellationToken)"/>
    Task<HttpResponse<UrlRetrieveDetailsResponse>> RetrieveDetails(
        string urlID,
        UrlRetrieveDetailsParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/urls</c>, but is otherwise the
    /// same as <see cref="IUrlService.SubmitForVerification(UrlSubmitForVerificationParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UrlSubmitForVerificationResponse>> SubmitForVerification(
        UrlSubmitForVerificationParams parameters,
        CancellationToken cancellationToken = default
    );
}
