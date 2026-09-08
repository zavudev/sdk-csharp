using System;
using System.Threading;
using System.Threading.Tasks;
using Zavudev.Core;
using Zavudev.Models.EmailDomains;

namespace Zavudev.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEmailDomainService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEmailDomainServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailDomainService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Add a domain to send email from. Returns the DNS records to publish (DKIM CNAMEs
    /// are required; SPF, DMARC, and MAIL FROM are recommended). Publish them at your
    /// DNS provider, then verify.
    /// </summary>
    Task<EmailDomainCreateResponse> Create(
        EmailDomainCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Fetch a domain with its DNS records and current status.
    /// </summary>
    Task<EmailDomainRetrieveResponse> Retrieve(
        EmailDomainRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EmailDomainRetrieveParams, CancellationToken)"/>
    Task<EmailDomainRetrieveResponse> Retrieve(
        string domainID,
        EmailDomainRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List email domains
    /// </summary>
    Task<EmailDomainListResponse> List(
        EmailDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove an email domain
    /// </summary>
    Task Delete(EmailDomainDeleteParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Delete(EmailDomainDeleteParams, CancellationToken)"/>
    Task Delete(
        string domainID,
        EmailDomainDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Re-check the domain's published DNS records and refresh its status.
    /// </summary>
    Task<EmailDomainVerifyResponse> Verify(
        EmailDomainVerifyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Verify(EmailDomainVerifyParams, CancellationToken)"/>
    Task<EmailDomainVerifyResponse> Verify(
        string domainID,
        EmailDomainVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEmailDomainService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEmailDomainServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEmailDomainServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/email-domains</c>, but is otherwise the
    /// same as <see cref="IEmailDomainService.Create(EmailDomainCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EmailDomainCreateResponse>> Create(
        EmailDomainCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/email-domains/{domainId}</c>, but is otherwise the
    /// same as <see cref="IEmailDomainService.Retrieve(EmailDomainRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EmailDomainRetrieveResponse>> Retrieve(
        EmailDomainRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EmailDomainRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EmailDomainRetrieveResponse>> Retrieve(
        string domainID,
        EmailDomainRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /v1/email-domains</c>, but is otherwise the
    /// same as <see cref="IEmailDomainService.List(EmailDomainListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EmailDomainListResponse>> List(
        EmailDomainListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /v1/email-domains/{domainId}</c>, but is otherwise the
    /// same as <see cref="IEmailDomainService.Delete(EmailDomainDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse> Delete(
        EmailDomainDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EmailDomainDeleteParams, CancellationToken)"/>
    Task<HttpResponse> Delete(
        string domainID,
        EmailDomainDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /v1/email-domains/{domainId}/verify</c>, but is otherwise the
    /// same as <see cref="IEmailDomainService.Verify(EmailDomainVerifyParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EmailDomainVerifyResponse>> Verify(
        EmailDomainVerifyParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Verify(EmailDomainVerifyParams, CancellationToken)"/>
    Task<HttpResponse<EmailDomainVerifyResponse>> Verify(
        string domainID,
        EmailDomainVerifyParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
